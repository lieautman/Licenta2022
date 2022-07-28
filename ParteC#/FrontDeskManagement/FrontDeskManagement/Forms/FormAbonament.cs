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
    public partial class FormAbonament : Form
    {
        public FormAbonament()
        {
            InitializeComponent();
        }


        private string idTipAbonament = "";
        private string idClient = "";
        private string dataStart;
        private string reccuring = "false";
        private EventArgs eLocal;
        private object senderLocal;

        private async void FormAbonament_Load(object sender, EventArgs e)
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
                ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/subscriptionType/all", stringContent);



            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la preluare tipurilor de abonamente!");
            }
            else
            {
                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);


                string sirDropdown = "";
                foreach(dynamic datai in data.subscriptionType)
                {
                    string idSubscriptionType = datai.idSubscriptionType;
                    string nrMessages = datai.nrMessages;
                    string nrMinutes = datai.nrMinutes;
                    string nrGbInternet = datai.nrGbInternet;
                    string price = datai.price;

                    cbTipAbonament.Items.Add("Id: " + idSubscriptionType + "  nrMesaje " + nrMessages + " nrMinute " + nrMinutes + " gbInternet " + nrGbInternet + " la pretul: " + price);


                    string sirDropdownNou = "Id: " + idSubscriptionType + " nrMesaje " + nrMessages + "nrMinute " + nrMinutes + "gbInternet " + nrGbInternet + " la pretul: " + price;

                    if (sirDropdownNou.Length > sirDropdown.Length)
                        sirDropdown = sirDropdownNou;
                    //https://www.youtube.com/watch?v=CQBl1l27dL0
                }
                cbTipAbonament.DropDownWidth = sirDropdown.Length*8;

                cbTipAbonament.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            HttpClient HttpApiClient2 = new HttpClient();

            string jsonCreat2 = @"{
                ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent2 = new StringContent(jsonCreat2, Encoding.UTF8, "application/json");
            HttpResponseMessage response2 = await HttpApiClient2.PostAsync("http://localhost:8080/client/all", stringContent2);

            if (response2.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la preluarea clientilor!");
            }
            else
            {
                HttpContent content = response2.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);


                string sirDropdown = "";
                foreach (dynamic datai in data.client)
                {
                    string idClient = datai.idClient;
                    string firstName = datai.firstName;
                    string lastName = datai.lastName;
                    string email = datai.email;
                    string idAccount = datai.idAccount;

                    cbClient.Items.Add("Id: " + idClient + "  cu numele: " + firstName + " " + lastName + " email " + email + " cu idAccount: " + idAccount);


                    string sirDropdownNou = "Id: " + idClient + "  cu numele: " + firstName + " " + lastName + " email " + email + " cu idAccount: " + idAccount;

                    if (sirDropdownNou.Length > sirDropdown.Length)
                        sirDropdown = sirDropdownNou;
                }

                cbClient.DropDownWidth = sirDropdown.Length * 8;

                cbClient.DropDownStyle = ComboBoxStyle.DropDownList;

            }

            DateTime azi = DateTime.Today;
            dataStart = azi.ToString().Substring(6, 4) + "-" + azi.ToString().Substring(3, 2) + "-" + azi.ToString().Substring(0, 2);
        }


        private async void btnSalveaza_Click(object sender, EventArgs e)
        {
            HttpClient HttpApiClient = new HttpClient();
            string tokenUserActual = InstanceGlobals.Token.ToString();

            string jsonCreat = @"{
                ""idClient"": """ + idClient + @""",
                ""idSubscriptionType"": """ + idTipAbonament + @""",
                ""dataStart"": """ + dataStart + @""",
                ""reccuring"": """ + reccuring + @""",
                ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/subscription/create", stringContent);

            labelRezulatat.Text = "Asociat!";
        }
        private void cbTipAbonament_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTipAbonament = ((System.Windows.Forms.ComboBox)sender).Text.Substring(4, 36);
            labelRezulatat.Text = "";
        }
        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            idClient = ((System.Windows.Forms.ComboBox)sender).Text.Substring(4, 36);
            labelRezulatat.Text = "";
        }
        private void FormAbonament_MouseMove(object sender, MouseEventArgs e)
        {
            labelRezulatat.Text = "";
        }
        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            senderLocal = sender;
            eLocal = e;
            string data1 = sender.ToString().Substring(44,10);

            dataStart=data1.Substring(6,4)+"-"+ data1.Substring(3, 2) + "-" + data1.Substring(0, 2);
        }
        private void cbReccuring_CheckedChanged(object sender, EventArgs e)
        {
            if (reccuring == "false")
            {
                reccuring = "true";
            }
            else
            {
                reccuring = "false";
            }
        }
    }
}