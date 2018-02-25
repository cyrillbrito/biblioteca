using CBClass;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PapeApplication
{
    public partial class DAutores : Form
    {
        int _id;
        bool _edit = false;

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

                searchId.CbValue = query.Read("id_auto").ToString();
                searchNome.CbValue = query.Read("nome").ToString();
                searchNacionalidade.CbValue = query.Read("nacionalidade").ToString();
                searchDataNascimento.CbValue = query.Read("data_nasc").ToString();
                // todo
                if (query.Read("data_fale").ToString() == "")
                    searchDataFalecimento.Visible = false;
                else
                {
                    searchDataFalecimento.Visible = true;
                    // todo remover esta tostring
                    searchDataFalecimento.CbValue = query.Read("data_fale").ToString();
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
                searchId.CbValue = query.Read("a").ToString();
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
            string str, str2;
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
                        Mysql.Update("autores", str, "id_auto = " + _id.ToString());
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchNome.CbValue + "', '" + searchNacionalidade.CbValue + "', '" + searchDataNascimento.CbValue + "'";
                        str2 = "nome, nacionalidade, data_nasc";
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
                this.Close();
        }

        private List<string> CheckData()
        {
            var list = new List<string>();

            if (searchNome.CbValue == "")
                list.Add("Nome");
            if (searchNacionalidade.CbValue == "")
                list.Add("Nacionalidade");
            if (checkBox.Checked && DateTime.Compare(Convert.ToDateTime(searchDataNascimento.CbValue), Convert.ToDateTime(searchDataFalecimento.CbValue)) >= 0)
                list.Add("Data nacimento ou de falecimento");

            return list;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
                searchDataFalecimento.Visible = true;
            else
                searchDataFalecimento.Visible = false;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Mysql.Delete("autores", "id_auto = " + _id);

                MessageBox.Show("Registo Eliminado");
                this.Close();
            }
        }
    }
}
