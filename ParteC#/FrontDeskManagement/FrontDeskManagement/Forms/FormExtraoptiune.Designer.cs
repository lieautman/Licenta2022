
namespace FrontDeskManagement
{
    partial class FormExtraoptiune
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExtraoptiune));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.labelSelectatiClientul = new System.Windows.Forms.Label();
            this.labelSelectatiAbonamentul = new System.Windows.Forms.Label();
            this.cbAbonament = new System.Windows.Forms.ComboBox();
            this.labelTipExtraoptiune = new System.Windows.Forms.Label();
            this.cbTipExtraoptiune = new System.Windows.Forms.ComboBox();
            this.labelNumarExtraoptiune = new System.Windows.Forms.Label();
            this.tbNumar = new System.Windows.Forms.TextBox();
            this.labelPretulEste = new System.Windows.Forms.Label();
            this.labelPret = new System.Windows.Forms.Label();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.labelRezultat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrontDeskManagement.Properties.Resources.loginImg;
            this.pictureBox1.Location = new System.Drawing.Point(12, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Completati campurile urmatoare";
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(433, 102);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(346, 28);
            this.cbClient.TabIndex = 13;
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            // 
            // labelSelectatiClientul
            // 
            this.labelSelectatiClientul.AutoSize = true;
            this.labelSelectatiClientul.Location = new System.Drawing.Point(433, 79);
            this.labelSelectatiClientul.Name = "labelSelectatiClientul";
            this.labelSelectatiClientul.Size = new System.Drawing.Size(118, 20);
            this.labelSelectatiClientul.TabIndex = 14;
            this.labelSelectatiClientul.Text = "Selectati clientul";
            // 
            // labelSelectatiAbonamentul
            // 
            this.labelSelectatiAbonamentul.AutoSize = true;
            this.labelSelectatiAbonamentul.Location = new System.Drawing.Point(433, 142);
            this.labelSelectatiAbonamentul.Name = "labelSelectatiAbonamentul";
            this.labelSelectatiAbonamentul.Size = new System.Drawing.Size(158, 20);
            this.labelSelectatiAbonamentul.TabIndex = 15;
            this.labelSelectatiAbonamentul.Text = "Selectati abonamentul";
            this.labelSelectatiAbonamentul.Visible = false;
            // 
            // cbAbonament
            // 
            this.cbAbonament.FormattingEnabled = true;
            this.cbAbonament.Location = new System.Drawing.Point(433, 165);
            this.cbAbonament.Name = "cbAbonament";
            this.cbAbonament.Size = new System.Drawing.Size(346, 28);
            this.cbAbonament.TabIndex = 16;
            this.cbAbonament.Visible = false;
            this.cbAbonament.SelectedIndexChanged += new System.EventHandler(this.cbAbonament_SelectedIndexChanged);
            // 
            // labelTipExtraoptiune
            // 
            this.labelTipExtraoptiune.AutoSize = true;
            this.labelTipExtraoptiune.Location = new System.Drawing.Point(433, 225);
            this.labelTipExtraoptiune.Name = "labelTipExtraoptiune";
            this.labelTipExtraoptiune.Size = new System.Drawing.Size(188, 20);
            this.labelTipExtraoptiune.TabIndex = 17;
            this.labelTipExtraoptiune.Text = "Selectati tipul extraoptiunii";
            this.labelTipExtraoptiune.Visible = false;
            // 
            // cbTipExtraoptiune
            // 
            this.cbTipExtraoptiune.FormattingEnabled = true;
            this.cbTipExtraoptiune.Items.AddRange(new object[] {
            "minute",
            "mesaje",
            "gb internet"});
            this.cbTipExtraoptiune.Location = new System.Drawing.Point(433, 248);
            this.cbTipExtraoptiune.Name = "cbTipExtraoptiune";
            this.cbTipExtraoptiune.Size = new System.Drawing.Size(188, 28);
            this.cbTipExtraoptiune.TabIndex = 18;
            this.cbTipExtraoptiune.Visible = false;
            this.cbTipExtraoptiune.SelectedIndexChanged += new System.EventHandler(this.cbTipExtraoptiune_SelectedIndexChanged);
            // 
            // labelNumarExtraoptiune
            // 
            this.labelNumarExtraoptiune.AutoSize = true;
            this.labelNumarExtraoptiune.Location = new System.Drawing.Point(433, 290);
            this.labelNumarExtraoptiune.Name = "labelNumarExtraoptiune";
            this.labelNumarExtraoptiune.Size = new System.Drawing.Size(139, 20);
            this.labelNumarExtraoptiune.TabIndex = 19;
            this.labelNumarExtraoptiune.Text = "Introduceti numarul";
            this.labelNumarExtraoptiune.Visible = false;
            // 
            // tbNumar
            // 
            this.tbNumar.Location = new System.Drawing.Point(433, 313);
            this.tbNumar.Name = "tbNumar";
            this.tbNumar.Size = new System.Drawing.Size(125, 27);
            this.tbNumar.TabIndex = 20;
            this.tbNumar.Visible = false;
            this.tbNumar.TextChanged += new System.EventHandler(this.tbNumar_TextChanged);
            // 
            // labelPretulEste
            // 
            this.labelPretulEste.AutoSize = true;
            this.labelPretulEste.Location = new System.Drawing.Point(635, 290);
            this.labelPretulEste.Name = "labelPretulEste";
            this.labelPretulEste.Size = new System.Drawing.Size(78, 20);
            this.labelPretulEste.TabIndex = 21;
            this.labelPretulEste.Text = "Pretul este";
            this.labelPretulEste.Visible = false;
            // 
            // labelPret
            // 
            this.labelPret.AutoSize = true;
            this.labelPret.Location = new System.Drawing.Point(635, 313);
            this.labelPret.Name = "labelPret";
            this.labelPret.Size = new System.Drawing.Size(33, 20);
            this.labelPret.TabIndex = 22;
            this.labelPret.Text = "100";
            this.labelPret.Visible = false;
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(487, 356);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(194, 59);
            this.btnSalveaza.TabIndex = 23;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Visible = false;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // labelRezultat
            // 
            this.labelRezultat.AutoSize = true;
            this.labelRezultat.Location = new System.Drawing.Point(558, 418);
            this.labelRezultat.Name = "labelRezultat";
            this.labelRezultat.Size = new System.Drawing.Size(0, 20);
            this.labelRezultat.TabIndex = 24;
            // 
            // FormExtraoptiune
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelRezultat);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.labelPret);
            this.Controls.Add(this.labelPretulEste);
            this.Controls.Add(this.tbNumar);
            this.Controls.Add(this.labelNumarExtraoptiune);
            this.Controls.Add(this.cbTipExtraoptiune);
            this.Controls.Add(this.labelTipExtraoptiune);
            this.Controls.Add(this.cbAbonament);
            this.Controls.Add(this.labelSelectatiAbonamentul);
            this.Controls.Add(this.labelSelectatiClientul);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExtraoptiune";
            this.Text = "Form Extraoptiune";
            this.Load += new System.EventHandler(this.FormExtraoptiune_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label labelSelectatiClientul;
        private System.Windows.Forms.Label labelSelectatiAbonamentul;
        private System.Windows.Forms.ComboBox cbAbonament;
        private System.Windows.Forms.Label labelTipExtraoptiune;
        private System.Windows.Forms.ComboBox cbTipExtraoptiune;
        private System.Windows.Forms.Label labelNumarExtraoptiune;
        private System.Windows.Forms.TextBox tbNumar;
        private System.Windows.Forms.Label labelPretulEste;
        private System.Windows.Forms.Label labelPret;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Label labelRezultat;
    }
}