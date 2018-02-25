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
    public partial class Editora : Form
    {
        string _columns = "id_edit, editora";
        string _tables = "editoras";
        string _conditions = "";
        bool _select;

        public Editora(bool @select = false)
        {
            InitializeComponent();
            _select = @select;
        }

        private void editora_Load(object sender, EventArgs e)
        {
            if (_select)
            {
                menuStrip1.Visible = false;
                buttonSelect.Font = new Font(buttonSelect.Font, FontStyle.Bold);
                this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                Methods.LoadFormProperties(this, true);
                label1.Text = "Selecionar Editora";
            }
            else
                Methods.LoadFormProperties(this);
            
            Methods.UpdateListView(listView, _columns, _tables, _conditions);
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.SaveFormProperties();
                DEditora obj = new DEditora(Convert.ToInt32(listView.SelectedItems[0].Text));
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
                DEditora obj = new DEditora(Convert.ToInt32(listView.SelectedItems[0].Text), true);
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, _tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            DEditora obj = new DEditora(0, true);
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

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                if (_select)
                {
                    Variables.ReturnValue = Convert.ToInt32(listView.SelectedItems[0].Text);
                    this.Close();
                }
                else
                {
                    Methods.SaveFormProperties();

                    Livros c = new Livros(false, "0", "0", listView.SelectedItems[0].Text);
                    this.Hide();
                    c.ShowDialog();
                }
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }
    }
}
