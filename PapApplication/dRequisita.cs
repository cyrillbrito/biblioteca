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
    public partial class dRequisita : Form
    {
        int id;
        string id2;
        bool edit = false;

        public dRequisita(int ID = 0, bool edit = false)
        {
            InitializeComponent();

            id = ID;
            if (edit == false)
                viewMode();
            else if (id == 0)
            {
                editMode();
                addMode();
            }
            else
            {
                viewMode();
                editMode();
            }
        }

        private void dRequisita_Load(object sender, EventArgs e)
        {
            Methods.loadFormPosition(this);
        }

        private void editMode()
        {
            id2 = searchLivro.CBValue;
            edit = true;
            searchLivro.CBReadOnly = false;
            searchLeitor.CBReadOnly = false;
            searchRequisita.CBReadOnly = false;
            searchEntrega.CBReadOnly = false;
            searchDevolucao.CBReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonEntregar.Visible = false;
            buttonEstender.Visible = false;
            buttonEliminar.Visible = true;
        }

        private void viewMode()
        {
            mysql query = new mysql("*", "view_requisita", "id_requ = " + id);

            query.read();

            searchId.CBValue = query.read("id_requ").ToString();
            searchLivro.CBValue = query.read("id_livr").ToString();
            searchLeitor.CBValue = query.read("id_leit").ToString();
            searchRequisita.CBValue = query.read("data_requ").ToString();
            searchEntrega.CBValue = query.read("data_entr").ToString();

            if (query.read("data_devo").ToString() == "")
            {
                searchDevolucao.Visible = false;
                label1.Visible = true;
                buttonEntregar.Visible = true;
                buttonEstender.Visible = true;
            }
            else
            {
                searchDevolucao.Visible = true;
                label1.Visible = false;
                searchDevolucao.CBValue = query.read("data_devo").ToString();
                buttonEntregar.Visible = false;
                buttonEstender.Visible = false;
            }
            query.close();

            edit = false;
            searchLivro.CBReadOnly = true;
            searchLeitor.CBReadOnly = true;
            searchRequisita.CBReadOnly = true;
            searchEntrega.CBReadOnly = true;
            searchDevolucao.CBReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonEliminar.Visible = false;
        }

        private void addMode()
        {
            edit = false;
            mysql query = new mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'requisita'");
            query.read();
            searchId.CBValue = query.read("a").ToString();
            id = Convert.ToInt16(searchId.CBValue);
            query.close();

            searchRequisita.CBValue = DateTime.Today.ToString("yyyy-MM-dd");
            searchEntrega.CBValue = DateTime.Today.AddDays(15).ToString("yyyy-MM-dd"); ;
            searchDevolucao.Visible = false;
            searchRequisita.CBReadOnly = true;
            searchEntrega.CBReadOnly = true;
            buttonEliminar.Visible = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            editMode();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<string> list = checkData();
            string str;
            if (list.Count == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende guadar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (edit)
                    {
                        str = "id_livr = '" + searchLivro.CBValue + "', id_leit = '" + searchLeitor.CBValue + "', data_entr = '" + searchEntrega.CBValue + "', data_requ = '" + searchRequisita.CBValue + "'";
                        if (searchDevolucao.Visible)
                            str += ", data_devo = '" + searchDevolucao.CBValue + "'";

                        mysql.update("requisita", str, "id_requ = " + id.ToString());
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchLivro.CBValue + "', '" + searchLeitor.CBValue + "', '" + searchRequisita.CBValue + "', '" + searchEntrega.CBValue + "', '" + Variables.funcId.ToString() + "'";
                        mysql.insert("requisita", "id_livr, id_leit, data_requ, data_entr, id_func", str);
                        mysql.update("livros", "requisitado = 1", "id_livr = " + searchLivro.CBValue);
                        MessageBox.Show("Os dados foram inseridos");
                    }
                    viewMode();
                }
            }
            else
            {
                str = "Os seguintes campos estão incorectos:";
                foreach (string s in list)
                {
                    str += "\n     - " + s;
                }
                MessageBox.Show(str);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende cancelar?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        private List<string> checkData()
        {
            List<string> list = new List<string>();
            mysql query;

            if (searchLivro.CBValue == "ID")
            {
                list.Add("Livro");
            }
            else
            {
                query = new mysql("requisitado", "livros", "id_livr = " + searchLivro.CBValue);
                query.read();
                if (Convert.ToBoolean(query.read("requisitado")) && id2 != searchLivro.CBValue)
                    list.Add("O livro já está requisitado");
                query.close();
            }

            if (searchLeitor.CBValue == "ID")
                list.Add("Leitor");

            if (DateTime.Compare(Convert.ToDateTime(searchRequisita.CBValue), Convert.ToDateTime(searchEntrega.CBValue)) >= 0)
                list.Add("Data de requisição ou data limite de entraga");


            return list;
        }

        private void buttonEntregar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Pretende entregar o livro?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string str = "data_devo = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                mysql.update("requisita", str, "id_requ = " + id.ToString());
                mysql.update("livros", "requisitado = 0", "id_livr = " + searchLivro.CBValue);
                MessageBox.Show("Livro entregue.");
                viewMode();
            }
        }

        private void buttonEstender_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Pretende estender a data de entrega do livro em uma semana?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                mysql query = new mysql("data_entr", "requisita", "id_requ = " + id);
                query.read();

                string str = "data_entr = '" + Convert.ToDateTime(query.read("data_entr")).AddDays(7).ToString("yyyy-MM-dd") + "'";
                query.close();
                mysql.update("requisita", str, "id_requ = " + id.ToString());

                MessageBox.Show("Livro entregue.");
                viewMode();
            }
        }

        private void search_ButtonClick(object sender, EventArgs e)
        {
            CBClass.Controls.Search search = sender as CBClass.Controls.Search;

            switch (search.CBFormName)
            {
                case "livros": livros a = new livros(true); a.ShowDialog(); break;
                case "leitores": leitores b = new leitores(true); b.ShowDialog(); break;
            }
            search.CBValue = Variables.returnValue.ToString();
            search.reload();
            Variables.returnValue = 0;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                mysql.delete("requisita", "id_requ = " + id);

                MessageBox.Show("Registo Eliminado");
                this.Close();
            }
        }
    }
}
