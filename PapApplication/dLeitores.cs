using CbClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PapApplication
{
    public partial class DLeitores : Form
    {
        private int _id;
        private bool _edit;

        public DLeitores(int id = 0, bool edit = false)
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

        private void EditMode()
        {
            _edit = true;
            searchNome.CbReadOnly = false;
            searchEmail.CbReadOnly = false;
            searchMorada.CbReadOnly = false;
            searchTelemovel.CbReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonImagem.Visible = true;
            buttonEliminar.Visible = true;
        }

        private void ViewMode()
        {
            using (var query = new Mysql("*", "leitores", "id_leit = " + _id))
            {
                query.Read();

                searchId.CbValue = query.Read("id_leit");
                searchNome.CbValue = query.Read("nome");
                searchEmail.CbValue = query.Read("email");
                searchMorada.CbValue = query.Read("morada");
                searchTelemovel.CbValue = query.Read("telemovel");
            }

            _edit = false;
            searchNome.CbReadOnly = true;
            searchEmail.CbReadOnly = true;
            searchMorada.CbReadOnly = true;
            searchTelemovel.CbReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonImagem.Visible = false;
            buttonEliminar.Visible = false;

            if (File.Exists(Application.StartupPath + @"\leitores\" + _id))
                pictureBox1.ImageLocation = Application.StartupPath + @"\leitores\" + _id;
        }

        private void AddMode()
        {
            _edit = false;

            using (var query = new Mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'leitores'"))
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
                        str = "Nome = '" + searchNome.CbValue + "', email = '" + searchEmail.CbValue + "', morada = '" + searchMorada.CbValue + "', telemovel = '" + searchTelemovel.CbValue + "'";
                        Mysql.Update("leitores", str, "id_leit = " + _id);
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchNome.CbValue + "', '" + searchEmail.CbValue + "', '" + searchMorada.CbValue + "', '" + searchTelemovel.CbValue + "'";
                        Mysql.Insert("leitores", "Nome, email, morada, telemovel", str);
                        MessageBox.Show("Os dados foram inseridos");
                    }
                    if (File.Exists(Application.StartupPath + @"\leitores\temp"))
                    {
                        File.Copy(Application.StartupPath + @"\leitores\temp", Application.StartupPath + @"\leitores\" + _id, true);
                        File.Delete(Application.StartupPath + @"\leitores\temp");
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
            {
                if (File.Exists(Application.StartupPath + @"\leitores\temp"))
                    File.Delete(Application.StartupPath + @"\leitores\temp");
                Close();
            }
        }

        private List<string> CheckData()
        {
            var list = new List<string>();

            if (string.IsNullOrWhiteSpace(searchNome.CbValue))
                list.Add("Nome");
            if (searchEmail.CbValue.IndexOf('@') == -1)
                list.Add("Email");
            if (string.IsNullOrWhiteSpace(searchMorada.CbValue))
                list.Add("Morada");
            if (!int.TryParse(searchTelemovel.CbValue, out var num) || num < 100000000)
                list.Add("Telemóvel");

            return list;
        }

        private void ButtonEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Mysql.Delete("leitores", "id_leit = " + _id);

                MessageBox.Show("Registo Eliminado");
                Close();
            }
        }

        private void ButtonImagem_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Escolher a Imagem",
                Filter = "JPEG|*.jpg|PNG|*.png",
                InitialDirectory = @"C:\"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(fileDialog.FileName, Application.StartupPath + @"\leitores\temp", true);
                if (File.Exists(Application.StartupPath + @"\leitores\temp"))
                    pictureBox1.ImageLocation = Application.StartupPath + @"\leitores\temp";
            }
        }

        private void DLeitores_Load(object sender, EventArgs e)
        {
            Methods.LoadFormPosition(this);
        }
    }
}
