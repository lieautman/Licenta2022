using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontDeskManagement
{
    public partial class Login_page : Form
    {

        public Login_page()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await login();
        }

        private async void tbUsername_KeyPressAsync(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== 13)
            {
                await login();
            }
        }
        private async void tbParola_KeyPressAsync(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                await login();
            }
        }

        private async Task login()
        {
            string usernameSent = tbUsername.Text.ToString();//preluat din input daca e
            string passwordSent = tbPassword.Text.ToString();//preluat din input daca e
            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
                ""username"": """ + usernameSent + @""",
                ""password"": """ + passwordSent + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/account/login_app", stringContent);

            if (response.IsSuccessStatusCode == false)
            {
                tbUsername.Clear();
                tbPassword.Clear();
                MessageBox.Show("Eroare de autentificare");
            }
            else
            {
                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);//treb sa fol o biblioteca (Newtonsoft.Json/ JSON.NET)

                string id = data.id;
                string firstName = data.firstName;
                string lastName = data.lastName;
                string birthYear = data.birthYear;
                string username = data.username;
                string type = data.type;
                string token = data.token;

                InstanceGlobals.Id = id;
                InstanceGlobals.FirstName = firstName;
                InstanceGlobals.LastName = lastName;
                InstanceGlobals.BirthYear = birthYear;
                InstanceGlobals.Username = username;
                InstanceGlobals.Type = type;
                InstanceGlobals.Token = token;


                switch (InstanceGlobals.Type)
                {
                    case "client":
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = "http://localhost:3000/",//aici va treb sa pun adevaratul url al site-ului cand(daca) ii dau deploy
                                UseShellExecute = true
                            });

                            break;
                        }
                    case "employee":
                        {
                            Employee_page frm = new Employee_page();
                            this.Hide();
                            frm.ShowDialog();
                            this.Show();
                            break;
                        }
                    case "admin":
                        {
                            Admin_page frm = new Admin_page();
                            this.Hide();
                            frm.ShowDialog();
                            this.Show();
                            break;
                        }
                    case "manager":
                        {
                            Manager_page frm = new Manager_page();
                            this.Hide();
                            frm.ShowDialog();
                            this.Show();
                            break;
                        }
                    default:
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = "http://localhost:3000/",//aici va treb sa pun adevaratul url al site-ului cand(daca) ii dau deploy
                                UseShellExecute = true
                            });
                            break;
                        }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Register_page frm = new Register_page();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
