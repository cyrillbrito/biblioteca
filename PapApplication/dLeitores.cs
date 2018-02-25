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
using System.IO;

namespace PapeApplication
{
    public partial class dLeitores : Form
    {
        int id;
        bool edit = false;

        public dLeitores(int ID = 0, bool edit = false)
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

        private void editMode()
        {
            edit = true;
            searchNome.CBReadOnly = false;
            searchEmail.CBReadOnly = false;
            searchMorada.CBReadOnly = false;
            searchTelemovel.CBReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonImagem.Visible = true;
            buttonEliminar.Visible = true;
        }

        private void viewMode()
        {
            mysql query = new mysql("*", "leitores", "id_leit = " + id);
            query.read();

            searchId.CBValue = query.read("id_leit").ToString();
            searchNome.CBValue = query.read("nome").ToString();
            searchEmail.CBValue = query.read("email").ToString();
            searchMorada.CBValue = query.read("morada").ToString();
            searchTelemovel.CBValue = query.read("telemovel").ToString();
            query.close();

            edit = false;
            searchNome.CBReadOnly = true;
            searchEmail.CBReadOnly = true;
            searchMorada.CBReadOnly = true;
            searchTelemovel.CBReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonImagem.Visible = false;
            buttonEliminar.Visible = false;

            if (File.Exists(Application.StartupPath + @"\leitores\" + id))
                pictureBox1.ImageLocation = Application.StartupPath + @"\leitores\" + id;
        }

        private void addMode()
        {
            edit = false;
            mysql query = new mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'leitores'");
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
                        str = "Nome = '" + searchNome.CBValue + "', email = '" + searchEmail.CBValue + "', morada = '" + searchMorada.CBValue + "', telemovel = '" + searchTelemovel.CBValue + "'";
                        mysql.update("leitores", str, "id_leit = " + id.ToString());
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchNome.CBValue + "', '" + searchEmail.CBValue + "', '" + searchMorada.CBValue + "', '" + searchTelemovel.CBValue + "'";
                        mysql.insert("leitores", "Nome, email, morada, telemovel", str);
                        MessageBox.Show("Os dados foram inseridos");
                    }
                    if (File.Exists(Application.StartupPath + @"\leitores\temp"))
                    {
                        File.Copy(Application.StartupPath + @"\leitores\temp", Application.StartupPath + @"\leitores\" + id, true);
                        File.Delete(Application.StartupPath + @"\leitores\temp");
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
            {
                if (File.Exists(Application.StartupPath + @"\leitores\temp"))
                    File.Delete(Application.StartupPath + @"\leitores\temp");
                this.Close();
            }
        }

        private List<string> checkData()
        {
            int num;
            List<string> list = new List<string>();

            if (searchNome.CBValue == "")
                list.Add("Nome");
            if (searchEmail.CBValue.IndexOf('@') == -1)
                list.Add("Email");
            if (searchMorada.CBValue == "")
                list.Add("Morada");
            if (!int.TryParse(searchTelemovel.CBValue, out num) || num < 100000000)
                list.Add("Telemóvel");

            return list;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                mysql.delete("leitores", "id_leit = " + id);

                MessageBox.Show("Registo Eliminado");
                this.Close();
            }
        }

        private void buttonImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Escolher a Imagem";
            fileDialog.Filter = "JPEG|*.jpg|PNG|*.png";
            fileDialog.InitialDirectory = @"C:\";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(fileDialog.FileName.ToString(), Application.StartupPath + @"\leitores\temp", true);
                if (File.Exists(Application.StartupPath + @"\leitores\temp"))
                    pictureBox1.ImageLocation = Application.StartupPath + @"\leitores\temp";
            }
        }

        private void dLeitores_Load(object sender, EventArgs e)
        {
            Methods.loadFormPosition(this);
        }
    }
}
