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
    public partial class FormModificareCont : Form
    {
        private string idCont;
        public FormModificareCont(string idCont)
        {
            InitializeComponent();
            this.idCont = idCont;
        }

        private async void FormModificareCont_Load(object sender, EventArgs e)
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/account/byId/" + idCont, stringContent);



            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la preluare date cont!");
            }
            else
            {

                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);

                dynamic datai = data.account;

                string firstName = datai.firstName;
                string lastName = datai.lastName;
                string email = datai.email;
                string birthYear= datai.birthYear;
                string username = datai.username;
                string type = datai.type;

                tbFirstName.Text = firstName;
                tbLastName.Text = lastName;
                tbEmailAddress.Text = email;
                tbYearOfBirth.Text = birthYear;
                tbUsername.Text = username;
                cbType.Text = type;


            } 
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string tokenUserActual = InstanceGlobals.Token.ToString();

            HttpClient HttpApiClient = new HttpClient();

            string jsonCreat = @"{
            ""firstName"": """ + tbFirstName.Text + @""",
            ""lastName"": """ + tbLastName.Text + @""",
            ""email"": """ + tbEmailAddress.Text + @""",
            ""birthYear"": """ + tbYearOfBirth.Text + @""",
            ""username"": """ + tbUsername.Text + @""",
            ""type"": """ + cbType.Text + @""",
            ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PutAsync("http://localhost:8080/account/update/" + idCont, stringContent);



            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Eroare de server la salvare!");
            }
            else
            {
                labelRezultat.Text = "Salvat!";
            }
        }
    }
}
