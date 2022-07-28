using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontDeskManagement
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private async void btnSalveaza_ClickAsync(object sender, EventArgs e)
        {
            string firstNameSent = tbFirstName.Text.ToString();
            string lastNameSent = tbLastName.Text.ToString();
            string yearOfBirthSent = tbBirthYear.Text.ToString();
            string emailAddressSent = tbEmail.Text.ToString();
            string paymentMethodSent = cbPaymentMethod.Text.ToString();
            string tokenUserActual = InstanceGlobals.Token.ToString();


            HttpClient HttpApiClient = new HttpClient();
            HttpApiClient.BaseAddress = new Uri("http://localhost:8080/client/create");

            string jsonCreat = @"{
                ""firstName"": """ + firstNameSent + @""",
                ""lastName"": """ + lastNameSent + @""",
                ""birthYear"": """ + yearOfBirthSent + @""",
                ""email"": """ + emailAddressSent + @""",
                ""paymentMethod"": """ + paymentMethodSent + @""",
                ""token"": """ + tokenUserActual + @"""
            }";


            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/client/create", stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la creare client!");
            }
            else
            {
                labelRezultat.Text = "Creat!";
            }
        }

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";
        }
        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";

        }
        private void tbEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";
        }
        private void tbBirthYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";

        }
        private void FormClient_MouseMove(object sender, MouseEventArgs e)
        {
            labelRezultat.Text = "";
        }
    }
}
