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
    public partial class FormPreturiExtraoptiuni : Form
    {
        public FormPreturiExtraoptiuni()
        {
            InitializeComponent();
        }

        private bool isMinutesNew = true;
        private string minutesId = "";
        private bool isMessagesNew = true;
        private string messagesId = "";
        private bool isGbInternetNew = true;
        private string gbInternetId = "";
        private string tokenUserActual = InstanceGlobals.Token.ToString();

        private async void FormPreturiExtraoptiuni_Load(object sender, EventArgs e)
        {
            await refreshTextBoxesAndPrivateValies();
        }

        private async void btnSalveaza_Click(object sender, EventArgs e)
        {
            string minuteSent = tbMinute.Text.ToString();
            string mesajeSent = tbMesaje.Text.ToString();
            string gbInternteSent = tbGbInternet.Text.ToString();
            string tokenUserActual = InstanceGlobals.Token.ToString();

            //if pt daca sunt noi sau nu
            if (isMessagesNew)
            {
                HttpClient HttpApiClient = new HttpClient();
                string jsonCreat = @"{
                    ""type"": ""minute"",
                    ""pricePerUnit"": """ + minuteSent + @""",
                    ""token"": """ + tokenUserActual + @"""
                }";


                StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/extraOptionPricing/create", stringContent);
            }
            else
            {
                HttpClient HttpApiClient = new HttpClient();
                string jsonCreat = @"{
                    ""type"": ""minute"",
                    ""pricePerUnit"": """ + minuteSent + @""",
                    ""token"": """ + tokenUserActual + @"""
                }";


                StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpApiClient.PutAsync("http://localhost:8080/extraOptionPricing/update/" + minutesId, stringContent);
            }
            if (isMessagesNew)
            {
                HttpClient HttpApiClient = new HttpClient();
                string jsonCreat = @"{
                    ""type"": ""mesaje"",
                    ""pricePerUnit"": """ + mesajeSent + @""",
                    ""token"": """ + tokenUserActual + @"""
                }";


                StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/extraOptionPricing/create", stringContent);
            }
            else
            {
                HttpClient HttpApiClient = new HttpClient();
                string jsonCreat = @"{
                    ""type"": ""mesaje"",
                    ""pricePerUnit"": """ + mesajeSent + @""",
                    ""token"": """ + tokenUserActual + @"""
                }";


                StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpApiClient.PutAsync("http://localhost:8080/extraOptionPricing/update/" + messagesId, stringContent);
            }
            if (isGbInternetNew)
            {
                HttpClient HttpApiClient = new HttpClient();
                string jsonCreat = @"{
                    ""type"": ""gb internet"",
                    ""pricePerUnit"": """ + gbInternteSent + @""",
                    ""token"": """ + tokenUserActual + @"""
                }";


                StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/extraOptionPricing/create", stringContent);
            }
            else
            {
                HttpClient HttpApiClient = new HttpClient();
                string jsonCreat = @"{
                    ""type"": ""gb internet"",
                    ""pricePerUnit"": """ + gbInternteSent + @""",
                    ""token"": """ + tokenUserActual + @"""
                }";


                StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpApiClient.PutAsync("http://localhost:8080/extraOptionPricing/update/" + gbInternetId, stringContent);
            }

            await refreshTextBoxesAndPrivateValies();

            labelRezultat.Text = "Salvat!";
        }

        private void FormPreturiExtraoptiuni_MouseMove(object sender, MouseEventArgs e)
        {
            labelRezultat.Text = "";
        }
        private void tbMinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";
        }
        private void tbMesaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";
        }
        private void tbGbInternet_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelRezultat.Text = "";
        }


        private async Task refreshTextBoxesAndPrivateValies()
        {
            HttpClient HttpApiClient = new HttpClient();
            HttpApiClient.BaseAddress = new Uri("http://localhost:8080/extraOptionPricing/all");


            string jsonCreat = @"{
                ""token"": """ + tokenUserActual + @"""
            }";

            StringContent stringContent = new StringContent(jsonCreat, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await HttpApiClient.PostAsync("http://localhost:8080/extraOptionPricing/all", stringContent);


            if (response.IsSuccessStatusCode == false)
            {
                MessageBox.Show("Nu exista preturi inca!");
            }
            else
            {
                HttpContent content = response.Content;
                Task<string> result = content.ReadAsStringAsync();
                string res = result.Result;

                dynamic data = JObject.Parse(res);//treb sa fol o biblioteca (Newtonsoft.Json/ JSON.NET)

                foreach (dynamic extraOptionPricingInstance in data.extraOptionPricing)
                {
                    string id = extraOptionPricingInstance.idExtraOptionPricing;
                    string type = extraOptionPricingInstance.type;
                    string pricePerUnit = extraOptionPricingInstance.pricePerUnit;



                    switch (type)
                    {
                        case "minute":
                            {
                                tbMinute.Text = pricePerUnit;
                                isMinutesNew = false;
                                minutesId = id;
                                break;
                            }
                        case "mesaje":
                            {
                                tbMesaje.Text = pricePerUnit;
                                isMessagesNew = false;
                                messagesId = id;
                                break;
                            }
                        case "gb internet":
                            {
                                tbGbInternet.Text = pricePerUnit;
                                isGbInternetNew = false;
                                gbInternetId = id;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
}
