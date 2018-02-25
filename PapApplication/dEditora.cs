using CBClass;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PapeApplication
{
    public partial class DEditora : Form
    {
        int _id;
        bool _edit = false;

        public DEditora(int id = 0, bool edit = false)
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

        private void dEditora_Load(object sender, EventArgs e)
        {
            Methods.LoadFormPosition(this);
        }

        private void EditMode()
        {
            _edit = true;
            searchEditora.CbReadOnly = false;
            buttonCancel.Visible = true;
            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonEliminar.Visible = true;
        }

        private void ViewMode()
        {
            using (var query = new Mysql("*", "editoras", "id_edit = " + _id))
            {
                query.Read();

                searchId.CbValue = query.Read("id_edit").ToString();
                searchEditora.CbValue = query.Read("editora").ToString();
            }

            _edit = false;
            searchEditora.CbReadOnly = true;
            buttonCancel.Visible = false;
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonEliminar.Visible = false;
        }

        private void AddMode()
        {
            _edit = false;

            using (var query = new Mysql("`AUTO_INCREMENT` as a", "INFORMATION_SCHEMA.TABLES", "TABLE_SCHEMA = 'biblioteca' AND TABLE_NAME = 'editoras'"))
            {
                query.Read();
                searchId.CbValue = query.Read("a").ToString();
                _id = int.Parse(searchId.CbValue);
                buttonEliminar.Visible = false;
            }
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
                        str = "editora = '" + searchEditora.CbValue + "'";
                        Mysql.Update("editoras", str, "id_edit = " + _id.ToString());
                        MessageBox.Show("Os dados foram alterados.");
                    }
                    else
                    {
                        str = "'" + searchEditora.CbValue + "'";
                        Mysql.Insert("editoras", "editora", str);
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

            if (searchEditora.CbValue == "")
                list.Add("Categoria");

            return list;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Tem a certeza que pretende apagar o registo?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Mysql.Delete("editoras", "id_edit = " + _id);

                MessageBox.Show("Registo Eliminado");
                this.Close();
            }
        }
    }
}
