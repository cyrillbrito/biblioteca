﻿using CbClass;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PapApplication
{
    public partial class DLivros : Form
    {
        private int _id;
        private bool _edit;

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

        private void DLivros_Load(object sender, EventArgs e)
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

                searchId.CbValue = query.Read("id_livr");
                searchTitulo.CbValue = query.Read("titulo");
                searchPaginas.CbValue = query.Read("n_pagi");
                searchCategoria.CbValue = query.Read("id_cate");
                searchAutor.CbValue = query.Read("id_auto");
                searchEditora.CbValue = query.Read("id_edit");
                searchEditora.CbValue = query.Read("id_edit");
                searchData.CbValue = query.Read("data_lanc");
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

                searchId.CbValue = query.Read("a");
                _id = int.Parse(searchId.CbValue);
                buttonEliminar.Visible = false;
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var list = CheckData();
            string str;
            if (list.Count == 0)
            {
                var dialogResult = MessageBox.Show("Tem a certeza que pretende guadar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_edit)
                    {
                        str = "titulo = '" + searchTitulo.CbValue + "', n_pagi = '" + searchPaginas.CbValue + "', id_cate = '" + searchCategoria.CbValue + "', id_auto = '" + searchAutor.CbValue + "', id_edit = '" + searchEditora.CbValue + "', data_lanc = '" + searchData.CbValue + "'";
                        Mysql.Update("livros", str, "id_livr = " + _id);
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
                foreach (var s in list)
                {
                    str += "\n     - " + s;
                }
                MessageBox.Show(str);
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Tem a certeza que pretende cancelar?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Close();
        }

        private List<string> CheckData()
        {
            var list = new List<string>();

            if (string.IsNullOrWhiteSpace(searchTitulo.CbValue))
                list.Add("Titulo");
            if (!int.TryParse(searchPaginas.CbValue, out var num) || num <= 0)
                list.Add("Paginas");
            if (searchCategoria.CbValue == "ID")
                list.Add("Categoria");
            if (searchAutor.CbValue == "ID")
                list.Add("Autor");
            if (searchEditora.CbValue == "ID")
                list.Add("Editora");

            return list;
        }

        private void Search_ButtonClick(object sender, EventArgs e)
        {
            var search = (Search)sender;

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

        private void ButtonEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Mysql.Delete("livros", "id_livr = " + _id);

                MessageBox.Show("Registo Eliminado");
                Close();
            }
        }
    }
}
