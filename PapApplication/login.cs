using System;
using System.Windows.Forms;
using CbClass;

namespace PapApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxId.Text, out int id))
            {
                bool success;
                using (var query = new Mysql("password", "funcionarios", "id_func = " + textBoxId.Text))
                    success = query.Read() && query.Read("password") == textBoxPassword.Text;

                if (success)
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

            MessageBox.Show("Dados inseridos não estão corretos.");
        }
    }
}
