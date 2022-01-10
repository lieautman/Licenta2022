using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontDeskManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient HttpApiClient = new HttpClient();
            HttpApiClient.BaseAddress = new Uri("http://localhost:8080/");

            HttpResponseMessage response = HttpApiClient.GetAsync("").Result;

            var a = 0;

        }
    }
}
