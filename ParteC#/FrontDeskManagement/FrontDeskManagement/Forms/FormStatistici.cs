using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontDeskManagement
{
    public partial class FormStatistici : Form
    {


        private int nrClientsTotal1;
        private int nrClientsWeb1;
        private int nrClientsPhisical1;

        public FormStatistici(int nrClientsTotal, int nrClientsPhisical, int nrClientsWeb)
        {
            nrClientsTotal1 = nrClientsTotal;
            nrClientsWeb1 = nrClientsWeb;
            nrClientsPhisical1 = nrClientsPhisical;
            InitializeComponent();
        }





        private async void FormStatistici_Paint(object sender, PaintEventArgs e)
        {
           


            //desenare pe formular
            Random random = new Random();

            //general details
            Graphics g = e.Graphics;


            int centerX = 70;
            int centerY = 70;
            int radius = 60;

            //details first half
            int colorRed = random.Next(20, 255);
            int colorGreen = random.Next(20, 255);
            int colorBlue = random.Next(20, 255);

            int darkness = 20;


            //these change under the condition of nr of clients
            float fractie = (float) nrClientsPhisical1 / nrClientsTotal1;

            float startAngle = -90;
            float endAngle = 360*fractie;


            Brush brush1 = new SolidBrush(Color.FromArgb(colorRed, colorGreen, colorBlue));
            Brush brush2 = new SolidBrush(Color.FromArgb(colorRed - darkness, colorGreen - darkness, colorBlue - darkness));


            Pen pen1 = new Pen(Color.FromArgb(0, 0, 0), 2);
            Pen pen2 = new Pen(Color.FromArgb(0, 0, 0), 2);




            //details second half
            int colorRed2 = random.Next(20, 255);
            int colorGreen2 = random.Next(20, 255);
            int colorBlue2 = random.Next(20, 255);

            //these change under the condition of nr of clients
            float startAngle2 = 360 * fractie-90;
            float endAngle2 = 360 * (1-fractie);

            Brush brush21 = new SolidBrush(Color.FromArgb(colorRed2, colorGreen2, colorBlue2));
            Brush brush22 = new SolidBrush(Color.FromArgb(colorRed2 - darkness, colorGreen2 - darkness, colorBlue2 - darkness));


            Pen pen21 = new Pen(Color.FromArgb(0, 0, 0), 2);
            Pen pen22 = new Pen(Color.FromArgb(0, 0, 0), 2);







            //first half front
            g.FillPie(brush1, centerX - radius, centerY - radius, radius + radius, radius + radius, startAngle, endAngle);

            g.DrawPie(pen1, centerX - radius, centerY - radius, radius + radius, radius + radius, startAngle, endAngle);
            //second half front
            g.FillPie(brush21, centerX - radius, centerY - radius, radius + radius, radius + radius, startAngle2, endAngle2);

            g.DrawPie(pen21, centerX - radius, centerY - radius, radius + radius, radius + radius, startAngle2, endAngle2);


            g.DrawString(nrClientsPhisical1.ToString(), new Font(FontFamily.GenericSansSerif, 7), new SolidBrush(Color.Black), 170, 37);
            g.DrawString(nrClientsWeb1.ToString(), new Font(FontFamily.GenericSansSerif, 7), new SolidBrush(Color.Black), 170, 77);

            g.DrawString("Pondere clienti de pe site-ul web", new Font(FontFamily.GenericSansSerif, 7), new SolidBrush(Color.Black), 210, 77);



            //desenare patratele pentru intelegere desen
            //patratel si proportie clientiWeb

            g.FillRectangle(brush1, new Rectangle(200,40,10,10));
            g.DrawString("Pondere clienti de la ghiseu", new Font(FontFamily.GenericSansSerif, 7), new SolidBrush(Color.Black), 210,37);


            //patratel si proportie clientiPhisical
            g.FillRectangle(brush21, new Rectangle(200, 80, 10, 10));
            g.DrawString("Pondere clienti de pe site-ul web", new Font(FontFamily.GenericSansSerif, 7), new SolidBrush(Color.Black), 210, 77);
        }
    }
}
