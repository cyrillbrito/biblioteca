﻿using System;
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
    public partial class DRequisita : Form
    {
        int _id;
        string _id2;
        bool _edit = false;

        public DRequisita(int id = 0, bool edit = false)
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

        private void dRequisita_Load(object sender, EventArgs e)
        {
            Methods.LoadFormPosition(this);
        }

        private void EditMode()
        {
            _id2 = searchLivro.CbValue;
            _edit = true;
            searchLivro.CbReadOnly = false;
            searchLeitor.CbReadOnly = false;
            searchRequisita.CbReadOnly = false;
            searchEntrega.CbReadOnly = false;
            searchDevolucao.CbReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonEntregar.Visible = false;
            buttonEstender.Visible = false;
            buttonEliminar.Visible = true;
        }

        private void ViewMode()
        {
            Mysql query = new Mysql("*", "view_requisita", "id_requ = " + _id);

            query.Read();

            searchId.CbValue = query.Read("id_requ").ToString();
            searchLivro.CbValue = query.Read("id_livr").ToString();
            searchLeitor.CbValue = query.Read("id_leit").ToString();
            searchRequisita.CbValue = query.Read("data_requ").ToString();
            searchEntrega.CbValue = query.Read("data_entr").ToString();

            if (query.Read("data_devo").ToString() == "")
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
                searchDevolucao.CbValue = query.Read("data_devo").ToString();
                buttonEntregar.Visible = false;
                buttonEstender.Visible = false;
            }
            query.Close();

            _edit = false;
            searchLivro.CbReadOnly = true;
            searchLeitor.CbReadOnly = true;
            searchRequisita.CbReadOnly = true;
            searchEntrega.CbReadOnly = true;
            searchDevolucao.CbReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonEliminar.Visible = false;
        }

        private void AddMode()
        {
            _edit = false;
            Mysql query = new Mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'requisita'");
            query.Read();
            searchId.CbValue = query.Read("a").ToString();
            _id = Convert.ToInt16(searchId.CbValue);
            query.Close();

            searchRequisita.CbValue = DateTime.Today.ToString("yyyy-MM-dd");
            searchEntrega.CbValue = DateTime.Today.AddDays(15).ToString("yyyy-MM-dd"); ;
            searchDevolucao.Visible = false;
            searchRequisita.CbReadOnly = true;
            searchEntrega.CbReadOnly = true;
            buttonEliminar.Visible = false;
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
                        str = "id_livr = '" + searchLivro.CbValue + "', id_leit = '" + searchLeitor.CbValue + "', data_entr = '" + searchEntrega.CbValue + "', data_requ = '" + searchRequisita.CbValue + "'";
                        if (searchDevolucao.Visible)
                            str += ", data_devo = '" + searchDevolucao.CbValue + "'";

                        Mysql.Update("requisita", str, "id_requ = " + _id.ToString());
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchLivro.CbValue + "', '" + searchLeitor.CbValue + "', '" + searchRequisita.CbValue + "', '" + searchEntrega.CbValue + "', '" + Variables.FuncId.ToString() + "'";
                        Mysql.Insert("requisita", "id_livr, id_leit, data_requ, data_entr, id_func", str);
                        Mysql.Update("livros", "requisitado = 1", "id_livr = " + searchLivro.CbValue);
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
            List<string> list = new List<string>();
            Mysql query;

            if (searchLivro.CbValue == "ID")
            {
                list.Add("Livro");
            }
            else
            {
                query = new Mysql("requisitado", "livros", "id_livr = " + searchLivro.CbValue);
                query.Read();
                if (Convert.ToBoolean(query.Read("requisitado")) && _id2 != searchLivro.CbValue)
                    list.Add("O livro já está requisitado");
                query.Close();
            }

            if (searchLeitor.CbValue == "ID")
                list.Add("Leitor");

            if (DateTime.Compare(Convert.ToDateTime(searchRequisita.CbValue), Convert.ToDateTime(searchEntrega.CbValue)) >= 0)
                list.Add("Data de requisição ou data limite de entraga");


            return list;
        }

        private void buttonEntregar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Pretende entregar o livro?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string str = "data_devo = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                Mysql.Update("requisita", str, "id_requ = " + _id.ToString());
                Mysql.Update("livros", "requisitado = 0", "id_livr = " + searchLivro.CbValue);
                MessageBox.Show("Livro entregue.");
                ViewMode();
            }
        }

        private void buttonEstender_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Pretende estender a data de entrega do livro em uma semana?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Mysql query = new Mysql("data_entr", "requisita", "id_requ = " + _id);
                query.Read();

                string str = "data_entr = '" + Convert.ToDateTime(query.Read("data_entr")).AddDays(7).ToString("yyyy-MM-dd") + "'";
                query.Close();
                Mysql.Update("requisita", str, "id_requ = " + _id.ToString());

                MessageBox.Show("Livro entregue.");
                ViewMode();
            }
        }

        private void search_ButtonClick(object sender, EventArgs e)
        {
            CBClass.Controls.Search search = sender as CBClass.Controls.Search;

            switch (search.CbFormName)
            {
                case "livros": Livros a = new Livros(true); a.ShowDialog(); break;
                case "leitores": Leitores b = new Leitores(true); b.ShowDialog(); break;
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
                Mysql.Delete("requisita", "id_requ = " + _id);

                MessageBox.Show("Registo Eliminado");
                this.Close();
            }
        }
    }
}
