﻿namespace VoenKaffStartClient
{
    partial class FormSettings
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
            this.IpAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IpAddress
            // 
            this.IpAddress.Location = new System.Drawing.Point(193, 49);
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.Size = new System.Drawing.Size(250, 22);
            this.IpAddress.TabIndex = 0;
            this.IpAddress.Leave += new System.EventHandler(this.IpAddress_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Адрес сервера:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Порт сервера:";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(193, 91);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(74, 22);
            this.Port.TabIndex = 3;
            this.Port.Leave += new System.EventHandler(this.Port_Leave);
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(227, 233);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(161, 64);
            this.Close.TabIndex = 4;
            this.Close.Text = "Закрыть";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 362);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IpAddress);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IpAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Button Close;
    }
}