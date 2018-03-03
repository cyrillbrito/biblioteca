using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CbClass
{
    public partial class Search : UserControl
    {
        [Description("Text that will appear"), Category("Cb")]
        public string CbText
        {
            get => checkBox.Text;
            set => checkBox.Text = value;
        }

        [Description("Name of the table in the DataBase"), Category("Cb")]
        public string CbTableName { get; set; }

        [Description("Name of the column in the DataBase"), Category("Cb")]
        public string CbColumnName { get; set; }

        [Description("Name of the primary key column in the DataBase"), Category("Cb")]
        public string CbIdColumn { get; set; }

        [Description("Is the checkBox Checked"), Category("Cb")]
        public bool CbIsChecked
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

        [Description("Name of the form to serach"), Category("Cb")]
        public string CbFormName { get; set; }

        [Description("Value in the textBoxId"), Category("Cb")]
        public string CbValue
        {
            get => textBoxId.Text;
            set => textBoxId.Text = value;
        }

        [Description("Is button visible"), Category("Cb")]
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

        [Description("CheckBox is always on"), Category("Cb")]
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
                textBoxId.ForeColor = Color.Black;
            }
        }

        private void textBoxColumn_Click(object sender, EventArgs e)
        {
            if (!CbReadOnly && textBoxColumn.Text == CbColumnName)
            {
                textBoxColumn.Clear();
                textBoxColumn.ForeColor = Color.Black;
            }
        }

        private void textBoxId_Leave(object sender, EventArgs e)
        {
            if (!CbReadOnly)
            {
                if (string.IsNullOrWhiteSpace(CbValue))
                {
                    ConditionChanged?.Invoke(this, e);
                    textBoxId.ForeColor = Color.Gray;
                    CbValue = "ID";
                    if (textBoxColumn.Text != CbColumnName)
                    {
                        textBoxColumn.Text = CbColumnName;
                        textBoxColumn.ForeColor = Color.Gray;
                    }
                }
                else if (UpdateColumn())
                    ConditionChanged?.Invoke(this, e);
            }
        }

        private void textBoxColumn_Leave(object sender, EventArgs e)
        {
            if (!CbReadOnly)
            {
                if (string.IsNullOrWhiteSpace(textBoxColumn.Text))
                {
                    textBoxColumn.Text = CbColumnName;
                    textBoxColumn.ForeColor = Color.Gray;
                    textBoxId.Clear();
                    ConditionChanged?.Invoke(this, e);
                    CbValue = "ID";
                    textBoxId.ForeColor = Color.Gray;
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

                        textBoxId.ForeColor = Color.Black;

                        ConditionChanged?.Invoke(this, e);
                    }
                    else
                    {
                        MessageBox.Show(int.Parse(count) > 1 ? "Pouco específico" : "Sem resultados");

                        textBoxColumn.Select();
                        textBoxColumn.Clear();
                        textBoxId.Clear();
                        textBoxId.ForeColor = Color.Gray;
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
                CbIsChecked = checkBox.Checked;//para mudar a propriadade


            if (!CbIsChecked)
            {
                textBoxId.Clear();
                ConditionChanged?.Invoke(this, e);
                CbValue = "ID";
                textBoxColumn.Text = CbColumnName;
                textBoxColumn.ForeColor = Color.Gray;
                textBoxId.ForeColor = Color.Gray;
            }

            CheckBoxCheckedChanged?.Invoke(this, e);
        }

        private void button_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this, e);
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
                    textBoxColumn.ForeColor = Color.Black;
                    return true;
                }

                MessageBox.Show("Sem resultados");
                textBoxId.Select();
                textBoxId.Clear();
                textBoxColumn.Text = CbColumnName;
                textBoxColumn.ForeColor = Color.Gray;
                return false;
            }
        }

        public void Reload()
        {
            if (CbValue != "ID")
            {
                UpdateColumn();
                textBoxId.ForeColor = Color.Black;
                ConditionChanged?.Invoke(this, new EventArgs());
            }
            else
                textBoxColumn.Text = CbColumnName;
        }
    }
}
