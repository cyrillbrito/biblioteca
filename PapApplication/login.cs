using CBClass;
using System;
using System.Windows.Forms;

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
                using (var query = new Mysql("password", "funcionarios", "id_func = " + textBoxId.Text))
                {
                    if (query.Read() && query.Read("password") == textBoxPassword.Text)
                    {
                        Variables.FuncId = int.Parse(textBoxId.Text);

                        MessageBox.Show("Bem-vindo!");
                        var obj = new Livros();
                        this.Hide();
                        obj.ShowDialog();
                        this.Close();
                        return;
                    }
                }
            }

            MessageBox.Show("Dados inseridos não estão corretos.");
        }
    }
}
