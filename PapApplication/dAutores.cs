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
    public partial class dAutores : Form
    {
         int id;
        bool edit = false;

        public dAutores(int ID = 0, bool edit = false)
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

        private void dAutores_Load(object sender, EventArgs e)
        {
            Methods.loadFormPosition(this);
        }
        
        private void editMode()
        {
            edit = true;
            searchNome.CBReadOnly = false;
            searchNacionalidade.CBReadOnly = false;
            searchDataNascimento.CBReadOnly = false;
            searchDataFalecimento.CBReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            checkBox.Visible = !searchDataFalecimento.Visible;
            checkBox.Checked = searchDataFalecimento.Visible;
            buttonEliminar.Visible = true;
        }

        private void viewMode()
        {
            mysql query = new mysql("*", "autores", "id_auto = " + id);
            query.read();

            searchId.CBValue = query.read("id_auto").ToString();
            searchNome.CBValue = query.read("nome").ToString();
            searchNacionalidade.CBValue = query.read("nacionalidade").ToString();
            searchDataNascimento.CBValue = query.read("data_nasc").ToString();
            if (query.read("data_fale").ToString() == "")
                searchDataFalecimento.Visible = false;
            else
            {
                searchDataFalecimento.Visible = true;
                searchDataFalecimento.CBValue = query.read("data_fale").ToString();
            }

            query.close();

            edit = false;
            searchNome.CBReadOnly = true;
            searchNacionalidade.CBReadOnly = true;
            searchDataNascimento.CBReadOnly = true;
            searchDataFalecimento.CBReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            checkBox.Visible = false;
            buttonEliminar.Visible = false;
        }

        private void addMode()
        {
            edit = false;
            mysql query = new mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'autores'");
            query.read();
            searchId.CBValue = query.read("a").ToString();
            id = Convert.ToInt16(searchId.CBValue);
            query.close();
            checkBox.Visible = true;
            buttonEliminar.Visible = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            editMode();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<string> list = checkData();
            string str, str2;
            if (list.Count == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende guadar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (edit)
                    {
                        str = "nome = '" + searchNome.CBValue + "', Nacionalidade = '" + searchNacionalidade.CBValue + "', data_nasc = '" + searchDataNascimento.CBValue + "'";
                        if(checkBox.Checked)
                            str += ", data_fale = '" + searchDataFalecimento.CBValue + "'";
                        mysql.update("autores", str, "id_auto = " + id.ToString());
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchNome.CBValue + "', '" + searchNacionalidade.CBValue + "', '" + searchDataNascimento.CBValue + "'";
                        str2 = "nome, nacionalidade, data_nasc";
                        if (checkBox.Checked)
                        {
                            str += ", '" + searchDataNascimento.CBValue + "'";
                            str2 += ", data_fale";
                        }
                        mysql.insert("autores", str2, str);
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

            if (searchNome.CBValue == "")
                list.Add("Nome");
            if (searchNacionalidade.CBValue == "")
                list.Add("Nacionalidade");
            if (checkBox.Checked && DateTime.Compare(Convert.ToDateTime(searchDataNascimento.CBValue), Convert.ToDateTime(searchDataFalecimento.CBValue)) >= 0)
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
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                mysql.delete("autores", "id_auto = " + id);

                MessageBox.Show("Registo Eliminado");
                this.Close();
            }
        }
    }
}
