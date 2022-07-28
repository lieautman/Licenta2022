
namespace FrontDeskManagement
{
    partial class FormTipAbonament
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTipAbonament));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelRezultat = new System.Windows.Forms.Label();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.tbPret = new System.Windows.Forms.TextBox();
            this.tbGbInternet = new System.Windows.Forms.TextBox();
            this.tbNrMesaje = new System.Windows.Forms.TextBox();
            this.tbNrMinute = new System.Windows.Forms.TextBox();
            this.labelPret = new System.Windows.Forms.Label();
            this.labelNrGbInternet = new System.Windows.Forms.Label();
            this.labelNrMesaje = new System.Windows.Forms.Label();
            this.labelNrMinute = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Completati campurile urmatoare";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrontDeskManagement.Properties.Resources.loginImg;
            this.pictureBox1.Location = new System.Drawing.Point(12, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // labelRezultat
            // 
            this.labelRezultat.AutoSize = true;
            this.labelRezultat.Location = new System.Drawing.Point(559, 344);
            this.labelRezultat.Name = "labelRezultat";
            this.labelRezultat.Size = new System.Drawing.Size(0, 20);
            this.labelRezultat.TabIndex = 21;
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(491, 282);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(194, 59);
            this.btnSalveaza.TabIndex = 20;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // tbPret
            // 
            this.tbPret.Location = new System.Drawing.Point(590, 226);
            this.tbPret.Name = "tbPret";
            this.tbPret.Size = new System.Drawing.Size(125, 27);
            this.tbPret.TabIndex = 19;
            this.tbPret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPret_KeyPress);
            // 
            // tbGbInternet
            // 
            this.tbGbInternet.Location = new System.Drawing.Point(590, 185);
            this.tbGbInternet.Name = "tbGbInternet";
            this.tbGbInternet.Size = new System.Drawing.Size(125, 27);
            this.tbGbInternet.TabIndex = 18;
            this.tbGbInternet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGbInternet_KeyPress);
            // 
            // tbNrMesaje
            // 
            this.tbNrMesaje.Location = new System.Drawing.Point(590, 144);
            this.tbNrMesaje.Name = "tbNrMesaje";
            this.tbNrMesaje.Size = new System.Drawing.Size(125, 27);
            this.tbNrMesaje.TabIndex = 17;
            this.tbNrMesaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNrMesaje_KeyPress);
            // 
            // tbNrMinute
            // 
            this.tbNrMinute.Location = new System.Drawing.Point(590, 103);
            this.tbNrMinute.Name = "tbNrMinute";
            this.tbNrMinute.Size = new System.Drawing.Size(125, 27);
            this.tbNrMinute.TabIndex = 16;
            this.tbNrMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNrMinute_KeyPress);
            // 
            // labelPret
            // 
            this.labelPret.AutoSize = true;
            this.labelPret.Location = new System.Drawing.Point(450, 229);
            this.labelPret.Name = "labelPret";
            this.labelPret.Size = new System.Drawing.Size(35, 20);
            this.labelPret.TabIndex = 15;
            this.labelPret.Text = "Pret";
            // 
            // labelNrGbInternet
            // 
            this.labelNrGbInternet.AutoSize = true;
            this.labelNrGbInternet.Location = new System.Drawing.Point(450, 188);
            this.labelNrGbInternet.Name = "labelNrGbInternet";
            this.labelNrGbInternet.Size = new System.Drawing.Size(132, 20);
            this.labelNrGbInternet.TabIndex = 14;
            this.labelNrGbInternet.Text = "Numar Gb internet";
            // 
            // labelNrMesaje
            // 
            this.labelNrMesaje.AutoSize = true;
            this.labelNrMesaje.Location = new System.Drawing.Point(450, 147);
            this.labelNrMesaje.Name = "labelNrMesaje";
            this.labelNrMesaje.Size = new System.Drawing.Size(105, 20);
            this.labelNrMesaje.TabIndex = 13;
            this.labelNrMesaje.Text = "Numar mesaje";
            // 
            // labelNrMinute
            // 
            this.labelNrMinute.AutoSize = true;
            this.labelNrMinute.Location = new System.Drawing.Point(450, 106);
            this.labelNrMinute.Name = "labelNrMinute";
            this.labelNrMinute.Size = new System.Drawing.Size(104, 20);
            this.labelNrMinute.TabIndex = 12;
            this.labelNrMinute.Text = "Numar minute";
            // 
            // FormTipAbonament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelRezultat);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.tbPret);
            this.Controls.Add(this.tbGbInternet);
            this.Controls.Add(this.tbNrMesaje);
            this.Controls.Add(this.tbNrMinute);
            this.Controls.Add(this.labelPret);
            this.Controls.Add(this.labelNrGbInternet);
            this.Controls.Add(this.labelNrMesaje);
            this.Controls.Add(this.labelNrMinute);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTipAbonament";
            this.Text = "Form TipAbonament";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTipAbonament_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelRezultat;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.TextBox tbPret;
        private System.Windows.Forms.TextBox tbGbInternet;
        private System.Windows.Forms.TextBox tbNrMesaje;
        private System.Windows.Forms.TextBox tbNrMinute;
        private System.Windows.Forms.Label labelPret;
        private System.Windows.Forms.Label labelNrGbInternet;
        private System.Windows.Forms.Label labelNrMesaje;
        private System.Windows.Forms.Label labelNrMinute;
    }
}