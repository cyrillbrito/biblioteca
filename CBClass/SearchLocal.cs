using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CbClass
{
    public partial class SearchLocal : UserControl
    {
        [Description("Text that will appear"), Category("Cb")]
        public string CbText
        {
            get => label.Text;
            set => label.Text = value;
        }

        [Description("Name of the column in the DataBase"), Category("Cb")]
        public string CbColumnName { get; set; }

        [Description("Name of the form to serach"), Category("Cb")]
        public string CbValue
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        [Description("Name of the form to serach"), Category("Cb")]
        public bool CbReadOnly
        {
            get => textBox.ReadOnly;
            set => textBox.ReadOnly = value;
        }

        public SearchLocal()
        {
            InitializeComponent();
        }

        public new event EventHandler TextChanged;
        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }
    }
}
