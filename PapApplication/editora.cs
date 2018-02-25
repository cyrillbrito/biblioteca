using CbClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PapApplication
{
    public partial class Editora : Form
    {
        private const string Tables = "editoras";
        private string _columns = "id_edit, editora";
        private string _conditions = "";
        private readonly bool _select;

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
                FormBorderStyle = FormBorderStyle.SizableToolWindow;
                Methods.LoadFormProperties(this, true);
                label1.Text = "Selecionar Editora";
            }
            else
                Methods.LoadFormProperties(this);

            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.SaveFormProperties();
                var obj = new DEditora(int.Parse(listView.SelectedItems[0].Text));
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
                var obj = new DEditora(int.Parse(listView.SelectedItems[0].Text), true);
                obj.ShowDialog();
                Methods.UpdateListView(listView, _columns, Tables, _conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Methods.SaveFormProperties();
            var obj = new DEditora(0, true);
            obj.ShowDialog();
            Methods.UpdateListView(listView, _columns, Tables, _conditions);
        }

        private void Search_ConditionChanged(object sender, EventArgs e)
        {
            _conditions = FormsHelper.SearchConditionChanged(sender, _conditions);
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

        private void buttonSelect_Click(object sender, EventArgs e)
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

                    var c = new Livros(false, "0", "0", listView.SelectedItems[0].Text);
                    Hide();
                    c.ShowDialog();
                }
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }
    }
}
