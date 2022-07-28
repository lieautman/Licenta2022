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
    public partial class Register_page : Form
    {
        public Register_page()
        {
            InitializeComponent();
        }

        private async void btnSignup_Click(object sender, EventArgs e)
        {
            await signup();
        }

        private async void tbFristName_KeyPressAsync(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                await signup();
            }
        }
        private async void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                await signup();
            }
        }
        private async void tbYearOfBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                await signup();
            }
        }
        private async void tbEmailAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                await signup();
            }
        }
        private async void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                await signup();
            }
        }
        private async void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                await signup();
            }
        }
        private async void tbPassword2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                await signup();
            }
        }

        private async Task signup()
        {
            string firstNameSent = tbFirstName.Text.ToString();
            string lastNameSent = tbLastName.Text.ToString();
            string yearOfBirthSent = tbYearOfBirth.Text.ToString();
            string emailAddressSent = tbEmailAddress.Text.ToString();
            string usernameSent = tbUsername.Text.ToString();
            string passwordSent = tbPassword.Text.ToString();
            string password2Sent = tbPassword2.Text.ToString();

            if (passwordSent != password2Sent)
            {
                tbFirstName.Clear();
                tbLastName.Clear();
                tbYearOfBirth.Clear();
                tbEmailAddress.Clear();
                tbUsername.Clear();
                tbPassword.Clear();
                tbPassword2.Clear();
                MessageBox.Show("Parolele nu sunt egale!");
            }
            else
            {

                HttpClient HttpApiClient = new HttpClient();
                HttpApiClient.BaseAddress = new Uri("http://localhost:8080/account/signup_app");

                string jsonCreat = @"{
                ""firstName"": """ + firstNameSent + @""",
                ""lastName"": """ + lastNameSent + @""",
                ""birthYear"": """ + yearOfBirthSent + @""",
                ""email"": """ + emailAddressSent + @""",
                ""username"": """ + usernameSent + @""",
                ""password"": """ + passwordSent + @"""
                }";


                StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/account/signup_app", stringContent);

                if (response.IsSuccessStatusCode == false)
                {
                    tbFirstName.Clear();
                    tbLastName.Clear();
                    tbYearOfBirth.Clear();
                    tbEmailAddress.Clear();
                    tbUsername.Clear();
                    tbPassword.Clear();
                    tbPassword2.Clear();
                    MessageBox.Show("Eroare la inregistrare!");
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
