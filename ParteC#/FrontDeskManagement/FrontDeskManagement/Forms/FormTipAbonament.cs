using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace FrontDeskManagement
{
    public partial class FormTipAbonament : Form
    {
        public FormTipAbonament()
        {
            InitializeComponent();
        }

        private async void btnSalveaza_Click(object sender, EventArgs e)
        {
            string nrMinuteSent = tbNrMinute.Text.ToString();
            string nrMesajeSent = tbNrMesaje.Text.ToString();
            string gbInternetSent = tbGbInternet.Text.ToString();
            string pretSent = tbPret.Text.ToString();
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();
            HttpApiClient.BaseAddress = new Uri("http://localhost:8080/client/create");

            string jsonCreat = @"{
                ""nrMessages"": """ + nrMinuteSent + @""",
                ""nrMinutes"": """ + nrMesajeSent + @""",
                ""nrGbInternet"": """ + gbInternetSent + @""",
                ""price"": """ + pretSent + @""",
                ""token"": """ + tokenUserActual + @"""
            }";


            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/subscriptionType/create", stringContent);

            labelRezultat.Text = "Creat!";

        }

        private void tbNrMinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";
        }
        private void tbNrMesaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";
        }
        private void tbGbInternet_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";
        }
        private void tbPret_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";
        }
        private void FormTipAbonament_MouseMove(object sender, MouseEventArgs e)
        {
            labelRezultat.Text = "";
        }
    }
}
