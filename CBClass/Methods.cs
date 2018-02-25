using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBClass;

namespace CBClass
{
    public class Methods
    {
        public static void loadFormProperties(Form form, bool tool = false)
        {
            if (!tool)
            {
                form.Width = Variables.formProperties[0];
                form.Height = Variables.formProperties[1];
                form.Location = new System.Drawing.Point(Variables.formProperties[2], Variables.formProperties[3]);
            }
            else
            {
                form.Width = Variables.formProperties[0] - 100;
                form.Height = Variables.formProperties[1] - 100;
                form.Location = new System.Drawing.Point(Variables.formProperties[2] + 100, Variables.formProperties[3] + 100);
            }
        }

        public static void loadFormPosition(Form form, bool tool = false)
        {
            form.Location = new System.Drawing.Point(Variables.formProperties[2] + 100, Variables.formProperties[3] + 100);
        }

        public static void saveFormProperties()
        {
            Variables.formProperties[0] = Form.ActiveForm.Width;
            Variables.formProperties[1] = Form.ActiveForm.Height;
            Variables.formProperties[2] = Form.ActiveForm.Location.X;
            Variables.formProperties[3] = Form.ActiveForm.Location.Y;
        }

        public static void updateListView(ListView listView, string columns, string tables, string conditions)
        {
            int i;
            mysql query = new mysql(columns, tables, conditions);
            query.listView(listView);
            for (i = 0; i < listView.Columns.Count; i++)
                listView.Columns[i].Width = -2;
            query.close();
        }        
    }
}
