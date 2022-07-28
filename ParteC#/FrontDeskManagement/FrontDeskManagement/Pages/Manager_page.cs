using Newtonsoft.Json.Linq;
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
    public partial class Manager_page : Form
    {
        public Manager_page()
        {
            InitializeComponent();
        }

        private void btnFormularClient_Click(object sender, EventArgs e)
        {
            FormClient frm = new FormClient();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnFormularAbonament_Click(object sender, EventArgs e)
        {
            FormAbonament frm = new FormAbonament();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnFormularExtraoptiuni_Click(object sender, EventArgs e)
        {
            FormExtraoptiune frm = new FormExtraoptiune();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnFormularTipAbonament_Click(object sender, EventArgs e)
        {
            FormTipAbonament frm = new FormTipAbonament();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnFormularPreturiExtraoptiuni_Click(object sender, EventArgs e)
        {
            FormPreturiExtraoptiuni frm = new FormPreturiExtraoptiuni();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnAfisare_Click(object sender, EventArgs e)
        {
            FormAfisareDate frm = new FormAfisareDate();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnFormularClient_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.clients;
        }

        private void btnFormularClient_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = null;
        }

        private void btnFormularAbonament_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.subscriptions;
        }

        private void btnFormularAbonament_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = null;
        }

        private void btnFormularExtraoptiuni_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.options;
        }

        private void btnFormularExtraoptiuni_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = null;
        }

        private void btnFormularTipAbonament_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.subscriptionPricing;
        }

        private void btnFormularTipAbonament_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = null;
        }

        private void btnFormularPreturiExtraoptiuni_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.extraOptionPrices;
        }

        private void btnFormularPreturiExtraoptiuni_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = null;
        }

        private void btnAfisare_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.displayData;
        }

        private void btnAfisare_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = null;
        }


        private string tokenUserActual = InstanceGlobals.Token.ToString();
        private int nrClientsTotal;
        private int nrClientsWeb;
        private int nrClientsPhisical;

        private async void afisareStatisticiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HttpClient HttpApiClient = new HttpClient();
            HttpApiClient.BaseAddress = new Uri("http://localhost:8080/client/all");

            string jsonCreat = @"{
                ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/client/all", stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Nu exista clienti inca!");
            }
            else
            {
                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);//treb sa fol o biblioteca (Newtonsoft.Json/ JSON.NET)

                nrClientsTotal = 0;

                foreach (dynamic clientInstance in data.client)
                {
                    nrClientsTotal++;
                }
            }


            HttpApiClient = new HttpClient();
            HttpApiClient.BaseAddress = new Uri("http://localhost:8080/account/all");

            jsonCreat = @"{
                ""token"": """ + tokenUserActual + @"""
            }";

            stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            response = await HttpApiClient.PostAsync("http://localhost:8080/account/all", stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Nu exista conturi inca!");
            }
            else
            {
                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);//treb sa fol o biblioteca (Newtonsoft.Json/ JSON.NET)

                nrClientsWeb = 0;

                foreach (dynamic accountInstance in data.accounts)
                {
                    if (accountInstance.type == "client")
                        nrClientsWeb++;
                }
            }
            nrClientsPhisical = nrClientsTotal - nrClientsWeb;


            FormStatistici frm = new FormStatistici(nrClientsTotal, nrClientsPhisical, nrClientsWeb);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
