
namespace FrontDeskManagement
{
    partial class Employee_page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee_page));
            this.labelMesaj = new System.Windows.Forms.Label();
            this.btnFormularClient = new System.Windows.Forms.Button();
            this.btnFormularAbonament = new System.Windows.Forms.Button();
            this.btnFormularExtraoptiuni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMesaj
            // 
            this.labelMesaj.AutoSize = true;
            this.labelMesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMesaj.Location = new System.Drawing.Point(171, 47);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(450, 22);
            this.labelMesaj.TabIndex = 0;
            this.labelMesaj.Text = "Dati click pe butonul cu formularul ce trebuie completat!";
            // 
            // btnFormularClient
            // 
            this.btnFormularClient.Location = new System.Drawing.Point(52, 177);
            this.btnFormularClient.Name = "btnFormularClient";
            this.btnFormularClient.Size = new System.Drawing.Size(147, 68);
            this.btnFormularClient.TabIndex = 1;
            this.btnFormularClient.Text = "Formular client";
            this.btnFormularClient.UseVisualStyleBackColor = true;
            this.btnFormularClient.Click += new System.EventHandler(this.btnFormularClient_Click);
            this.btnFormularClient.MouseEnter += new System.EventHandler(this.btnFormularClient_MouseEnter);
            this.btnFormularClient.MouseLeave += new System.EventHandler(this.btnFormularClient_MouseLeave);
            // 
            // btnFormularAbonament
            // 
            this.btnFormularAbonament.Location = new System.Drawing.Point(323, 177);
            this.btnFormularAbonament.Name = "btnFormularAbonament";
            this.btnFormularAbonament.Size = new System.Drawing.Size(147, 68);
            this.btnFormularAbonament.TabIndex = 2;
            this.btnFormularAbonament.Text = "Formular Abonament";
            this.btnFormularAbonament.UseVisualStyleBackColor = true;
            this.btnFormularAbonament.Click += new System.EventHandler(this.btnFormularAbonament_Click);
            this.btnFormularAbonament.MouseEnter += new System.EventHandler(this.btnFormularAbonament_MouseEnter);
            this.btnFormularAbonament.MouseLeave += new System.EventHandler(this.btnFormularAbonament_MouseLeave);
            // 
            // btnFormularExtraoptiuni
            // 
            this.btnFormularExtraoptiuni.Location = new System.Drawing.Point(594, 177);
            this.btnFormularExtraoptiuni.Name = "btnFormularExtraoptiuni";
            this.btnFormularExtraoptiuni.Size = new System.Drawing.Size(147, 68);
            this.btnFormularExtraoptiuni.TabIndex = 3;
            this.btnFormularExtraoptiuni.Text = "Formular Extraoptiuni";
            this.btnFormularExtraoptiuni.UseVisualStyleBackColor = true;
            this.btnFormularExtraoptiuni.Click += new System.EventHandler(this.btnFormularExtraoptiuni_Click);
            this.btnFormularExtraoptiuni.MouseEnter += new System.EventHandler(this.btnFormularExtraoptiuni_MouseEnter);
            this.btnFormularExtraoptiuni.MouseLeave += new System.EventHandler(this.btnFormularExtraoptiuni_MouseLeave);
            // 
            // Employee_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFormularExtraoptiuni);
            this.Controls.Add(this.btnFormularAbonament);
            this.Controls.Add(this.btnFormularClient);
            this.Controls.Add(this.labelMesaj);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Employee_page";
            this.Text = "Employee page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMesaj;
        private System.Windows.Forms.Button btnFormularClient;
        private System.Windows.Forms.Button btnFormularAbonament;
        private System.Windows.Forms.Button btnFormularExtraoptiuni;
    }
}