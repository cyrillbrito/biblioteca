using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBClass;

namespace PapeApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text != "")
            {
                Mysql query = new Mysql("password", "funcionarios", "id_func = " + textBoxId.Text);

                if (query.Read())
                    if (query.Read("password") == textBoxPassword.Text)
                    {
                        Variables.FuncId = Convert.ToInt16(textBoxId.Text);
                        query.Close();
                        MessageBox.Show("Bem-vindo!");
                        Livros obj = new Livros();
                        this.Hide();
                        obj.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        query.Close();
                        MessageBox.Show("Dados inseridos não estão corretos.");
                    }
                else
                {
                    query.Close();
                    MessageBox.Show("Dados inseridos não estão corretos.");
                }
            }
            else
            {
                MessageBox.Show("Dados inseridos não estão corretos.");
            }
        }
    }
}
