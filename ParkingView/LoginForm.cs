using Newtonsoft.Json;
using ParkingApp_Core.Models;
using RestSharp;

namespace ParkingView
{
    public partial class LoginForm : Form
    {
        public string connectionString = "https://localhost:7062";
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            lblError.Text = "";
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Lütfen tüm alanlarý doldurunuz.";
                return;
            }
            else
            {
                lblError.ForeColor = Color.Green;
                lblError.Text = "Bilgileriniz kontrol ediliyor...";
                await Task.Delay(2000);
                var loginBody = new
                {
                    Email = username,
                    Password = password,
                };
                var login = ApiCall.RequestJSON($"{connectionString}/Users", loginBody, "Login", Method.Post);
                if (login.Success)
                {
                    string userJson = JsonConvert.SerializeObject(login.Result);
                    var user = JsonConvert.DeserializeObject<User>(userJson);
                    MessageBox.Show($"Hoþgeldin {(user?.FirstName)} {user?.LastName}");
                    this.Hide();
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = login.Message + "!";
                }
            }


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new();
            registerForm.ShowDialog();
        }
    }
}