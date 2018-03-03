using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CbClass
{
    public partial class SearchDate : UserControl
    {
        [Description("Text in the label"), Category("Cb")]
        public string CbText
        {
            get => label.Text;
            set => label.Text = value;
        }

        [Description("Value i the datetimepicker"), Category("Cb")]
        public string CbValue
        {
            get => dateTimePicker.Value.ToString("yyyy-MM-dd");
            set => dateTimePicker.Value = Convert.ToDateTime(value);
        }

        [Description("Read Only"), Category("Cb")]
        public bool CbReadOnly
        {
            get => !dateTimePicker.Enabled;
            set => dateTimePicker.Enabled = !value;
        }

        [Description("Number od days added to the max date"), Category("Cb")]
        public int CbNumberDays { get; set; }

        public SearchDate()
        {
            InitializeComponent();
        }

        private void SearchDate_Load(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = "dd - MMM - yyyy";
            dateTimePicker.MaxDate = (DateTime.Today).AddDays(CbNumberDays);
            dateTimePicker.MaxDate = DateTime.Today.AddDays(CbNumberDays);
        }
    }
}
