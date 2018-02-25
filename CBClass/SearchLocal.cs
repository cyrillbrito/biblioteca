using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBClass
{
    public partial class SearchLocal : UserControl
    {
        string _columnName;
        
        [Description("Text that will appear"), Category("CB")]
        public string CbText
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        [Description("Name of the column in the DataBase"), Category("CB")]
        public string CbColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        [Description("Name of the form to serach"), Category("CB")]
        public string CbValue
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        [Description("Name of the form to serach"), Category("CB")]
        public bool CbReadOnly
        {
            get { return textBox.ReadOnly; }
            set { textBox.ReadOnly = value; }
        }

        public SearchLocal()
        {
            InitializeComponent();
        }

        public event EventHandler TextChanged;
        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.TextChanged != null)
                this.TextChanged(this, e);   
        }
    }
}
