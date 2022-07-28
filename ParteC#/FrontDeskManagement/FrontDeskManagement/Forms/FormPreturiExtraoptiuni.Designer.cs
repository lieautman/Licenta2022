
namespace FrontDeskManagement
{
    partial class FormPreturiExtraoptiuni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPreturiExtraoptiuni));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNrMinute = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMinute = new System.Windows.Forms.TextBox();
            this.tbMesaje = new System.Windows.Forms.TextBox();
            this.tbGbInternet = new System.Windows.Forms.TextBox();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.labelRezultat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrontDeskManagement.Properties.Resources.loginImg;
            this.pictureBox1.Location = new System.Drawing.Point(27, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Completati campurile urmatoare";
            // 
            // labelNrMinute
            // 
            this.labelNrMinute.AutoSize = true;
            this.labelNrMinute.Location = new System.Drawing.Point(456, 106);
            this.labelNrMinute.Name = "labelNrMinute";
            this.labelNrMinute.Size = new System.Drawing.Size(103, 20);
            this.labelNrMinute.TabIndex = 14;
            this.labelNrMinute.Text = "Pret per minut";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(456, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pret per mesaj";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Pret per gb internet";
            // 
            // tbMinute
            // 
            this.tbMinute.Location = new System.Drawing.Point(600, 103);
            this.tbMinute.Name = "tbMinute";
            this.tbMinute.Size = new System.Drawing.Size(125, 27);
            this.tbMinute.TabIndex = 17;
            this.tbMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMinute_KeyPress);
            // 
            // tbMesaje
            // 
            this.tbMesaje.Location = new System.Drawing.Point(600, 156);
            this.tbMesaje.Name = "tbMesaje";
            this.tbMesaje.Size = new System.Drawing.Size(125, 27);
            this.tbMesaje.TabIndex = 18;
            this.tbMesaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMesaje_KeyPress);
            // 
            // tbGbInternet
            // 
            this.tbGbInternet.Location = new System.Drawing.Point(600, 208);
            this.tbGbInternet.Name = "tbGbInternet";
            this.tbGbInternet.Size = new System.Drawing.Size(125, 27);
            this.tbGbInternet.TabIndex = 19;
            this.tbGbInternet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGbInternet_KeyPress);
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(503, 258);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(194, 59);
            this.btnSalveaza.TabIndex = 21;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // labelRezultat
            // 
            this.labelRezultat.AutoSize = true;
            this.labelRezultat.Location = new System.Drawing.Point(571, 320);
            this.labelRezultat.Name = "labelRezultat";
            this.labelRezultat.Size = new System.Drawing.Size(0, 20);
            this.labelRezultat.TabIndex = 22;
            // 
            // FormPreturiExtraoptiuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelRezultat);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.tbGbInternet);
            this.Controls.Add(this.tbMesaje);
            this.Controls.Add(this.tbMinute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNrMinute);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPreturiExtraoptiuni";
            this.Text = "Form Preturi Extraoptiuni";
            this.Load += new System.EventHandler(this.FormPreturiExtraoptiuni_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormPreturiExtraoptiuni_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNrMinute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMinute;
        private System.Windows.Forms.TextBox tbMesaje;
        private System.Windows.Forms.TextBox tbGbInternet;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Label labelRezultat;
    }
}