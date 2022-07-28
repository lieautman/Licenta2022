
namespace FrontDeskManagement
{
    partial class FormAbonament
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbonament));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbTipAbonament = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.labelRezulatat = new System.Windows.Forms.Label();
            this.labelDataStart = new System.Windows.Forms.Label();
            this.labelrecurring = new System.Windows.Forms.Label();
            this.cbReccuring = new System.Windows.Forms.CheckBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrontDeskManagement.Properties.Resources.loginImg;
            this.pictureBox1.Location = new System.Drawing.Point(12, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // cbTipAbonament
            // 
            this.cbTipAbonament.FormattingEnabled = true;
            this.cbTipAbonament.Location = new System.Drawing.Point(419, 77);
            this.cbTipAbonament.Name = "cbTipAbonament";
            this.cbTipAbonament.Size = new System.Drawing.Size(335, 28);
            this.cbTipAbonament.TabIndex = 12;
            this.cbTipAbonament.SelectedIndexChanged += new System.EventHandler(this.cbTipAbonament_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tipul abonamentului:";
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(419, 140);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(335, 28);
            this.cbClient.TabIndex = 14;
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Clientul:";
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(499, 275);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(194, 59);
            this.btnSalveaza.TabIndex = 16;
            this.btnSalveaza.Text = "Asociaza";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // labelRezulatat
            // 
            this.labelRezulatat.AutoSize = true;
            this.labelRezulatat.Location = new System.Drawing.Point(586, 337);
            this.labelRezulatat.Name = "labelRezulatat";
            this.labelRezulatat.Size = new System.Drawing.Size(0, 20);
            this.labelRezulatat.TabIndex = 17;
            // 
            // labelDataStart
            // 
            this.labelDataStart.AutoSize = true;
            this.labelDataStart.Location = new System.Drawing.Point(419, 175);
            this.labelDataStart.Name = "labelDataStart";
            this.labelDataStart.Size = new System.Drawing.Size(126, 20);
            this.labelDataStart.TabIndex = 18;
            this.labelDataStart.Text = "Data de incepere:";
            // 
            // labelrecurring
            // 
            this.labelrecurring.AutoSize = true;
            this.labelrecurring.Location = new System.Drawing.Point(419, 231);
            this.labelrecurring.Name = "labelrecurring";
            this.labelrecurring.Size = new System.Drawing.Size(77, 20);
            this.labelrecurring.TabIndex = 19;
            this.labelrecurring.Text = "Reccuring:";
            // 
            // cbReccuring
            // 
            this.cbReccuring.AutoSize = true;
            this.cbReccuring.Location = new System.Drawing.Point(499, 234);
            this.cbReccuring.Name = "cbReccuring";
            this.cbReccuring.Size = new System.Drawing.Size(18, 17);
            this.cbReccuring.TabIndex = 20;
            this.cbReccuring.UseVisualStyleBackColor = true;
            this.cbReccuring.CheckedChanged += new System.EventHandler(this.cbReccuring_CheckedChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(419, 201);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(335, 27);
            this.datePicker.TabIndex = 21;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // FormAbonament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.cbReccuring);
            this.Controls.Add(this.labelrecurring);
            this.Controls.Add(this.labelDataStart);
            this.Controls.Add(this.labelRezulatat);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTipAbonament);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAbonament";
            this.Text = "Form Abonament";
            this.Load += new System.EventHandler(this.FormAbonament_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormAbonament_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbTipAbonament;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Label labelRezulatat;
        private System.Windows.Forms.Label labelDataStart;
        private System.Windows.Forms.Label labelrecurring;
        private System.Windows.Forms.CheckBox cbReccuring;
        private System.Windows.Forms.DateTimePicker datePicker;
    }
}