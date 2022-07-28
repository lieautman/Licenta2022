using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrontDeskManagement
{
    public partial class Admin_page : Form
    {
        public Admin_page()
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
            FormAfisareDateAdmin frm = new FormAfisareDateAdmin();
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

        private void btnAfisare_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.displayData;
        }

        private void btnAfisare_MouseLeave(object sender, EventArgs e)
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

        private void btnFormularTipAbonament_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Properties.Resources.subscriptionPricing;
        }

        private void btnFormularTipAbonament_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = null;
        }
    }
    
}
