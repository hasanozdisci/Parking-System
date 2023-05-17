using ParkingApp_Core;
using ParkingApp_Core.Models;
using ParkingView.Properties;
using ParkingWebApi.Application.UserOperations.Commands.LoginUser;
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
    public partial class MainForm : Form
    {
        public string connectionString = "https://localhost:7062";
        public LoginUserViewModel user;

        public MainForm(LoginUserViewModel user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tsbPoint.Text = "Güncel Bakiye = " + user.Point.ToString();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new();
            login.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            // request get user point
            var getPointBody = new
            {
                Id = user.Id
            };
            var getPoint = ApiCall.RequestJSON($"{connectionString}/Scores", getPointBody, "GetUserPoint", Method.Get);
            if (getPoint.Success)
            {
                user.Point = Convert.ToInt32(getPoint.Result);
                tsbPoint.Text = "Güncel Bakiye = " + user.Point.ToString();
            }
            else
            {
                MessageBox.Show("Hata oluştu");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddPoint point = new(user);
            point.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new();
            login.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CarParkForm carParkForm = new(user);
            carParkForm.ShowDialog();
        }
    }
}
