using System.Windows.Forms;

namespace CBClass
{
    public class Methods
    {
        public static void LoadFormProperties(Form form, bool tool = false)
        {
            if (!tool)
            {
                form.Width = Variables.FormProperties[0];
                form.Height = Variables.FormProperties[1];
                form.Location = new System.Drawing.Point(Variables.FormProperties[2], Variables.FormProperties[3]);
            }
            else
            {
                form.Width = Variables.FormProperties[0] - 100;
                form.Height = Variables.FormProperties[1] - 100;
                form.Location = new System.Drawing.Point(Variables.FormProperties[2] + 100, Variables.FormProperties[3] + 100);
            }
        }

        public static void LoadFormPosition(Form form, bool tool = false)
        {
            form.Location = new System.Drawing.Point(Variables.FormProperties[2] + 100, Variables.FormProperties[3] + 100);
        }

        public static void SaveFormProperties()
        {
            Variables.FormProperties[0] = Form.ActiveForm.Width;
            Variables.FormProperties[1] = Form.ActiveForm.Height;
            Variables.FormProperties[2] = Form.ActiveForm.Location.X;
            Variables.FormProperties[3] = Form.ActiveForm.Location.Y;
        }

        public static void UpdateListView(ListView listView, string columns, string tables, string conditions)
        {
            using (var query = new Mysql(columns, tables, conditions))
                query.ListView(listView);

            for (int i = 0; i < listView.Columns.Count; i++)
                listView.Columns[i].Width = -2;
        }
    }
}
