﻿using Newtonsoft.Json;
using ParkingWebApi.Application.UserOperations.Commands.LoginUser;
using ParkingWebApi.Application.UserOperations.Queries.GetParks;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ParkingView
{
    public partial class CarParkForm : Form
    {
        public string connectionString = "https://localhost:7062";
        public LoginUserViewModel user;
        public CarParkForm(LoginUserViewModel user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void CarParkForm_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Green;
            label2.BackColor = Color.Green;
            label3.BackColor = Color.Green;
            label4.BackColor = Color.Green;
            label5.BackColor = Color.Green;
            label6.BackColor = Color.Green;
            // request the getparks api
            var getParks = ApiCall.RequestJSON($"{connectionString}/Parks", null, "GetParks", Method.Get);
            if (getParks.Success)
            {
                var parks = JsonConvert.DeserializeObject<List<GetParksViewModel>>(getParks.Result.ToString());
                // i have 6 label match the parks and labels is park isBusy equals true, then get the user who bought the park and label text is user's car plate and label backcolor is red
                if (parks[0].IsBusy)
                {
                    label1.BackColor = Color.Red;
                    label1.Text += $"\n {parks[0].CarPlate}";
                    if (parks[0].UserId == user.Id)
                    {
                        label1.Enabled = true;
                        label1.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        label1.Enabled = false;

                    }
                }
                if (parks[1].IsBusy)
                {
                    label2.BackColor = Color.Red;
                    label2.Text += $"\n {parks[1].CarPlate}";
                    if (parks[1].UserId == user.Id)
                    {
                        label2.Enabled = true;
                        label2.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        label2.Enabled = false;

                    }
                }
                if (parks[2].IsBusy)
                {
                    label3.BackColor = Color.Red;
                    label3.Text += $"\n {parks[2].CarPlate}";
                    if (parks[2].UserId == user.Id)
                    {
                        label3.Enabled = true;
                        label3.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        label3.Enabled = false;

                    }
                }
                if (parks[3].IsBusy)
                {
                    label4.BackColor = Color.Red;
                    label4.Text += $"\n {parks[3].CarPlate}";
                    if (parks[3].UserId == user.Id)
                    {
                        label4.Enabled = true;
                        label4.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        label4.Enabled = false;

                    }
                }
                if (parks[4].IsBusy)
                {
                    label5.BackColor = Color.Red;
                    label5.Text += $"\n {parks[4].CarPlate}";
                    if (parks[4].UserId == user.Id)
                    {
                        label5.Enabled = true;
                        label5.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        label5.Enabled = false;

                    }
                }
                if (parks[5].IsBusy)
                {
                    label6.BackColor = Color.Red;
                    label6.Text += $"\n {parks[5].CarPlate}";

                    if (parks[5].UserId == user.Id)
                    {
                        label6.Enabled = true;
                        label6.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        label6.Enabled = false;
                    }
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // request api and update user information
            var loginBody = new
            {
                Email = user.Email,
                Password = user.Password,
            };
            var login = ApiCall.RequestJSON($"{connectionString}/Users", loginBody, "Login", Method.Post);
            if (login.Success)
            {
                user = JsonConvert.DeserializeObject<LoginUserViewModel>(login.Result.ToString());
            }
            var park1 = new
            {
                Id = 2
            };
            var park2 = new
            {
                Id = 2,
                UserId = user.Id
            };
            var park3 = new
            {
                Id = user.Id
            };
            var getPark = ApiCall.RequestJSON($"{connectionString}/Parks", park1, "GetParkById", Method.Get);

            if (getPark.Success)
            {
                var park = JsonConvert.DeserializeObject<GetParksViewModel>(getPark.Result.ToString());
                if (park.IsBusy)
                {
                    if (park.UserId == user.Id)
                    {
                        var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark.Success)
                        {
                            label2.BackColor = Color.Green;
                            label2.Enabled = true;
                            label2.Text = "Park 3";
                            label2.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            MessageBox.Show(updatePark.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu park alanı dolu");
                    }
                }
                else
                {
                    // Kullanıcı başka park alanına park etmiş mi?
                    var getParks = ApiCall.RequestJSON($"{connectionString}/Parks", null, "GetParks", Method.Get);
                    var parks = JsonConvert.DeserializeObject<List<GetParksViewModel>>(getParks.Result.ToString());
                    var userParks = parks.Where(x => x.UserId == user.Id).ToList();
                    if (userParks.Count > 0)
                    {
                        MessageBox.Show("Birden fazla park yapamazsınız");
                        return;
                    }
                    // Kullanıcının free ticketi var mı?
                    if (user.FreeTicket > 0)
                    {
                        var updatePark2 = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark2.Success)
                        {
                            // request UpdateScoreForParkingWithFreeTicket endpoint
                            var updateScoreWithFreeTicket = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParkingWithFreeTicket", Method.Put);
                            if (updateScoreWithFreeTicket.Success)
                            {
                                label2.BackColor = Color.Red;
                                label2.Cursor = Cursors.Default;
                                label2.Text += $"\n {user.CarPlate}";
                                return;
                            }
                            else
                            {
                                MessageBox.Show(updateScoreWithFreeTicket.Message);
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show(updatePark2.Message);
                            return;
                        }
                    }
                    // Kullanıcının bakiyesi yeterli mi?
                    if (user.Point < 5)
                    {
                        MessageBox.Show("Bakiyeniz yetersiz");
                        return;
                    }

                    var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                    if (updatePark.Success)
                    {
                        var updateScoreForParking = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParking", Method.Put);
                        if (updateScoreForParking.Success)
                        {
                            label2.BackColor = Color.Red;
                            label2.Cursor = Cursors.Default;
                            label2.Text += $"\n {user.CarPlate}";
                            return;
                        }
                        else
                        {
                            MessageBox.Show(updateScoreForParking.Message);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(updatePark.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show(getPark.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var loginBody = new
            {
                Email = user.Email,
                Password = user.Password,
            };
            var login = ApiCall.RequestJSON($"{connectionString}/Users", loginBody, "Login", Method.Post);
            if (login.Success)
            {
                user = JsonConvert.DeserializeObject<LoginUserViewModel>(login.Result.ToString());
            }
            var park1 = new
            {
                Id = 1
            };
            var park2 = new
            {
                Id = 1,
                UserId = user.Id
            };
            var park3 = new
            {
                Id = user.Id
            };
            var getPark = ApiCall.RequestJSON($"{connectionString}/Parks", park1, "GetParkById", Method.Get);

            if (getPark.Success)
            {
                var park = JsonConvert.DeserializeObject<GetParksViewModel>(getPark.Result.ToString());
                if (park.IsBusy)
                {
                    if (park.UserId == user.Id)
                    {
                        var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark.Success)
                        {
                            label1.BackColor = Color.Green;
                            label1.Enabled = true;
                            label1.Text = "Park 3";
                            label1.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            MessageBox.Show(updatePark.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu park alanı dolu");
                    }
                }
                else
                {
                    // Kullanıcı başka park alanına park etmiş mi?
                    var getParks = ApiCall.RequestJSON($"{connectionString}/Parks", null, "GetParks", Method.Get);
                    var parks = JsonConvert.DeserializeObject<List<GetParksViewModel>>(getParks.Result.ToString());
                    var userParks = parks.Where(x => x.UserId == user.Id).ToList();
                    if (userParks.Count > 0)
                    {
                        MessageBox.Show("Birden fazla park yapamazsınız");
                        return;
                    }
                    // Kullanıcının free ticketi var mı?
                    if (user.FreeTicket > 0)
                    {
                        var updatePark2 = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark2.Success)
                        {
                            // request UpdateScoreForParkingWithFreeTicket endpoint
                            var updateScoreWithFreeTicket = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParkingWithFreeTicket", Method.Put);
                            if (updateScoreWithFreeTicket.Success)
                            {
                                label1.BackColor = Color.Red;
                                label1.Cursor = Cursors.Default;
                                label1.Text += $"\n {user.CarPlate}";
                                return;
                            }
                            else
                            {
                                MessageBox.Show(updateScoreWithFreeTicket.Message);
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show(updatePark2.Message);
                            return;
                        }
                    }
                    // Kullanıcının bakiyesi yeterli mi?
                    if (user.Point < 5)
                    {
                        MessageBox.Show("Bakiyeniz yetersiz");
                        return;
                    }

                    var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                    if (updatePark.Success)
                    {
                        var updateScoreForParking = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParking", Method.Put);
                        if (updateScoreForParking.Success)
                        {
                            label1.BackColor = Color.Red;
                            label1.Cursor = Cursors.Default;
                            label1.Text += $"\n {user.CarPlate}";
                            return;
                        }
                        else
                        {
                            MessageBox.Show(updateScoreForParking.Message);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(updatePark.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show(getPark.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var loginBody = new
            {
                Email = user.Email,
                Password = user.Password,
            };
            var login = ApiCall.RequestJSON($"{connectionString}/Users", loginBody, "Login", Method.Post);
            if (login.Success)
            {
                user = JsonConvert.DeserializeObject<LoginUserViewModel>(login.Result.ToString());
            }
            var park1 = new
            {
                Id = 3
            };
            var park2 = new
            {
                Id = 3,
                UserId = user.Id
            };
            var park3 = new
            {
                Id = user.Id
            };
            var getPark = ApiCall.RequestJSON($"{connectionString}/Parks", park1, "GetParkById", Method.Get);

            if (getPark.Success)
            {
                var park = JsonConvert.DeserializeObject<GetParksViewModel>(getPark.Result.ToString());
                if (park.IsBusy)
                {
                    if (park.UserId == user.Id)
                    {
                        var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark.Success)
                        {
                            label3.BackColor = Color.Green;
                            label3.Enabled = true;
                            label3.Text = "Park 3";
                            label3.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            MessageBox.Show(updatePark.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu park alanı dolu");
                    }
                }
                else
                {
                    // Kullanıcı başka park alanına park etmiş mi?
                    var getParks = ApiCall.RequestJSON($"{connectionString}/Parks", null, "GetParks", Method.Get);
                    var parks = JsonConvert.DeserializeObject<List<GetParksViewModel>>(getParks.Result.ToString());
                    var userParks = parks.Where(x => x.UserId == user.Id).ToList();
                    if (userParks.Count > 0)
                    {
                        MessageBox.Show("Birden fazla park yapamazsınız");
                        return;
                    }
                    // Kullanıcının free ticketi var mı?
                    if (user.FreeTicket > 0)
                    {
                        var updatePark2 = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark2.Success)
                        {
                            // request UpdateScoreForParkingWithFreeTicket endpoint
                            var updateScoreWithFreeTicket = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParkingWithFreeTicket", Method.Put);
                            if (updateScoreWithFreeTicket.Success)
                            {
                                label3.BackColor = Color.Red;
                                label3.Cursor = Cursors.Default;
                                label3.Text += $"\n {user.CarPlate}";
                                return;
                            }
                            else
                            {
                                MessageBox.Show(updateScoreWithFreeTicket.Message);
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show(updatePark2.Message);
                            return;
                        }
                    }
                    // Kullanıcının bakiyesi yeterli mi?
                    if (user.Point < 5)
                    {
                        MessageBox.Show("Bakiyeniz yetersiz");
                        return;
                    }

                    var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                    if (updatePark.Success)
                    {
                        var updateScoreForParking = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParking", Method.Put);
                        if (updateScoreForParking.Success)
                        {
                            label3.BackColor = Color.Red;
                            label3.Cursor = Cursors.Default;
                            label3.Text += $"\n {user.CarPlate}";
                            return;
                        }
                        else
                        {
                            MessageBox.Show(updateScoreForParking.Message);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(updatePark.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show(getPark.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var loginBody = new
            {
                Email = user.Email,
                Password = user.Password,
            };
            var login = ApiCall.RequestJSON($"{connectionString}/Users", loginBody, "Login", Method.Post);
            if (login.Success)
            {
                user = JsonConvert.DeserializeObject<LoginUserViewModel>(login.Result.ToString());
            }
            var park1 = new
            {
                Id = 4
            };
            var park2 = new
            {
                Id = 4,
                UserId = user.Id
            };
            var park3 = new
            {
                Id = user.Id
            };
            var getPark = ApiCall.RequestJSON($"{connectionString}/Parks", park1, "GetParkById", Method.Get);

            if (getPark.Success)
            {
                var park = JsonConvert.DeserializeObject<GetParksViewModel>(getPark.Result.ToString());
                if (park.IsBusy)
                {
                    if (park.UserId == user.Id)
                    {
                        var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark.Success)
                        {
                            label4.BackColor = Color.Green;
                            label4.Enabled = true;
                            label4.Text = "Park 3";
                            label4.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            MessageBox.Show(updatePark.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu park alanı dolu");
                    }
                }
                else
                {
                    // Kullanıcı başka park alanına park etmiş mi?
                    var getParks = ApiCall.RequestJSON($"{connectionString}/Parks", null, "GetParks", Method.Get);
                    var parks = JsonConvert.DeserializeObject<List<GetParksViewModel>>(getParks.Result.ToString());
                    var userParks = parks.Where(x => x.UserId == user.Id).ToList();
                    if (userParks.Count > 0)
                    {
                        MessageBox.Show("Birden fazla park yapamazsınız");
                        return;
                    }
                    // Kullanıcının free ticketi var mı?
                    if (user.FreeTicket > 0)
                    {
                        var updatePark2 = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark2.Success)
                        {
                            // request UpdateScoreForParkingWithFreeTicket endpoint
                            var updateScoreWithFreeTicket = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParkingWithFreeTicket", Method.Put);
                            if (updateScoreWithFreeTicket.Success)
                            {
                                label4.BackColor = Color.Red;
                                label4.Cursor = Cursors.Default;
                                label4.Text += $"\n {user.CarPlate}";
                                return;
                            }
                            else
                            {
                                MessageBox.Show(updateScoreWithFreeTicket.Message);
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show(updatePark2.Message);
                            return;
                        }
                    }
                    // Kullanıcının bakiyesi yeterli mi?
                    if (user.Point < 5)
                    {
                        MessageBox.Show("Bakiyeniz yetersiz");
                        return;
                    }

                    var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                    if (updatePark.Success)
                    {
                        var updateScoreForParking = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParking", Method.Put);
                        if (updateScoreForParking.Success)
                        {
                            label4.BackColor = Color.Red;
                            label4.Cursor = Cursors.Default;
                            label4.Text += $"\n {user.CarPlate}";
                            return;
                        }
                        else
                        {
                            MessageBox.Show(updateScoreForParking.Message);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(updatePark.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show(getPark.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var loginBody = new
            {
                Email = user.Email,
                Password = user.Password,
            };
            var login = ApiCall.RequestJSON($"{connectionString}/Users", loginBody, "Login", Method.Post);
            if (login.Success)
            {
                user = JsonConvert.DeserializeObject<LoginUserViewModel>(login.Result.ToString());
            }
            var park1 = new
            {
                Id = 5
            };
            var park2 = new
            {
                Id = 5,
                UserId = user.Id
            };
            var park3 = new
            {
                Id = user.Id
            };
            var getPark = ApiCall.RequestJSON($"{connectionString}/Parks", park1, "GetParkById", Method.Get);

            if (getPark.Success)
            {
                var park = JsonConvert.DeserializeObject<GetParksViewModel>(getPark.Result.ToString());
                if (park.IsBusy)
                {
                    if (park.UserId == user.Id)
                    {
                        var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark.Success)
                        {
                            label5.BackColor = Color.Green;
                            label5.Enabled = true;
                            label5.Text = "Park 3";
                            label5.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            MessageBox.Show(updatePark.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu park alanı dolu");
                    }
                }
                else
                {
                    // Kullanıcı başka park alanına park etmiş mi?
                    var getParks = ApiCall.RequestJSON($"{connectionString}/Parks", null, "GetParks", Method.Get);
                    var parks = JsonConvert.DeserializeObject<List<GetParksViewModel>>(getParks.Result.ToString());
                    var userParks = parks.Where(x => x.UserId == user.Id).ToList();
                    if (userParks.Count > 0)
                    {
                        MessageBox.Show("Birden fazla park yapamazsınız");
                        return;
                    }
                    // Kullanıcının free ticketi var mı?
                    if (user.FreeTicket > 0)
                    {
                        var updatePark2 = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark2.Success)
                        {
                            // request UpdateScoreForParkingWithFreeTicket endpoint
                            var updateScoreWithFreeTicket = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParkingWithFreeTicket", Method.Put);
                            if (updateScoreWithFreeTicket.Success)
                            {
                                label5.BackColor = Color.Red;
                                label5.Cursor = Cursors.Default;
                                label5.Text += $"\n {user.CarPlate}";
                                return;
                            }
                            else
                            {
                                MessageBox.Show(updateScoreWithFreeTicket.Message);
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show(updatePark2.Message);
                            return;
                        }
                    }
                    // Kullanıcının bakiyesi yeterli mi?
                    if (user.Point < 5)
                    {
                        MessageBox.Show("Bakiyeniz yetersiz");
                        return;
                    }

                    var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                    if (updatePark.Success)
                    {
                        var updateScoreForParking = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParking", Method.Put);
                        if (updateScoreForParking.Success)
                        {
                            label5.BackColor = Color.Red;
                            label5.Cursor = Cursors.Default;
                            label5.Text += $"\n {user.CarPlate}";
                            return;
                        }
                        else
                        {
                            MessageBox.Show(updateScoreForParking.Message);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(updatePark.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show(getPark.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            var loginBody = new
            {
                Email = user.Email,
                Password = user.Password,
            };
            var login = ApiCall.RequestJSON($"{connectionString}/Users", loginBody, "Login", Method.Post);
            if (login.Success)
            {
                user = JsonConvert.DeserializeObject<LoginUserViewModel>(login.Result.ToString());
            }
            var park1 = new
            {
                Id = 6
            };
            var park2 = new
            {
                Id = 6,
                UserId = user.Id
            };
            var park3 = new
            {
                Id = user.Id
            };
            var getPark = ApiCall.RequestJSON($"{connectionString}/Parks", park1, "GetParkById", Method.Get);

            if (getPark.Success)
            {
                var park = JsonConvert.DeserializeObject<GetParksViewModel>(getPark.Result.ToString());
                if (park.IsBusy)
                {
                    if (park.UserId == user.Id)
                    {
                        var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark.Success)
                        {
                            label6.BackColor = Color.Green;
                            label6.Enabled = true;
                            label6.Text = "Park 3";
                            label6.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            MessageBox.Show(updatePark.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu park alanı dolu");
                    }
                }
                else
                {
                    // Kullanıcı başka park alanına park etmiş mi?
                    var getParks = ApiCall.RequestJSON($"{connectionString}/Parks", null, "GetParks", Method.Get);
                    var parks = JsonConvert.DeserializeObject<List<GetParksViewModel>>(getParks.Result.ToString());
                    var userParks = parks.Where(x => x.UserId == user.Id).ToList();
                    if (userParks.Count > 0)
                    {
                        MessageBox.Show("Birden fazla park yapamazsınız");
                        return;
                    }
                    // Kullanıcının free ticketi var mı?
                    if (user.FreeTicket > 0)
                    {
                        var updatePark2 = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                        if (updatePark2.Success)
                        {
                            // request UpdateScoreForParkingWithFreeTicket endpoint
                            var updateScoreWithFreeTicket = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParkingWithFreeTicket", Method.Put);
                            if (updateScoreWithFreeTicket.Success)
                            {
                                label6.BackColor = Color.Red;
                                label6.Cursor = Cursors.Default;
                                label6.Text += $"\n {user.CarPlate}";
                                return;
                            }
                            else
                            {
                                MessageBox.Show(updateScoreWithFreeTicket.Message);
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show(updatePark2.Message);
                            return;
                        }
                    }
                    // Kullanıcının bakiyesi yeterli mi?
                    if (user.Point < 5)
                    {
                        MessageBox.Show("Bakiyeniz yetersiz");
                        return;
                    }

                    var updatePark = ApiCall.RequestJSON($"{connectionString}/Parks", park2, "UpdatePark", Method.Put);
                    if (updatePark.Success)
                    {
                        var updateScoreForParking = ApiCall.RequestJSON($"{connectionString}/Scores", park3, "UpdateScoreForParking", Method.Put);
                        if (updateScoreForParking.Success)
                        {
                            label6.BackColor = Color.Red;
                            label6.Cursor = Cursors.Default;
                            label6.Text += $"\n {user.CarPlate}";
                            return;
                        }
                        else
                        {
                            MessageBox.Show(updateScoreForParking.Message);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(updatePark.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show(getPark.Message);
            }
        }
    }

}


