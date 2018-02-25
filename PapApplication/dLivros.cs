using CBClass;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PapeApplication
{
    public partial class DLivros : Form
    {
        int _id;
        bool _edit = false;

        public DLivros(int id = 0, bool edit = false)
        {
            InitializeComponent();

            _id = id;
            if (edit == false)
                ViewMode();
            else if (_id == 0)
            {
                EditMode();
                AddMode();
            }
            else
            {
                ViewMode();
                EditMode();
            }
        }

        private void dLivros_Load(object sender, EventArgs e)
        {
            Methods.LoadFormPosition(this);
        }

        private void EditMode()
        {
            _edit = true;
            searchTitulo.CbReadOnly = false;
            searchPaginas.CbReadOnly = false;
            searchCategoria.CbReadOnly = false;
            searchAutor.CbReadOnly = false;
            searchEditora.CbReadOnly = false;
            searchData.CbReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonEliminar.Visible = true;
        }

        private void ViewMode()
        {
            using (var query = new Mysql("*", "livros", "id_livr = " + _id))
            {
                query.Read();

                searchId.CbValue = query.Read("id_livr").ToString();
                searchTitulo.CbValue = query.Read("titulo").ToString();
                searchPaginas.CbValue = query.Read("n_pagi").ToString();
                searchCategoria.CbValue = query.Read("id_cate").ToString();
                searchAutor.CbValue = query.Read("id_auto").ToString();
                searchEditora.CbValue = query.Read("id_edit").ToString();
                searchEditora.CbValue = query.Read("id_edit").ToString();
                searchData.CbValue = query.Read("data_lanc").ToString();
            }

            _edit = false;
            searchTitulo.CbReadOnly = true;
            searchPaginas.CbReadOnly = true;
            searchCategoria.CbReadOnly = true;
            searchAutor.CbReadOnly = true;
            searchEditora.CbReadOnly = true;
            searchData.CbReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonEliminar.Visible = false;
        }

        private void AddMode()
        {
            _edit = false;

            using (var query = new Mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'livros'"))
            {
                query.Read();
                // todo tostring ?
                searchId.CbValue = query.Read("a").ToString();
                _id = Convert.ToInt16(searchId.CbValue);
                buttonEliminar.Visible = false;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<string> list = CheckData();
            string str;
            if (list.Count == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende guadar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_edit)
                    {
                        str = "titulo = '" + searchTitulo.CbValue + "', n_pagi = '" + searchPaginas.CbValue + "', id_cate = '" + searchCategoria.CbValue + "', id_auto = '" + searchAutor.CbValue + "', id_edit = '" + searchEditora.CbValue + "', data_lanc = '" + searchData.CbValue + "'";
                        Mysql.Update("livros", str, "id_livr = " + _id.ToString());
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchTitulo.CbValue + "', '" + searchPaginas.CbValue + "', '" + searchCategoria.CbValue + "', '" + searchAutor.CbValue + "', '" + searchEditora.CbValue + "', '" + searchData.CbValue + "'";
                        Mysql.Insert("livros", "titulo, n_pagi, id_cate, id_auto, id_edit, data_lanc", str);
                        MessageBox.Show("Os dados foram inseridos");
                    }
                    ViewMode();
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

        private List<string> CheckData()
        {
            int num;
            List<string> list = new List<string>();

            if (searchTitulo.CbValue == "")
                list.Add("Titulo");
            if (!int.TryParse(searchPaginas.CbValue, out num) || num <= 0)
                list.Add("Paginas");
            if (searchCategoria.CbValue == "ID")
                list.Add("Categoria");
            if (searchAutor.CbValue == "ID")
                list.Add("Autor");
            if (searchEditora.CbValue == "ID")
                list.Add("Editora");

            return list;
        }

        private void search_ButtonClick(object sender, EventArgs e)
        {
            CBClass.Controls.Search search = sender as CBClass.Controls.Search;

            switch (search.CbFormName)
            {
                case "categoria": Categoria a = new Categoria(true); a.ShowDialog(); break;
                case "autores": Autores b = new Autores(true); b.ShowDialog(); break;
                case "editora": Editora c = new Editora(true); c.ShowDialog(); break;
            }
            search.CbValue = Variables.ReturnValue.ToString();
            search.Reload();
            Variables.ReturnValue = 0;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Mysql.Delete("livros", "id_livr = " + _id);

                MessageBox.Show("Registo Eliminado");
                this.Close();
            }
        }
    }
}
