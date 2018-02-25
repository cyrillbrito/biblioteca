using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CBClass.Controls
{
    public partial class Search : UserControl
    {
        [Description("Text that will appear"), Category("CB")]
        public string CbText
        {
            get => checkBox.Text;
            set => checkBox.Text = value;
        }

        [Description("Name of the table in the DataBase"), Category("CB")]
        public string CbTableName { get; set; }

        [Description("Name of the column in the DataBase"), Category("CB")]
        public string CbColumnName { get; set; }

        [Description("Name of the primary key column in the DataBase"), Category("CB")]
        public string CbIdColumn { get; set; }

        [Description("Is the checkBox Checked"), Category("CB")]
        public bool CBisChecked
        {
            get => checkBox.Checked;
            set
            {
                checkBox.Checked = value;
                textBoxId.Enabled = value;
                textBoxColumn.Enabled = value;
                button.Enabled = value;
            }
        }

        [Description("Name of the form to serach"), Category("CB")]
        public string CbFormName { get; set; }

        [Description("Value in the textBoxId"), Category("CB")]
        public string CbValue
        {
            get => textBoxId.Text;
            set => textBoxId.Text = value;
        }

        [Description("Is button visible"), Category("CB")]
        public bool CbReadOnly
        {
            get => textBoxId.ReadOnly;
            set
            {
                button.Visible = !value;
                textBoxId.ReadOnly = value;
                textBoxColumn.ReadOnly = value;
            }
        }

        [Description("CheckBox is always on"), Category("CB")]
        public bool CbCheckBoxLocked { get; set; }

        public event EventHandler ButtonClick;
        public event EventHandler CheckBoxCheckedChanged;
        public event EventHandler ConditionChanged;

        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void textBoxId_Click(object sender, EventArgs e)
        {
            if (!CbReadOnly && CbValue == "ID")
            {
                textBoxId.Clear();
                textBoxId.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxColumn_Click(object sender, EventArgs e)
        {
            if (!CbReadOnly && textBoxColumn.Text == CbColumnName)
            {
                textBoxColumn.Clear();
                textBoxColumn.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void textBoxId_Leave(object sender, EventArgs e)
        {
            if (!CbReadOnly)
            {
                if (CbValue == "")
                {
                    if (this.ConditionChanged != null)
                        this.ConditionChanged(this, e);
                    textBoxId.ForeColor = System.Drawing.Color.Gray;
                    CbValue = "ID";
                    if (textBoxColumn.Text != CbColumnName)
                    {
                        textBoxColumn.Text = CbColumnName;
                        textBoxColumn.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                else if (UpdateColumn() /*&& this.ConditionChanged != null*/)
                    this.ConditionChanged(this, e);
            }
        }

        private void textBoxColumn_Leave(object sender, EventArgs e)
        {
            if (!CbReadOnly)
            {
                if (textBoxColumn.Text == "")
                {
                    textBoxColumn.Text = CbColumnName;
                    textBoxColumn.ForeColor = System.Drawing.Color.Gray;
                    textBoxId.Clear();
                    if (this.ConditionChanged != null)
                        this.ConditionChanged(this, e);
                    CbValue = "ID";
                    textBoxId.ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    string count;
                    using (var query = new Mysql("COUNT(" + CbIdColumn + ") as a", CbTableName, CbColumnName + " LIKE '%" + textBoxColumn.Text + "%'"))
                    {
                        query.Read();
                        query.Read("a");
                        count = query.Read("a");
                    }

                    if (count == "1")
                    {
                        using (var query = new Mysql(CbIdColumn + ", " + CbColumnName, CbTableName, CbColumnName + " LIKE '%" + textBoxColumn.Text + "%'"))
                        {
                            query.Read();
                            CbValue = query.Read(CbIdColumn);
                            textBoxColumn.Text = query.Read(CbColumnName);
                        }

                        textBoxId.ForeColor = System.Drawing.Color.Black;

                        ConditionChanged?.Invoke(this, e);
                    }
                    else
                    {
                        // todo change converter
                        if (Convert.ToInt16(count) > 1)
                            MessageBox.Show("Pouco específico");
                        else
                            MessageBox.Show("Sem resultados");

                        textBoxColumn.Select();
                        textBoxColumn.Clear();
                        textBoxId.Clear();
                        textBoxId.ForeColor = System.Drawing.Color.Gray;
                        CbValue = "ID";
                    }
                }
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CbCheckBoxLocked)
                checkBox.Checked = true;//se estiver em locked nao deixa mudar
            else
                CBisChecked = checkBox.Checked;//para mudar a propriadade


            if (!CBisChecked)
            {
                textBoxId.Clear();
                if (this.ConditionChanged != null)
                    this.ConditionChanged(this, e);
                CbValue = "ID";
                textBoxColumn.Text = CbColumnName;
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

        private bool UpdateColumn()
        {
            using (var query = new Mysql(CbColumnName, CbTableName, CbIdColumn + " = " + CbValue))
            {
                if (query.Read())
                {
                    textBoxColumn.Text = query.Read(CbColumnName);
                    textBoxColumn.ForeColor = System.Drawing.Color.Black;
                    return true;
                }
                else
                {
                    MessageBox.Show("Sem resultados");
                    textBoxId.Select();
                    textBoxId.Clear();
                    textBoxColumn.Text = CbColumnName;
                    textBoxColumn.ForeColor = System.Drawing.Color.Gray;
                    return false;
                }
            }
        }

        public void Reload()
        {
            if (CbValue != "ID")
            {
                UpdateColumn();
                textBoxId.ForeColor = System.Drawing.Color.Black;
                if (this.ConditionChanged != null)
                    this.ConditionChanged(this, new EventArgs());
            }
            else
                textBoxColumn.Text = CbColumnName;
        }
    }
}
