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
    public partial class dLivros : Form
    {
        int id;
        bool edit = false;

        public dLivros(int ID = 0, bool edit = false)
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

        private void dLivros_Load(object sender, EventArgs e)
        {
            Methods.loadFormPosition(this);
        }

        private void editMode()
        {
            edit = true;
            searchTitulo.CBReadOnly = false;
            searchPaginas.CBReadOnly = false;
            searchCategoria.CBReadOnly = false;
            searchAutor.CBReadOnly = false;
            searchEditora.CBReadOnly = false;
            searchData.CBReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonEliminar.Visible = true;
        }

        private void viewMode()
        {
            mysql query = new mysql("*", "livros", "id_livr = " + id);
            query.read();

            searchId.CBValue = query.read("id_livr").ToString();
            searchTitulo.CBValue = query.read("titulo").ToString();
            searchPaginas.CBValue = query.read("n_pagi").ToString();
            searchCategoria.CBValue = query.read("id_cate").ToString();
            searchAutor.CBValue = query.read("id_auto").ToString();
            searchEditora.CBValue = query.read("id_edit").ToString();
            searchEditora.CBValue = query.read("id_edit").ToString();
            searchData.CBValue = query.read("data_lanc").ToString();
            query.close();

            edit = false;
            searchTitulo.CBReadOnly = true;
            searchPaginas.CBReadOnly = true;
            searchCategoria.CBReadOnly = true;
            searchAutor.CBReadOnly = true;
            searchEditora.CBReadOnly = true;
            searchData.CBReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonEliminar.Visible = false;
        }

        private void addMode()
        {
            edit = false;
            mysql query = new mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'livros'");
            query.read();
            searchId.CBValue = query.read("a").ToString();
            id = Convert.ToInt16(searchId.CBValue);
            buttonEliminar.Visible = false;
            query.close();
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
                        str = "titulo = '" + searchTitulo.CBValue + "', n_pagi = '" + searchPaginas.CBValue + "', id_cate = '" + searchCategoria.CBValue + "', id_auto = '" + searchAutor.CBValue + "', id_edit = '" + searchEditora.CBValue + "', data_lanc = '" + searchData.CBValue + "'";
                        mysql.update("livros", str, "id_livr = " + id.ToString());
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchTitulo.CBValue + "', '" + searchPaginas.CBValue + "', '" + searchCategoria.CBValue + "', '" + searchAutor.CBValue + "', '" + searchEditora.CBValue + "', '" + searchData.CBValue + "'";
                        mysql.insert("livros", "titulo, n_pagi, id_cate, id_auto, id_edit, data_lanc", str);
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
            int num;
            List<string> list = new List<string>();

            if (searchTitulo.CBValue == "")
                list.Add("Titulo");
            if (!int.TryParse(searchPaginas.CBValue, out num) || num <= 0)
                list.Add("Paginas");
            if (searchCategoria.CBValue == "ID")
                list.Add("Categoria");
            if (searchAutor.CBValue == "ID")
                list.Add("Autor");
            if (searchEditora.CBValue == "ID")
                list.Add("Editora");

            return list;
        }

        private void search_ButtonClick(object sender, EventArgs e)
        {
            CBClass.Controls.Search search = sender as CBClass.Controls.Search;

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

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                mysql.delete("livros", "id_livr = " + id);

                MessageBox.Show("Registo Eliminado");
                this.Close();
            }
        }
    }
}
