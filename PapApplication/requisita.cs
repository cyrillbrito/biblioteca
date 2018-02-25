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
    public partial class requisita : Form
    {
        string columns = "id_requ";
        string tables = "view_requisita";
        string conditions = "", idli, idle;

        public requisita(string idLivro = "0", string idLeitores = "0")
        {
            InitializeComponent();

            idli=idLivro;
            idle = idLeitores;
        }

        private void Requisita_Load(object sender, EventArgs e)
        {
            Methods.loadFormProperties(this);
            Methods.updateListView(listView, columns, tables, conditions);

            searchLeitor.CBisChecked = true;
            searchLivro.CBisChecked = true;
            searchLeitor.CBCheckBoxLocked = true;
            searchLivro.CBCheckBoxLocked = true;

            if (idli != "0")
            {
                searchLivro.CBValue = idli;
                searchLivro.reload();
            }
            else if (idle != "0")
            {
                searchLeitor.CBValue = idle;
                searchLeitor.reload();
            }
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Methods.saveFormProperties();
                dRequisita obj = new dRequisita(Convert.ToInt32(listView.SelectedItems[0].Text));
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
                dRequisita obj = new dRequisita(Convert.ToInt32(listView.SelectedItems[0].Text), true);
                obj.ShowDialog();
                Methods.updateListView(listView, columns, tables, conditions);
            }
            else
                MessageBox.Show("Tem de selecionar um item primeiro.");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Methods.saveFormProperties();
            dRequisita obj = new dRequisita(0, true);
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
            if (!search.CBCheckBoxLocked)
            {
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

        private void search_ButtonClick(object sender, EventArgs e)
        {
            CBClass.Controls.Search search = sender as CBClass.Controls.Search;
            Methods.saveFormProperties();

            switch (search.CBFormName)
            {
                case "livros": livros a = new livros(true); a.ShowDialog(); break;
                case "leitores": leitores b = new leitores(true); b.ShowDialog(); break;
            }
            search.CBValue = Variables.returnValue.ToString();
            search.reload();
            Variables.returnValue = 0;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            int startPosition;
            int endPosition;

            startPosition = conditions.IndexOf("data_devo");
            if (startPosition != -1)//Foi encontrado
            {
                endPosition = conditions.IndexOf("AND", startPosition);
                if (endPosition == -1)//Se for a ultima condicao nao vai ter AND ficar com o valor -1
                    conditions = conditions.Remove((startPosition - 5 >= 0) ? startPosition - 5 : 0);
                else
                    conditions = conditions.Remove(startPosition, endPosition - startPosition + 3);
            }

            startPosition = conditions.IndexOf("data_entr");
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
                conditions += "data_devo IS ";
                if (radioNaBiblioteca.Checked)
                    conditions += "NOT null";
                else
                    conditions += "null";

                if (radioAtraso.Checked)
                    conditions += " AND data_entr < CURRENT_DATE";

            }
            Methods.updateListView(listView, columns, tables, conditions);
        }
    }
}
