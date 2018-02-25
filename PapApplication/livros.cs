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
    public partial class livros : Form
    {
        string columns = "id_livr, titulo";
        string tables = "view_livros";
        string conditions = "", idc, ida, ide;
        bool select;

        public livros(bool Select = false, string idCate = "0", string idAuto = "0", string idEdit = "0")
        {
            InitializeComponent();
            select = Select;

            idc = idCate;
            ida = idAuto;
            ide = idEdit;
        }

        private void livros_Load(object sender, EventArgs e)
        {
            if (select)
            {
                menuStrip1.Visible = false;
                buttonSelect.Font = new Font(buttonSelect.Font, FontStyle.Bold);
                this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                Methods.loadFormProperties(this, true);
                label1.Text = "Selecionar Livro";
            }
            else
                Methods.loadFormProperties(this);

            if (idc != "0")
            {
                searchCategoria.CBValue = idc;
                searchCategoria.reload();
                searchCategoria.CBisChecked = true;
            }
            else if (ida != "0")
            {
                searchAutor.CBValue = ida;
                searchAutor.reload();
                searchAutor.CBisChecked = true;
            }
            else if (ide != "0")
            {
                searchEditora.CBValue = ide;
                searchEditora.reload();
                searchEditora.CBisChecked = true;
            }

            Methods.updateListView(listView, columns, tables, conditions);
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.saveFormProperties();
                dLivros obj = new dLivros(Convert.ToInt32(listView.SelectedItems[0].Text));
                obj.ShowDialog();
                Methods.updateListView(listView, columns, tables, conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.saveFormProperties();
                dLivros obj = new dLivros(Convert.ToInt32(listView.SelectedItems[0].Text), true);
                obj.ShowDialog();
                Methods.updateListView(listView, columns, tables, conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Methods.saveFormProperties();
            dLivros obj = new dLivros(0, true);
            obj.ShowDialog();
            Methods.updateListView(listView, columns, tables, conditions);
        }

        private void search_ConditionChanged(object sender, EventArgs e)
        {
            CBClass.Controls.Search search = sender as CBClass.Controls.Search;
            CBClass.SearchLocal searchLocal = sender as CBClass.SearchLocal;
            int startPosition;
            int endPosition;

            if (searchLocal == null)
                startPosition = conditions.IndexOf(search.CBIdColumn);
            else
                startPosition = conditions.IndexOf(searchLocal.CBColumnName);

            if (startPosition != -1)//Foi encontrado
            {
                endPosition = conditions.IndexOf("AND", startPosition);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1 -2 = -3
                    conditions = conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    conditions = conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if (search != null && search.CBValue != "")// Search normal
            {
                if (conditions != "")
                    conditions += " AND ";
                conditions += search.CBIdColumn + " = " + search.CBValue;
            }
            else if (searchLocal != null)// SearchLocal
            {
                if (searchLocal.CBColumnName != "")
                {
                    if (conditions != "")
                        conditions += " AND ";
                    conditions += searchLocal.CBColumnName + " LIKE '%" + searchLocal.CBValue + "%'";
                }
            }
            Methods.updateListView(listView, columns, tables, conditions);
        }

        private void search_CheckBoxCheckedChange(object sender, EventArgs e)
        {
            CBClass.Controls.Search search = sender as CBClass.Controls.Search;
            if (search.CBisChecked)
            {
                listView.Columns.Add(search.CBText);
                columns += ", " + search.CBColumnName;
            }
            else
            {
                int i;
                for (i = 0; listView.Columns[i].Text != search.CBText; i++) ;
                listView.Columns[i].Dispose();
                columns = columns.Replace(", " + search.CBColumnName, "");
            }
            Methods.updateListView(listView, columns, tables, conditions);
        }

        private void ToolStrip_Click(object sender, EventArgs e)
        {
            Methods.saveFormProperties();
            this.Hide();
            switch ((sender as ToolStripMenuItem).Text)
            {
                case "Livros": livros a = new livros(); a.ShowDialog(); break;
                case "Leitores": leitores b = new leitores(); b.ShowDialog(); break;
                case "Requisitar": requisita c = new requisita(); c.ShowDialog(); break;
                case "Autores": autores d = new autores(); d.ShowDialog(); break;
                case "Categorias": categoria f = new categoria(); f.ShowDialog(); break;
                case "Editoras": editora g = new editora(); g.ShowDialog(); break;
                case "Funcionários": funcionarios h = new funcionarios(); h.ShowDialog(); break;
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                if (select)
                {
                    Variables.returnValue = Convert.ToInt32(listView.SelectedItems[0].Text);
                    this.Close();
                }
                else
                {
                    Methods.saveFormProperties();

                    requisita c = new requisita(listView.SelectedItems[0].Text);
                    this.Hide();
                    c.ShowDialog();
                }
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            int startPosition;
            int endPosition;

            startPosition = conditions.IndexOf("requisitado");
            if (startPosition != -1)//Foi encontrado
            {
                endPosition = conditions.IndexOf("AND", startPosition);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1
                    conditions = conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    conditions = conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            if (!radioTodos.Checked)
            {
                if (conditions != "")
                    conditions += " AND ";
                conditions += "requisitado = ";
                if (radioRequisitado.Checked)
                    conditions += "1";
                else
                    conditions += "0";
            }
            Methods.updateListView(listView, columns, tables, conditions);
        }

        private void search_ButtonClick(object sender, EventArgs e)
        {
            CBClass.Controls.Search search = sender as CBClass.Controls.Search;
            Methods.saveFormProperties();

            switch (search.CBFormName)
            {
                case "categoria": categoria a = new categoria(true); a.ShowDialog(); break;
                case "autores": autores b = new autores(true); b.ShowDialog(); break;
                case "editora": editora c = new editora(true); c.ShowDialog(); break;
            }
            search.CBValue = Variables.returnValue.ToString();
            search.reload();
            Variables.returnValue = 0;
        }
    }
}

