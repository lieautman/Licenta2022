using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrontDeskManagement
{
    public partial class Employee_page : Form
    {
        public Employee_page()
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
            Register_page frm = new Register_page();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }



        //imagini pe butoane
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
    }
}
