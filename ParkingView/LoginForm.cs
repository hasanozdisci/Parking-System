using Newtonsoft.Json;
using ParkingApp_Core.Models;
using ParkingWebApi.Application.UserOperations.Commands.LoginUser;
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
                    var user = JsonConvert.DeserializeObject<LoginUserViewModel>(userJson);
                    var getPointBody = new
                    {
                        Id = user.Id
                    };
                    var getPoint = ApiCall.RequestJSON($"{connectionString}/Scores", getPointBody, "GetUserPoint", Method.Get);
                    if (getPoint.Success)
                    {
                        //string pointJson = JsonConvert.SerializeObject(getPoint.Result);
                        //var point = JsonConvert.DeserializeObject<Score>(pointJson);
                        //user.Score.Point = Convert.ToInt32(getPoint.Result);
                        this.Hide();
                        MainForm mainForm = new(user);
                        mainForm.Show();
                    }
                    else
                    {
                        lblError.ForeColor = Color.Red;
                        lblError.Text = getPoint.Message + "!";
                    }

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