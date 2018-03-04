using CbClass;
using System;
using System.Windows.Forms;

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

            searchLeitor.CbIsChecked = true;
            searchLivro.CbIsChecked = true;
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

        private void ButtonDetails_Click(object sender, EventArgs e)
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

        private void ButtonEdit_Click(object sender, EventArgs e)
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

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            var obj = new DRequisita(0, true);
            obj.ShowDialog();
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void Search_ConditionChanged(object sender, EventArgs e)
        {
            var search = sender as Search;
            var searchLocal = sender as SearchLocal;

            var startPosition = _conditions.IndexOf(search != null ? search.CbIdColumn : searchLocal.CbColumnName, StringComparison.Ordinal);

            if (startPosition != -1)
            {
                var endPosition = _conditions.IndexOf("AND", startPosition, StringComparison.Ordinal);

                if (endPosition == -1)
                    _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if ((search != null && search.CbValue != "") || (searchLocal != null && searchLocal.CbValue != ""))
            {
                if (_conditions != "")
                    _conditions += " AND ";

                if (search != null)
                    _conditions += search.CbIdColumn + " = " + search.CbValue;
                else
                    _conditions += searchLocal.CbColumnName + " LIKE '%" + searchLocal.CbValue + "%'";
            }

            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void Search_CheckBoxCheckedChange(object sender, EventArgs e)
        {
            var search = (Search)sender;
            if (!search.CbCheckBoxLocked)
            {
                if (search.CbIsChecked)
                {
                    listView.Columns.Add(search.CbText);
                    _columns += ", " + search.CbColumnName;
                }
                else
                {
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        if (listView.Columns[i].Text == search.CbText)
                        {
                            listView.Columns[i].Dispose();
                            break;
                        }
                    }
                    _columns = _columns.Replace(", " + search.CbColumnName, "");
                }
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
        }

        private void ToolStrip_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            Hide();
            switch (((ToolStripMenuItem)sender).Text)
            {
                case "Livros": var a = new Livros(); a.ShowDialog(); break;
                case "Leitores": var b = new Leitores(); b.ShowDialog(); break;
                case "Requisitar": var c = new Requisita(); c.ShowDialog(); break;
                case "Autores": var d = new Autores(); d.ShowDialog(); break;
                case "Categorias": var f = new Categoria(); f.ShowDialog(); break;
                case "Editoras": var g = new Editora(); g.ShowDialog(); break;
            }
        }

        private void Search_ButtonClick(object sender, EventArgs e)
        {
            var search = (Search)sender;
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

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var startPosition = _conditions.IndexOf("data_devo", StringComparison.Ordinal);
            if (startPosition != -1)//Foi encontrado
            {
                int endPosition = _conditions.IndexOf("AND", startPosition, StringComparison.Ordinal);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1
                    _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            startPosition = _conditions.IndexOf("data_entr", StringComparison.Ordinal);
            if (startPosition != -1)//Foi encontrado
            {
                int endPosition = _conditions.IndexOf("AND", startPosition, StringComparison.Ordinal);
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
