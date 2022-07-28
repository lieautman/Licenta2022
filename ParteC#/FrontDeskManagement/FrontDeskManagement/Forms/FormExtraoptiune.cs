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
    public partial class FormExtraoptiune : Form
    {
        public FormExtraoptiune()
        {
            InitializeComponent();
        }
       
        private async void FormExtraoptiune_Load(object sender, EventArgs e)
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

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

            labelRezultat.Text = "";

        }
        private string idClient = "";
        private async void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            idClient = ((System.Windows.Forms.ComboBox)sender).Text.Substring(4, 36);
            labelRezultat.Text = "";
            labelSelectatiAbonamentul.Visible = true;
            cbAbonament.Visible = true;


            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
                ""idClient"": """ + idClient + @""",
                ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/subscription/allApp", stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la preluare de abonamente!");
            }
            else
            {
                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);


                string sirDropdown = "";
                foreach (dynamic datai in data.subscriptions)
                {
                    string idSubscription = datai.idSubscription;
                    string idSimAsociat = datai.idSimAsociat;
                    string idClient1 = datai.idClient1;
                    string idSubscriptionType = datai.idSubscriptionType;



                    HttpClient HttpApiClient2 = new HttpClient();
                    string jsonCreat2 = @"{
                        ""token"": """ + tokenUserActual + @"""
                    }";

                    StringContent stringContent2 = new StringContent(jsonCreat2, Encoding.UTF8, "application/json");
                    HttpResponseMessage response2 = await HttpApiClient2.PostAsync("http://localhost:8080/subscriptionType/all/" + idSubscriptionType, stringContent2);

                    string caracteristiciTipAbonament = "";
                    if (response2.IsSuccessStatusCode == false)
                    {
                        MessageBox.Show("Eroare de server la preluare tipurilor de abonamente!");
                    }
                    else
                    {
                        HttpContent content2 = response2.Content;
                        Task<string> result2 = content2.ReadAsStringAsync();
                        string res2 = result2.Result;

                        dynamic data2 = JObject.Parse(res2);


                        dynamic datai2 = data2.subscriptionType;
                        string idSubscriptionType2 = datai2.idSubscriptionType;
                        string nrMessages = datai2.nrMessages;
                        string nrMinutes = datai2.nrMinutes;
                        string nrGbInternet = datai2.nrGbInternet;
                        string price = datai2.price;

                        caracteristiciTipAbonament = "nrMesaje " + nrMessages + " nrMinute " + nrMinutes + " nr gb internet " + nrGbInternet + " la pretul:" + price; 
                    }









                    cbAbonament.Items.Add("Id: " + idSubscription + "  idClient " + idClient1 + " idSubscriptionType " + idSubscriptionType + " cu urmatoarele caracteristici:" + caracteristiciTipAbonament);


                    string sirDropdownNou = "Id: " + idSubscription + " idClient " + idClient1 + "idSubscriptionType " + idSubscriptionType + " cu urmatoarele caracteristici:" + caracteristiciTipAbonament;

                    if (sirDropdownNou.Length > sirDropdown.Length)
                        sirDropdown = sirDropdownNou;
                }
                cbAbonament.DropDownWidth = sirDropdown.Length * 8;

                cbAbonament.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            labelRezultat.Text = "";

        }

        private int pretMinute = 0;
        private int pretMesaje = 0;
        private int pretGbInternet = 0;
        private async void cbAbonament_SelectedIndexChanged(object sender, EventArgs e)
        {
            //preluare date despre indexi din baza de date
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
                ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/extraOptionPricing/all", stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la preluare preturi extraoptiuni!");
            }
            else
            {
                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);

                foreach (dynamic datai in data.extraOptionPricing)
                {
                    string type = datai.type;
                    string pricePerUnit = datai.pricePerUnit;

                    switch (type)
                    {
                        case "minute":
                            {
                                pretMinute = Int32.Parse(pricePerUnit);
                                break;
                            }
                        case "mesaje":
                            {
                                pretMesaje = Int32.Parse(pricePerUnit);
                                break;
                            }
                        case "gb internet":
                            {
                                pretGbInternet = Int32.Parse(pricePerUnit);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }

            //modificare id abonament selectat
            idAbonament = ((System.Windows.Forms.ComboBox)sender).Text.Substring(4, 36); ;


            //modificare vizibilitati
            cbTipExtraoptiune.DropDownStyle = ComboBoxStyle.DropDownList;
            labelTipExtraoptiune.Visible = true;
            cbTipExtraoptiune.Visible = true;

            labelRezultat.Text = "";


        }
        private int pretActual = 0;
        private void cbTipExtraoptiune_SelectedIndexChanged(object sender, EventArgs e)
        {
            //schimbare index de imnultit
            //modifica tipul pt save
            if (((System.Windows.Forms.ComboBox)sender).Text == "minute")
            {
                pretActual = pretMinute;
                tipExtraoptiune = "minute";
            }
            if (((System.Windows.Forms.ComboBox)sender).Text == "mesaje")
            {
                pretActual = pretMesaje;
                tipExtraoptiune = "mesaje";
            }
            if (((System.Windows.Forms.ComboBox)sender).Text == "gb internet")
            {
                pretActual = pretGbInternet; 
                tipExtraoptiune = "gb internet";
            }

            labelNumarExtraoptiune.Visible = true;
            tbNumar.Visible = true;

            if (pretIntrodus != 0)
            {
                if (((System.Windows.Forms.ComboBox)sender).Text == "minute")
                    pretActual = pretMinute;
                if (((System.Windows.Forms.ComboBox)sender).Text == "mesaje")
                    pretActual = pretMesaje;
                if (((System.Windows.Forms.ComboBox)sender).Text == "gb internet")
                    pretActual = pretGbInternet;

                pretCalculat = pretActual * pretIntrodus;
                labelPret.Text = pretCalculat.ToString();
            }


            labelRezultat.Text = "";

        }

        private int pretCalculat = 0;
        private int pretIntrodus = 0;
        private void tbNumar_TextChanged(object sender, EventArgs e)
        {
            //imultire cu indexul si pus in labelPret
            pretCalculat=pretActual* Int32.Parse(((System.Windows.Forms.TextBox)sender).Text);
            pretIntrodus = Int32.Parse(((System.Windows.Forms.TextBox)sender).Text);

            labelPret.Text = pretCalculat.ToString();

            labelPretulEste.Visible = true;
            labelPret.Visible = true;
            btnSalveaza.Visible = true;

            labelRezultat.Text = "";
        }


        private string idAbonament = "";
        private string tipExtraoptiune = "";
        private async void btnSalveaza_Click(object sender, EventArgs e)
        {
            //adaugare event listenere pt stergere labelRezultat
            string pretCalculatTrimis = pretCalculat.ToString();

            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
                ""idSubscription"": """ + idAbonament + @""",
                ""type"": """ + tipExtraoptiune + @""",
                ""number"": """ + pretCalculatTrimis + @""",
                ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/extraOption/create", stringContent);


            labelRezultat.Text = "Salvat!";
        }
    }
}