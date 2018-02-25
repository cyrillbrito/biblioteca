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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text != "")
            {
                mysql query = new mysql("password", "funcionarios", "id_func = " + textBoxId.Text);

                if (query.read())
                    if (query.read("password") == textBoxPassword.Text)
                    {
                        Variables.funcId = Convert.ToInt16(textBoxId.Text);
                        query.close();
                        MessageBox.Show("Bem-vindo!");
                        livros obj = new livros();
                        this.Hide();
                        obj.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        query.close();
                        MessageBox.Show("Dados inseridos não estão corretos.");
                    }
                else
                {
                    query.close();
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
