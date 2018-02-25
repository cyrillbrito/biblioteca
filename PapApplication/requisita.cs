using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBClass;

namespace PapeApplication
{
    public partial class Requisita : Form
    {
        string _columns = "id_requ";
        string _tables = "view_requisita";
        string _conditions = "", _idli, _idle;

        public Requisita(string idLivro = "0", string idLeitores = "0")
        {
            InitializeComponent();

            _idli=idLivro;
            _idle = idLeitores;
        }

        private void Requisita_Load(object sender, EventArgs e)
        {
            Methods.LoadFormProperties(this);
            Methods.UpdateListView(listView, _columns, _tables, _conditions);

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
                DRequisita obj = new DRequisita(Convert.ToInt32(listView.SelectedItems[0].Text));
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, _tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.SaveFormProperties();
                DRequisita obj = new DRequisita(Convert.ToInt32(listView.SelectedItems[0].Text), true);
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, _tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            DRequisita obj = new DRequisita(0, true);
            obj.ShowDialog();
            Methods.UpdateListView(listView, _columns, _tables, _conditions);
        }

        private void search_ConditionChanged(object sender, EventArgs e)
        {
            Search search = sender as Search;
            CBClass.SearchLocal searchLocal = sender as CBClass.SearchLocal;
            int startPosition;
            int endPosition;

            if (searchLocal == null)
                startPosition = _conditions.IndexOf(search.CbIdColumn);
            else
                startPosition = _conditions.IndexOf(searchLocal.CbColumnName);

            if (startPosition != -1)//Foi encontrado
            {
                endPosition = _conditions.IndexOf("AND", startPosition);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1 -2 = -3
                    _conditions = _conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    _conditions = _conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if (search != null && search.CbValue != "")// Search normal
            {
                if (_conditions != "")
                    _conditions += " AND ";
                _conditions += search.CbIdColumn + " = " + search.CbValue;
            }
            else if (searchLocal != null)// SearchLocal
            {
                if (searchLocal.CbColumnName != "")
                {
                    if (_conditions != "")
                        _conditions += " AND ";
                    _conditions += searchLocal.CbColumnName + " LIKE '%" + searchLocal.CbValue + "%'";
                }
            }
            Methods.UpdateListView(listView, _columns, _tables, _conditions);
        }

        private void search_CheckBoxCheckedChange(object sender, EventArgs e)
        {
            Search search = sender as Search;
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
                Methods.UpdateListView(listView, _columns, _tables, _conditions);
            }
        }

        private void ToolStrip_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            this.Hide();
            switch ((sender as ToolStripMenuItem).Text)
            {
                case "Livros": Livros a = new Livros(); a.ShowDialog(); break;
                case "Leitores": Leitores b = new Leitores(); b.ShowDialog(); break;
                case "Requisitar": Requisita c = new Requisita(); c.ShowDialog(); break;
                case "Autores": Autores d = new Autores(); d.ShowDialog(); break;
                case "Categorias": Categoria f = new Categoria(); f.ShowDialog(); break;
                case "Editoras": Editora g = new Editora(); g.ShowDialog(); break;
                case "Funcionários": Funcionarios h = new Funcionarios(); h.ShowDialog(); break;
            }
        }

        private void search_ButtonClick(object sender, EventArgs e)
        {
            Search search = sender as Search;
            Methods.SaveFormProperties();

            switch (search.CbFormName)
            {
                case "livros": Livros a = new Livros(true); a.ShowDialog(); break;
                case "leitores": Leitores b = new Leitores(true); b.ShowDialog(); break;
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
                if (_conditions != "")
                    _conditions += " AND ";
                _conditions += "data_devo IS ";
                if (radioNaBiblioteca.Checked)
                    _conditions += "NOT null";
                else
                    _conditions += "null";

                if (radioAtraso.Checked)
                    _conditions += " AND data_entr < CURRENT_DATE";

            }
            Methods.UpdateListView(listView, _columns, _tables, _conditions);
        }
    }
}
