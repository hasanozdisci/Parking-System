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
    public partial class AddPoint : Form
    {
        public string connectionString = "https://localhost:7062";
        public LoginUserViewModel _user;
        public AddPoint(LoginUserViewModel user)
        {
            InitializeComponent();
            _user = user;
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            var pointBody = new
            {
                Id = _user.Id,
                Point = Convert.ToInt32(mtbPoint.Text)
            };
            var point = ApiCall.RequestJSON($"{connectionString}/Scores", pointBody, "UpdateScore", Method.Put);
            if (point.Success)
            {
                MessageBox.Show("Bakiye başarı ile yüklendi");
                this.Hide();
            }
        }
    }
}
