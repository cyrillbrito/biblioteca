using CbClass;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PapApplication
{
    public partial class DAutores : Form
    {
        private int _id;
        private bool _edit;

        public DAutores(int id = 0, bool edit = false)
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

        private void dAutores_Load(object sender, EventArgs e)
        {
            Methods.LoadFormPosition(this);
        }

        private void EditMode()
        {
            _edit = true;
            searchNome.CbReadOnly = false;
            searchNacionalidade.CbReadOnly = false;
            searchDataNascimento.CbReadOnly = false;
            searchDataFalecimento.CbReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            checkBox.Visible = !searchDataFalecimento.Visible;
            checkBox.Checked = searchDataFalecimento.Visible;
            buttonEliminar.Visible = true;
        }

        private void ViewMode()
        {
            using (var query = new Mysql("*", "autores", "id_auto = " + _id))
            {
                query.Read();

                searchId.CbValue = query.Read("id_auto");
                searchNome.CbValue = query.Read("nome");
                searchNacionalidade.CbValue = query.Read("nacionalidade");
                searchDataNascimento.CbValue = query.Read("data_nasc");

                if (string.IsNullOrWhiteSpace(query.Read("data_fale")))
                    searchDataFalecimento.Visible = false;
                else
                {
                    searchDataFalecimento.Visible = true;
                    searchDataFalecimento.CbValue = query.Read("data_fale");
                }
            }

            _edit = false;
            searchNome.CbReadOnly = true;
            searchNacionalidade.CbReadOnly = true;
            searchDataNascimento.CbReadOnly = true;
            searchDataFalecimento.CbReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            checkBox.Visible = false;
            buttonEliminar.Visible = false;
        }

        private void AddMode()
        {
            _edit = false;

            using (var query = new Mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'autores'"))
            {
                query.Read();
                searchId.CbValue = query.Read("a");
                _id = int.Parse(searchId.CbValue);
            }

            checkBox.Visible = true;
            buttonEliminar.Visible = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditMode();
        }

        private void buttonSave_Click(object sender, EventArgs e)
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
                        str = "nome = '" + searchNome.CbValue + "', Nacionalidade = '" + searchNacionalidade.CbValue + "', data_nasc = '" + searchDataNascimento.CbValue + "'";
                        if (checkBox.Checked)
                            str += ", data_fale = '" + searchDataFalecimento.CbValue + "'";
                        Mysql.Update("autores", str, "id_auto = " + _id);
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchNome.CbValue + "', '" + searchNacionalidade.CbValue + "', '" + searchDataNascimento.CbValue + "'";
                        var str2 = "nome, nacionalidade, data_nasc";
                        if (checkBox.Checked)
                        {
                            str += ", '" + searchDataNascimento.CbValue + "'";
                            str2 += ", data_fale";
                        }
                        Mysql.Insert("autores", str2, str);
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Tem a certeza que pretende cancelar?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Close();
        }

        private List<string> CheckData()
        {
            var list = new List<string>();

            if (string.IsNullOrWhiteSpace(searchNome.CbValue))
                list.Add("Nome");
            if (string.IsNullOrWhiteSpace(searchNacionalidade.CbValue))
                list.Add("Nacionalidade");
            if (checkBox.Checked && DateTime.Compare(Convert.ToDateTime(searchDataNascimento.CbValue), Convert.ToDateTime(searchDataFalecimento.CbValue)) >= 0)
                list.Add("Data nacimento ou de falecimento");

            return list;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            searchDataFalecimento.Visible = checkBox.Checked;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Mysql.Delete("autores", "id_auto = " + _id);

                MessageBox.Show("Registo Eliminado");
                Close();
            }
        }
    }
}
