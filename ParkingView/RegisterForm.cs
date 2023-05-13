using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingView
{
    public partial class RegisterForm : Form
    {
        public string connectionString = "https://localhost:7062";
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            // control if all fields are filled
            // if not, show error message
            // else, register user
            if (txtCarPlate.Text == "" || txtEmail.Text == "" || txtName.Text == "" || txtLastName.Text == "" || txtPassword.Text == "")
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Lütfen tüm alanları doldurunuz.";
                return;
            }
            else
            {
                lblError.ForeColor = Color.Green;
                lblError.Text = "Bilgileriniz kontrol ediliyor...";
                await Task.Delay(2000);
                var user = new
                {
                    FirstName = txtName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    CarPlate = txtCarPlate.Text
                };
                var register = ApiCall.RequestJSON($"{connectionString}/Users", user, "CreateUser", Method.Post);
                if (register.Success)
                {
                    MessageBox.Show("Kayıt başarılı!");
                    this.Hide();
                }
                if (register.Exception.Message != null)
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = register.Exception.InnerException.Split(',')[0];
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = register.Message + "!";
                }
            }
        }
    }
}
