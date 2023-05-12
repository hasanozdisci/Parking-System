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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
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
                MessageBox.Show($"Hoþgeldin {user?.Email}");
            }
            else
            {
                MessageBox.Show("Giremedik");
            }
        }
    }
}