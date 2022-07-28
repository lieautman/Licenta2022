
namespace FrontDeskManagement
{
    partial class FormAfisareDate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAfisareDate));
            this.labelSelectatiClientul = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.cbAbonament = new System.Windows.Forms.ComboBox();
            this.labelSelectatiAbonamentul = new System.Windows.Forms.Label();
            this.cbExtraoptiune = new System.Windows.Forms.ComboBox();
            this.labelExtraoptiune = new System.Windows.Forms.Label();
            this.cbTipAbonament = new System.Windows.Forms.ComboBox();
            this.labelTipAbonament = new System.Windows.Forms.Label();
            this.btnStergeClient = new System.Windows.Forms.Button();
            this.btnStergeAbonament = new System.Windows.Forms.Button();
            this.btnStergeExtraoptiunea = new System.Windows.Forms.Button();
            this.btnStergeTipAbonament = new System.Windows.Forms.Button();
            this.labelAtentie = new System.Windows.Forms.Label();
            this.labelRezultat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSelectatiClientul
            // 
            this.labelSelectatiClientul.AutoSize = true;
            this.labelSelectatiClientul.Location = new System.Drawing.Point(12, 28);
            this.labelSelectatiClientul.Name = "labelSelectatiClientul";
            this.labelSelectatiClientul.Size = new System.Drawing.Size(118, 20);
            this.labelSelectatiClientul.TabIndex = 16;
            this.labelSelectatiClientul.Text = "Selectati clientul";
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(12, 51);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(328, 28);
            this.cbClient.TabIndex = 15;
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            // 
            // cbAbonament
            // 
            this.cbAbonament.FormattingEnabled = true;
            this.cbAbonament.Location = new System.Drawing.Point(12, 126);
            this.cbAbonament.Name = "cbAbonament";
            this.cbAbonament.Size = new System.Drawing.Size(328, 28);
            this.cbAbonament.TabIndex = 18;
            this.cbAbonament.Visible = false;
            this.cbAbonament.SelectedIndexChanged += new System.EventHandler(this.cbAbonament_SelectedIndexChanged);
            // 
            // labelSelectatiAbonamentul
            // 
            this.labelSelectatiAbonamentul.AutoSize = true;
            this.labelSelectatiAbonamentul.Location = new System.Drawing.Point(12, 103);
            this.labelSelectatiAbonamentul.Name = "labelSelectatiAbonamentul";
            this.labelSelectatiAbonamentul.Size = new System.Drawing.Size(158, 20);
            this.labelSelectatiAbonamentul.TabIndex = 17;
            this.labelSelectatiAbonamentul.Text = "Selectati abonamentul";
            this.labelSelectatiAbonamentul.Visible = false;
            // 
            // cbExtraoptiune
            // 
            this.cbExtraoptiune.FormattingEnabled = true;
            this.cbExtraoptiune.Location = new System.Drawing.Point(12, 206);
            this.cbExtraoptiune.Name = "cbExtraoptiune";
            this.cbExtraoptiune.Size = new System.Drawing.Size(328, 28);
            this.cbExtraoptiune.TabIndex = 20;
            this.cbExtraoptiune.Visible = false;
            this.cbExtraoptiune.SelectedIndexChanged += new System.EventHandler(this.cbExtraoptiune_SelectedIndexChanged);
            // 
            // labelExtraoptiune
            // 
            this.labelExtraoptiune.AutoSize = true;
            this.labelExtraoptiune.Location = new System.Drawing.Point(12, 183);
            this.labelExtraoptiune.Name = "labelExtraoptiune";
            this.labelExtraoptiune.Size = new System.Drawing.Size(162, 20);
            this.labelExtraoptiune.TabIndex = 19;
            this.labelExtraoptiune.Text = "Selectati extraoptiunea";
            this.labelExtraoptiune.Visible = false;
            // 
            // cbTipAbonament
            // 
            this.cbTipAbonament.FormattingEnabled = true;
            this.cbTipAbonament.Location = new System.Drawing.Point(12, 330);
            this.cbTipAbonament.Name = "cbTipAbonament";
            this.cbTipAbonament.Size = new System.Drawing.Size(328, 28);
            this.cbTipAbonament.TabIndex = 22;
            this.cbTipAbonament.SelectedIndexChanged += new System.EventHandler(this.cbTipAbonament_SelectedIndexChanged);
            // 
            // labelTipAbonament
            // 
            this.labelTipAbonament.AutoSize = true;
            this.labelTipAbonament.Location = new System.Drawing.Point(12, 307);
            this.labelTipAbonament.Name = "labelTipAbonament";
            this.labelTipAbonament.Size = new System.Drawing.Size(201, 20);
            this.labelTipAbonament.TabIndex = 21;
            this.labelTipAbonament.Text = "Selectati tipul de abonament";
            // 
            // btnStergeClient
            // 
            this.btnStergeClient.Location = new System.Drawing.Point(453, 45);
            this.btnStergeClient.Name = "btnStergeClient";
            this.btnStergeClient.Size = new System.Drawing.Size(156, 39);
            this.btnStergeClient.TabIndex = 23;
            this.btnStergeClient.Text = "Sterge client";
            this.btnStergeClient.UseVisualStyleBackColor = true;
            this.btnStergeClient.Visible = false;
            this.btnStergeClient.Click += new System.EventHandler(this.btnStergeClient_Click);
            // 
            // btnStergeAbonament
            // 
            this.btnStergeAbonament.Location = new System.Drawing.Point(453, 120);
            this.btnStergeAbonament.Name = "btnStergeAbonament";
            this.btnStergeAbonament.Size = new System.Drawing.Size(156, 39);
            this.btnStergeAbonament.TabIndex = 24;
            this.btnStergeAbonament.Text = "Sterge abonament";
            this.btnStergeAbonament.UseVisualStyleBackColor = true;
            this.btnStergeAbonament.Visible = false;
            this.btnStergeAbonament.Click += new System.EventHandler(this.btnStergeAbonament_Click);
            // 
            // btnStergeExtraoptiunea
            // 
            this.btnStergeExtraoptiunea.Location = new System.Drawing.Point(453, 200);
            this.btnStergeExtraoptiunea.Name = "btnStergeExtraoptiunea";
            this.btnStergeExtraoptiunea.Size = new System.Drawing.Size(156, 39);
            this.btnStergeExtraoptiunea.TabIndex = 25;
            this.btnStergeExtraoptiunea.Text = "Sterge extraoptiunea";
            this.btnStergeExtraoptiunea.UseVisualStyleBackColor = true;
            this.btnStergeExtraoptiunea.Visible = false;
            this.btnStergeExtraoptiunea.Click += new System.EventHandler(this.btnStergeExtraoptiunea_Click);
            // 
            // btnStergeTipAbonament
            // 
            this.btnStergeTipAbonament.Location = new System.Drawing.Point(453, 318);
            this.btnStergeTipAbonament.Name = "btnStergeTipAbonament";
            this.btnStergeTipAbonament.Size = new System.Drawing.Size(156, 51);
            this.btnStergeTipAbonament.TabIndex = 26;
            this.btnStergeTipAbonament.Text = "Sterge tip abonament";
            this.btnStergeTipAbonament.UseVisualStyleBackColor = true;
            this.btnStergeTipAbonament.Visible = false;
            this.btnStergeTipAbonament.Click += new System.EventHandler(this.btnStergeTipAbonament_Click);
            // 
            // labelAtentie
            // 
            this.labelAtentie.AutoSize = true;
            this.labelAtentie.Font = new System.Drawing.Font("Stencil", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAtentie.Location = new System.Drawing.Point(12, 402);
            this.labelAtentie.Name = "labelAtentie";
            this.labelAtentie.Size = new System.Drawing.Size(776, 20);
            this.labelAtentie.TabIndex = 27;
            this.labelAtentie.Text = "Atentie: Orice actiune este permanenta si are repercusiuni in baza de date!";
            // 
            // labelRezultat
            // 
            this.labelRezultat.AutoSize = true;
            this.labelRezultat.Location = new System.Drawing.Point(707, 154);
            this.labelRezultat.Name = "labelRezultat";
            this.labelRezultat.Size = new System.Drawing.Size(0, 20);
            this.labelRezultat.TabIndex = 28;
            // 
            // FormAfisareDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelRezultat);
            this.Controls.Add(this.labelAtentie);
            this.Controls.Add(this.btnStergeTipAbonament);
            this.Controls.Add(this.btnStergeExtraoptiunea);
            this.Controls.Add(this.btnStergeAbonament);
            this.Controls.Add(this.btnStergeClient);
            this.Controls.Add(this.cbTipAbonament);
            this.Controls.Add(this.labelTipAbonament);
            this.Controls.Add(this.cbExtraoptiune);
            this.Controls.Add(this.labelExtraoptiune);
            this.Controls.Add(this.cbAbonament);
            this.Controls.Add(this.labelSelectatiAbonamentul);
            this.Controls.Add(this.labelSelectatiClientul);
            this.Controls.Add(this.cbClient);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAfisareDate";
            this.Text = "Form AfisareDate";
            this.Load += new System.EventHandler(this.FormAfisareDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectatiClientul;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.ComboBox cbAbonament;
        private System.Windows.Forms.Label labelSelectatiAbonamentul;
        private System.Windows.Forms.ComboBox cbExtraoptiune;
        private System.Windows.Forms.Label labelExtraoptiune;
        private System.Windows.Forms.ComboBox cbTipAbonament;
        private System.Windows.Forms.Label labelTipAbonament;
        private System.Windows.Forms.Button btnStergeClient;
        private System.Windows.Forms.Button btnStergeAbonament;
        private System.Windows.Forms.Button btnStergeExtraoptiunea;
        private System.Windows.Forms.Button btnStergeTipAbonament;
        private System.Windows.Forms.Label labelAtentie;
        private System.Windows.Forms.Label labelRezultat;
    }
}