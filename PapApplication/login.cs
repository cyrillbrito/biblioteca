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
            if (!string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                using (var query = new Mysql("password", "funcionarios", "id_func = " + textBoxId.Text))
                {
                    if (query.Read() && query.Read("password") == textBoxPassword.Text)
                    {
                        Variables.FuncId = int.Parse(textBoxId.Text);

                        MessageBox.Show("Bem-vindo!");
                        var obj = new Livros();
                        Hide();
                        obj.ShowDialog();
                        Close();
                        return;
                    }
                }
            }

            MessageBox.Show("Dados inseridos não estão corretos.");
        }
    }
}
