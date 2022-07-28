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
    public partial class FormAfisareDateAdmin : Form
    {
        public FormAfisareDateAdmin()
        {
            InitializeComponent();
        }

        private async void FormAfisareDateAdmin_Load(object sender, EventArgs e)
        {
            await loadForm();
        }

        private string idClient = "";
        private async void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            idClient = ((System.Windows.Forms.ComboBox)sender).Text.Substring(4, 36);
            labelRezultat.Text = "";
            labelSelectatiAbonamentul.Visible = true;
            cbAbonament.Visible = true;
            btnStergeClient.Visible = true;

            btnStergeAbonament.Visible = false;

            labelExtraoptiune.Visible = false;
            cbExtraoptiune.Visible = false;
            btnStergeExtraoptiunea.Visible = false;


            await loadAbonamente();
        }
        private async void btnStergeClient_Click(object sender, EventArgs e)
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/client/delete/" + idClient, stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la stergere client!");
                await loadForm();
            }
            else
            {
                labelRezultat.Text = "STERS!";
                await loadForm();


                labelSelectatiAbonamentul.Visible = false;
                cbAbonament.Visible = false;
                btnStergeAbonament.Visible = false;

                labelExtraoptiune.Visible = false;
                cbExtraoptiune.Visible = false;
                btnStergeExtraoptiunea.Visible = false;
            }
        }

        private string idAbonament = "";
        private async void cbAbonament_SelectedIndexChanged(object sender, EventArgs e)
        {
            idAbonament = ((System.Windows.Forms.ComboBox)sender).Text.Substring(4, 36);
            labelRezultat.Text = "";
            labelExtraoptiune.Visible = true;
            cbExtraoptiune.Visible = true;
            btnStergeAbonament.Visible = true;

            btnStergeExtraoptiunea.Visible = false;

            await loadExtraoptiuni();
        }
        private async void btnStergeAbonament_Click(object sender, EventArgs e)
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""idClient"": """ + idClient + @""",
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/subscription/deleteApp/" + idAbonament, stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la stergere abonamentului!");
                await loadAbonamente();
            }
            else
            {
                labelRezultat.Text = "STERS!";
                await loadAbonamente();

                labelExtraoptiune.Visible = false;
                cbExtraoptiune.Visible = false;
                btnStergeExtraoptiunea.Visible = false;
            }
        }

        private string idExtraoptiune = "";
        private void cbExtraoptiune_SelectedIndexChanged(object sender, EventArgs e)
        {
            idExtraoptiune = ((System.Windows.Forms.ComboBox)sender).Text.Substring(4, 36);
            btnStergeExtraoptiunea.Visible = true;
        }
        private async void btnStergeExtraoptiunea_Click(object sender, EventArgs e)
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/extraOption/deleteApp/" + idExtraoptiune, stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la stergere extraoptiuni!");
                await loadExtraoptiuni();
            }
            else
            {
                labelRezultat.Text = "STERS!";
                await loadExtraoptiuni();
            }
        }

        private string idTipAbonament = "";
        private void cbTipAbonament_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTipAbonament = ((System.Windows.Forms.ComboBox)sender).Text.Substring(4, 36);
            btnStergeTipAbonament.Visible = true;
        }
        private async void btnStergeTipAbonament_Click(object sender, EventArgs e)
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/subscriptionType/delete/" + idTipAbonament, stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la stergere tip abonament!");
                await loadForm();
            }
            else
            {
                labelRezultat.Text = "STERS!";
                await loadForm();

                labelSelectatiAbonamentul.Visible = false;
                cbAbonament.Visible = false;
                btnStergeAbonament.Visible = false;

                labelExtraoptiune.Visible = false;
                cbExtraoptiune.Visible = false;
                btnStergeExtraoptiunea.Visible = false;
            }
        }

        private string idCont = "";
        private void cbConturi_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCont = ((System.Windows.Forms.ComboBox)sender).Text.Substring(4, 36);
            btnStergeCont.Visible = true;
            btnModificaCont.Visible = true;
        }
        private async void btnStergeCont_Click(object sender, EventArgs e)
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/account/delete/" + idCont, stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la stergere cont!");
                await loadForm();
            }
            else
            {
                labelRezultat.Text = "STERS!";
                await loadForm();
            }
        }
        private async void btnModificaCont_Click(object sender, EventArgs e)
        {
            FormModificareCont frm = new FormModificareCont(idCont);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            await loadForm();
        }


        private async Task loadForm()
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            //preluare clienti
            HttpClient HttpApiClient2 = new HttpClient();

            string jsonCreat2 = @"{
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent2 = new StringContent(jsonCreat2, Encoding.UTF8, "application/json");
            HttpResponseMessage response2 = await HttpApiClient2.PostAsync("http://localhost:8080/client/all", stringContent2);

            cbClient.Items.Clear();
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


            //preluare tipuri de abonamente
            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/subscriptionType/all", stringContent);

            cbTipAbonament.Items.Clear();
            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la preluare tipuri de abonamente!");
            }
            else
            {
                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);


                string sirDropdown = "";
                foreach (dynamic datai in data.subscriptionType)
                {
                    string idSubscriptionType = datai.idSubscriptionType;
                    string nrMessages = datai.nrMessages;
                    string nrMinutes = datai.nrMinutes;
                    string nrGbInternet = datai.nrGbInternet;
                    string price = datai.price;


                    cbTipAbonament.Items.Add("Id: " + idSubscriptionType + " cu un numar de " + nrMessages + " mesaje, " + nrMinutes + " minute, " + nrGbInternet + " Gb internet la pretul:" + price);


                    string sirDropdownNou = "Id: " + idSubscriptionType + " cu un numar de " + nrMessages + " mesaje, " + nrMinutes + " minute, " + nrGbInternet + " Gb internet la pretul:" + price;

                    if (sirDropdownNou.Length > sirDropdown.Length)
                        sirDropdown = sirDropdownNou;
                }

                cbTipAbonament.DropDownWidth = sirDropdown.Length * 8;

                cbTipAbonament.DropDownStyle = ComboBoxStyle.DropDownList;
            }



            //preluare conturi
            HttpClient HttpApiClient3 = new HttpClient();

            string jsonCreat3 = @"{
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent3 = new StringContent(jsonCreat3, Encoding.UTF8, "application/json");
            HttpResponseMessage response3 = await HttpApiClient3.PostAsync("http://localhost:8080/account/all", stringContent3);

            cbConturi.Items.Clear();
            if (response3.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la preluarea conturilor!");
            }
            else
            {
                HttpContent content = response3.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);


                string sirDropdown = "";
                foreach (dynamic datai in data.accounts)
                {
                    string idAccount = datai.idAccount;
                    string firstName = datai.firstName;
                    string lastName = datai.lastName;
                    string email = datai.email;
                    string username = datai.username;
                    string type = datai.type;

                    cbConturi.Items.Add("Id: " + idAccount + "  cu numele: " + firstName + " " + lastName + " email " + email + ", username " + username + " si tipul " + type);


                    string sirDropdownNou = "Id: " + idAccount + "  cu numele: " + firstName + " " + lastName + " email " + email + ", username " + username + " si tipul " + type;

                    if (sirDropdownNou.Length > sirDropdown.Length)
                        sirDropdown = sirDropdownNou;
                }

                cbConturi.DropDownWidth = sirDropdown.Length * 8;

                cbConturi.DropDownStyle = ComboBoxStyle.DropDownList;

            }
        }
        private async Task loadAbonamente()
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""idClient"": """ + idClient + @""",
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/subscription/allApp", stringContent);


            cbAbonament.Items.Clear();
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
        }
        private async Task loadExtraoptiuni()
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""idSubscription"": """ + idAbonament + @""",
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/extraOption/allForSubscription", stringContent);

            cbExtraoptiune.Items.Clear();
            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la preluare de extraoptiuni!");
            }
            else
            {
                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);


                string sirDropdown = "";
                foreach (dynamic datai in data.extraOptions)
                {
                    string idExtraOption = datai.idExtraOption;
                    string type = datai.type;
                    string number = datai.number;
                    string price = datai.price;

                    cbExtraoptiune.Items.Add("Id: " + idExtraOption + " cu un numar de " + number + " " + type + " la pretul:" + price);


                    string sirDropdownNou = "Id: " + idExtraOption + " cu un numar de " + number + " " + type + " la pretul:" + price;

                    if (sirDropdownNou.Length > sirDropdown.Length)
                        sirDropdown = sirDropdownNou;
                }
                cbExtraoptiune.DropDownWidth = sirDropdown.Length * 8;

                cbExtraoptiune.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}
