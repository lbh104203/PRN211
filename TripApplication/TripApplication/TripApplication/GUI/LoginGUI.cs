using TripApplication.GUI;
using TripApplication.Models;

namespace TripApplication
{
    public partial class LoginGUI : Form
    {
        private readonly TripContext context = new TripContext();
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void Login(string username, string password)
        {
            var user = context.Accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (user != null)
            {
                if (user.Role != null)
                {
                    MainGUI mainGUI = new MainGUI(user.Role, username);
                    mainGUI.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Username or Password is not correct !");
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(textUsername.Text, textPassword.Text);
        }

        private void LoginGUI_Load(object sender, EventArgs e)
        {
            textPassword.PasswordChar = '*';
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}