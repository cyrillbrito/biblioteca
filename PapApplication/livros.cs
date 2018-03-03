using CbClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PapApplication
{
    public partial class Livros : Form
    {
        private const string Tables = "view_livros";
        private string _columns = "id_livr, titulo";
        private string _conditions = "";
        private readonly string _idc;
        private readonly string _ida;
        private readonly string _ide;
        private readonly bool _select;

        public Livros(bool select = false, string idCate = "0", string idAuto = "0", string idEdit = "0")
        {
            InitializeComponent();
            _select = select;

            _idc = idCate;
            _ida = idAuto;
            _ide = idEdit;
        }

        private void Livros_Load(object sender, EventArgs e)
        {
            if (_select)
            {
                menuStrip1.Visible = false;
                buttonSelect.Font = new Font(buttonSelect.Font, FontStyle.Bold);
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                Methods.LoadFormProperties(this, true);
                label1.Text = "Selecionar Livro";
            }
            else
                Methods.LoadFormProperties(this);
            Methods.UpdateListView(listView, _columns, Tables, _conditions);

            if (_idc != "0")
            {
                searchCategoria.CbValue = _idc;
                searchCategoria.Reload();
                searchCategoria.CbIsChecked = true;
            }
            else if (_ida != "0")
            {
                searchAutor.CbValue = _ida;
                searchAutor.Reload();
                searchAutor.CbIsChecked = true;
            }
            else if (_ide != "0")
            {
                searchEditora.CbValue = _ide;
                searchEditora.Reload();
                searchEditora.CbIsChecked = true;
            }
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.SaveFormProperties();
                var obj = new DLivros(int.Parse(listView.SelectedItems[0].Text));
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
                var obj = new DLivros(int.Parse(listView.SelectedItems[0].Text), true);
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            var obj = new DLivros(0, true);
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

            if (_conditions != "")
                _conditions += " AND ";

            if (search != null)
            {
                if (search.CbValue != "")
                    _conditions += search.CbIdColumn + " = " + search.CbValue;
            }
            else
                _conditions += searchLocal.CbColumnName + " LIKE '%" + searchLocal.CbValue + "%'";

            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void Search_CheckBoxCheckedChange(object sender, EventArgs e)
        {
            var search = (Search)sender;
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

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                if (_select)
                {
                    Variables.ReturnValue = int.Parse(listView.SelectedItems[0].Text);
                    Close();
                }
                else
                {
                    Methods.SaveFormProperties();

                    var c = new Requisita(listView.SelectedItems[0].Text);
                    Hide();
                    c.ShowDialog();
                }
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var startPosition = _conditions.IndexOf("requisitado", StringComparison.Ordinal);

            if (startPosition != -1)//Foi encontrado
            {
                var endPosition = _conditions.IndexOf("AND", startPosition, StringComparison.Ordinal);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1
                    _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if (!radioTodos.Checked)
            {
                if (!string.IsNullOrWhiteSpace(_conditions))
                    _conditions += " AND ";
                _conditions += "requisitado = ";
                if (radioRequisitado.Checked)
                    _conditions += "1";
                else
                    _conditions += "0";
            }
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void Search_ButtonClick(object sender, EventArgs e)
        {
            var search = (Search)sender;
            Methods.SaveFormProperties();

            switch (search.CbFormName)
            {
                case "categoria": var a = new Categoria(true); a.ShowDialog(); break;
                case "autores": var b = new Autores(true); b.ShowDialog(); break;
                case "editora": var c = new Editora(true); c.ShowDialog(); break;
            }
            search.CbValue = Variables.ReturnValue.ToString();
            search.Reload();
            Variables.ReturnValue = 0;
        }
    }
}

