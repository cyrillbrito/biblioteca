using System;
using System.Windows.Forms;
using CbClass;

namespace PapApplication
{
    public partial class Requisita : Form
    {
        private const string Tables = "view_requisita";
        private string _columns = "id_requ";
        private string _conditions = "";
        private readonly string _idli;
        private readonly string _idle;

        public Requisita(string idLivro = "0", string idLeitores = "0")
        {
            InitializeComponent();

            _idli = idLivro;
            _idle = idLeitores;
        }

        private void Requisita_Load(object sender, EventArgs e)
        {
            Methods.LoadFormProperties(this);
            Methods.UpdateListView(listView, _columns, Tables, _conditions);

            searchLeitor.CBisChecked = true;
            searchLivro.CBisChecked = true;
            searchLeitor.CbCheckBoxLocked = true;
            searchLivro.CbCheckBoxLocked = true;

            if (_idli != "0")
            {
                searchLivro.CbValue = _idli;
                searchLivro.Reload();
            }
            else if (_idle != "0")
            {
                searchLeitor.CbValue = _idle;
                searchLeitor.Reload();
            }
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.SaveFormProperties();
                var obj = new DRequisita(int.Parse(listView.SelectedItems[0].Text));
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.SaveFormProperties();
                var obj = new DRequisita(int.Parse(listView.SelectedItems[0].Text), true);
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            var obj = new DRequisita(0, true);
            obj.ShowDialog();
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void Search_ConditionChanged(object sender, EventArgs e)
        {
            var search = (Search) sender;
            var searchLocal = sender as SearchLocal;
            int startPosition;

            if (searchLocal == null)
                startPosition = _conditions.IndexOf(search.CbIdColumn);
            else
                startPosition = _conditions.IndexOf(searchLocal.CbColumnName);

            if (startPosition != -1)//Foi encontrado
            {
                var endPosition = _conditions.IndexOf("AND", startPosition);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1 -2 = -3
                    _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if (!string.IsNullOrWhiteSpace(search?.CbValue))// Search normal
            {
                if (!string.IsNullOrWhiteSpace(_conditions))
                    _conditions += " AND ";
                _conditions += search.CbIdColumn + " = " + search.CbValue;
            }
            else if (searchLocal != null)// SearchLocal
            {
                if (!string.IsNullOrWhiteSpace(searchLocal.CbColumnName))
                {
                    if (!string.IsNullOrWhiteSpace(_conditions))
                        _conditions += " AND ";
                    _conditions += searchLocal.CbColumnName + " LIKE '%" + searchLocal.CbValue + "%'";
                }
            }
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void search_CheckBoxCheckedChange(object sender, EventArgs e)
        {
            var search = (Search) sender;
            if (!search.CbCheckBoxLocked)
            {
                if (search.CBisChecked)
                {
                    listView.Columns.Add(search.CbText);
                    _columns += ", " + search.CbColumnName;
                }
                else
                {
                    int i;
                    for (i = 0; listView.Columns[i].Text != search.CbText; i++) ;
                    listView.Columns[i].Dispose();
                    _columns = _columns.Replace(", " + search.CbColumnName, "");
                }
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
        }

        private void ToolStrip_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            Hide();
            switch ((sender as ToolStripMenuItem).Text)
            {
                case "Livros": var a = new Livros(); a.ShowDialog(); break;
                case "Leitores": var b = new Leitores(); b.ShowDialog(); break;
                case "Requisitar": var c = new Requisita(); c.ShowDialog(); break;
                case "Autores": var d = new Autores(); d.ShowDialog(); break;
                case "Categorias": var f = new Categoria(); f.ShowDialog(); break;
                case "Editoras": var g = new Editora(); g.ShowDialog(); break;
            }
        }

        private void search_ButtonClick(object sender, EventArgs e)
        {
            var search = (Search) sender;
            Methods.SaveFormProperties();

            switch (search.CbFormName)
            {
                case "livros": var a = new Livros(true); a.ShowDialog(); break;
                case "leitores": var b = new Leitores(true); b.ShowDialog(); break;
            }
            search.CbValue = Variables.ReturnValue.ToString();
            search.Reload();
            Variables.ReturnValue = 0;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            int startPosition;
            int endPosition;

            startPosition = _conditions.IndexOf("data_devo");
            if (startPosition != -1)//Foi encontrado
            {
                endPosition = _conditions.IndexOf("AND", startPosition);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1
                    _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            startPosition = _conditions.IndexOf("data_entr");
            if (startPosition != -1)//Foi encontrado
            {
                endPosition = _conditions.IndexOf("AND", startPosition);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1
                    _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if (!radioTodos.Checked)
            {
                if (!string.IsNullOrWhiteSpace(_conditions))
                    _conditions += " AND ";
                _conditions += "data_devo IS ";
                if (radioNaBiblioteca.Checked)
                    _conditions += "NOT null";
                else
                    _conditions += "null";

                if (radioAtraso.Checked)
                    _conditions += " AND data_entr < CURRENT_DATE";

            }
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }
    }
}
