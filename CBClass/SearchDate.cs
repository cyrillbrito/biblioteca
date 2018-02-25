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
    public partial class SearchDate : UserControl
    {
        int _numberDays;
        
        [Description("Text in the label"), Category("CB")]
        public string CbText
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        [Description("Value i the datetimepicker"), Category("CB")]
        public string CbValue
        {
            get { return dateTimePicker.Value.ToString("yyyy-MM-dd"); }
            set { dateTimePicker.Value = Convert.ToDateTime(value); }
        }

        [Description("Read Only"), Category("CB")]
        public bool CbReadOnly
        {
            get { return !dateTimePicker.Enabled; }
            set { dateTimePicker.Enabled = !value; }
        }

        [Description("Number od days added to the max date"), Category("CB")]
        public int CbNumberDays
        {
            get { return _numberDays; }
            set { _numberDays = value; }
        }
        
        public SearchDate()
        {
            InitializeComponent();
        }

        private void SearchDate_Load(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = "dd - MMM - yyyy";
            dateTimePicker.MaxDate = (DateTime.Today).AddDays(_numberDays);
            dateTimePicker.MaxDate = DateTime.Today.AddDays(_numberDays);
        }
    }
}
