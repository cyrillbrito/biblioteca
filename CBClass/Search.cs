using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBClass.Controls
{
    public partial class Search : UserControl
    {
        string columnName, tableName, idColumn, formName;
        bool checkBoxLocked;

        [Description("Text that will appear"), Category("CB")]
        public string CBText
        {
            get { return checkBox.Text; }
            set { checkBox.Text = value; }
        }

        [Description("Name of the table in the DataBase"), Category("CB")]
        public string CBTableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        [Description("Name of the column in the DataBase"), Category("CB")]
        public string CBColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        [Description("Name of the primary key column in the DataBase"), Category("CB")]
        public string CBIdColumn
        {
            get { return idColumn; }
            set { idColumn = value; }
        }

        [Description("Is the checkBox Checked"), Category("CB")]
        public bool CBisChecked
        {
            get { return checkBox.Checked; }
            set
            {
                checkBox.Checked = value;
                textBoxId.Enabled = value;
                textBoxColumn.Enabled = value;
                button.Enabled = value;
            }
        }

        [Description("Name of the form to serach"), Category("CB")]
        public string CBFormName
        {
            get { return formName; }
            set { formName = value; }
        }

        [Description("Value in the textBoxId"), Category("CB")]
        public string CBValue
        {
            get { return textBoxId.Text; }
            set { textBoxId.Text = value; }
        }

        [Description("Is button visible"), Category("CB")]
        public bool CBReadOnly
        {
            get { return textBoxId.ReadOnly; }
            set
            {
                button.Visible = !value;
                textBoxId.ReadOnly = value;
                textBoxColumn.ReadOnly = value;
            }
        }

        [Description("CheckBox is always on"), Category("CB")]
        public bool CBCheckBoxLocked
        {
            get { return checkBoxLocked; }
            set { checkBoxLocked = value; }
        }

        public event EventHandler ButtonClick;
        public event EventHandler CheckBoxCheckedChanged;
        public event EventHandler ConditionChanged;

        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void textBoxId_Click(object sender, EventArgs e)
        {
            if (!CBReadOnly && CBValue == "ID")
            {
                textBoxId.Clear();
                textBoxId.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxColumn_Click(object sender, EventArgs e)
        {
            if (!CBReadOnly && textBoxColumn.Text == CBColumnName)
            {
                textBoxColumn.Clear();
                textBoxColumn.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxId_Leave(object sender, EventArgs e)
        {
            if (!CBReadOnly)
            {
                if (CBValue == "")
                {
                    if (this.ConditionChanged != null)
                        this.ConditionChanged(this, e);
                    textBoxId.ForeColor = System.Drawing.Color.Gray;
                    CBValue = "ID";
                    if (textBoxColumn.Text != columnName)
                    {
                        textBoxColumn.Text = CBColumnName;
                        textBoxColumn.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                else if (updateColumn() /*&& this.ConditionChanged != null*/)
                    this.ConditionChanged(this, e);
            }
        }

        private void textBoxColumn_Leave(object sender, EventArgs e)
        {
            if (!CBReadOnly)
            {
                if (textBoxColumn.Text == "")
                {
                    textBoxColumn.Text = CBColumnName;
                    textBoxColumn.ForeColor = System.Drawing.Color.Gray;
                    textBoxId.Clear();
                    if (this.ConditionChanged != null)
                        this.ConditionChanged(this, e);
                    CBValue = "ID";
                    textBoxId.ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    mysql query = new mysql("COUNT(" + CBIdColumn + ") as a", CBTableName, CBColumnName + " LIKE '%" + textBoxColumn.Text + "%'");
                    query.read();
                    if (query.read("a") == "1")
                    {
                        query.close();
                        query = new mysql(CBIdColumn + ", " + CBColumnName, CBTableName, CBColumnName + " LIKE '%" + textBoxColumn.Text + "%'");
                        query.read();
                        CBValue = query.read(CBIdColumn);
                        textBoxColumn.Text = query.read(CBColumnName);
                        query.close();
                        textBoxId.ForeColor = System.Drawing.Color.Black;
                        if (this.ConditionChanged != null)
                            this.ConditionChanged(this, e);
                    }
                    else
                    {
                        if (Convert.ToInt16(query.read("a")) > 1)
                            MessageBox.Show("Pouco específico");
                        else
                            MessageBox.Show("Sem resultados");

                        query.close();
                        textBoxColumn.Select();
                        textBoxColumn.Clear();
                        textBoxId.Clear();
                        textBoxId.ForeColor = System.Drawing.Color.Gray;
                        CBValue = "ID";
                    }
                }
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CBCheckBoxLocked)
                checkBox.Checked = true;//se estiver em locked nao deixa mudar
            else
                CBisChecked = checkBox.Checked;//para mudar a propriadade


            if (!CBisChecked)
            {
                textBoxId.Clear();
                if (this.ConditionChanged != null)
                    this.ConditionChanged(this, e);
                CBValue = "ID";
                textBoxColumn.Text = columnName;
                textBoxColumn.ForeColor = System.Drawing.Color.Gray;
                textBoxId.ForeColor = System.Drawing.Color.Gray;
            }

            if (this.CheckBoxCheckedChanged != null)
                this.CheckBoxCheckedChanged(this, e);
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                checkBox.Focus();
        }

        private bool updateColumn()
        {
            mysql query = new mysql(CBColumnName, CBTableName, CBIdColumn + " = " + CBValue);
            if (query.read())
            {
                textBoxColumn.Text = query.read(CBColumnName);
                query.close();
                textBoxColumn.ForeColor = System.Drawing.Color.Black;
                return true;
            }
            else
            {
                query.close();
                MessageBox.Show("Sem resultados");
                textBoxId.Select();
                textBoxId.Clear();
                textBoxColumn.Text = CBColumnName;
                textBoxColumn.ForeColor = System.Drawing.Color.Gray;
                return false;
            }
        }

        public void reload()
        {
            if (CBValue != "ID")
            {
                updateColumn();
                textBoxId.ForeColor = System.Drawing.Color.Black;
                if (this.ConditionChanged != null)
                    this.ConditionChanged(this, new EventArgs());
            }
            else
                textBoxColumn.Text = columnName;
        }
    }
}
