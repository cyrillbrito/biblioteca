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
    public partial class dEditora : Form
    {
         int id;
        bool edit = false;

        public dEditora(int ID = 0, bool edit = false)
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

        private void dEditora_Load(object sender, EventArgs e)
        {
            Methods.loadFormPosition(this);
        }

        private void editMode()
        {
            edit = true;
            searchEditora.CBReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonEliminar.Visible = true;
        }

        private void viewMode()
        {
            mysql query = new mysql("*", "editoras", "id_edit = " + id);
            query.read();

            searchId.CBValue = query.read("id_edit").ToString();
            searchEditora.CBValue = query.read("editora").ToString();
            query.close();

            edit = false;
            searchEditora.CBReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonEliminar.Visible = false;
        }

        private void addMode()
        {
            edit = false;
            mysql query = new mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'editoras'");
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
                        str = "editora = '" + searchEditora.CBValue + "'";
                        mysql.update("editoras", str, "id_edit = " + id.ToString());
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchEditora.CBValue + "'";
                        mysql.insert("editoras", "editora", str);
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

            if (searchEditora.CBValue == "")
                list.Add("Categoria");

            return list;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                mysql.delete("editoras", "id_edit = " + id);

                MessageBox.Show("Registo Eliminado");
                this.Close();
            }
        }
    }
}
