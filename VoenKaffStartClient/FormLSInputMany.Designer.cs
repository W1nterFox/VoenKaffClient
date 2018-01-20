namespace VoenKaffStartClient
{
    partial class FormLSInputMany
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxLS = new System.Windows.Forms.RichTextBox();
            this.buttonRichTextBoxAddLS = new System.Windows.Forms.Button();
            this.buttonRichTextBoxClear = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonRichTextBoxClear);
            this.panel1.Controls.Add(this.buttonRichTextBoxAddLS);
            this.panel1.Controls.Add(this.richTextBoxLS);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 522);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.label1.Location = new System.Drawing.Point(245, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите ФИО \r\n1 строка = 1 ФИО";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBoxLS
            // 
            this.richTextBoxLS.Location = new System.Drawing.Point(4, 86);
            this.richTextBoxLS.Name = "richTextBoxLS";
            this.richTextBoxLS.Size = new System.Drawing.Size(652, 382);
            this.richTextBoxLS.TabIndex = 1;
            this.richTextBoxLS.Text = "";
            this.richTextBoxLS.TextChanged += new System.EventHandler(this.richTextBoxLS_TextChanged);
            // 
            // buttonRichTextBoxAddLS
            // 
            this.buttonRichTextBoxAddLS.Enabled = false;
            this.buttonRichTextBoxAddLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRichTextBoxAddLS.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.buttonRichTextBoxAddLS.Location = new System.Drawing.Point(126, 474);
            this.buttonRichTextBoxAddLS.Name = "buttonRichTextBoxAddLS";
            this.buttonRichTextBoxAddLS.Size = new System.Drawing.Size(140, 45);
            this.buttonRichTextBoxAddLS.TabIndex = 2;
            this.buttonRichTextBoxAddLS.Text = "Добавить";
            this.buttonRichTextBoxAddLS.UseVisualStyleBackColor = true;
            this.buttonRichTextBoxAddLS.Click += new System.EventHandler(this.buttonRichTextBoxAddLS_Click);
            // 
            // buttonRichTextBoxClear
            // 
            this.buttonRichTextBoxClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRichTextBoxClear.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.buttonRichTextBoxClear.Location = new System.Drawing.Point(272, 474);
            this.buttonRichTextBoxClear.Name = "buttonRichTextBoxClear";
            this.buttonRichTextBoxClear.Size = new System.Drawing.Size(140, 45);
            this.buttonRichTextBoxClear.TabIndex = 3;
            this.buttonRichTextBoxClear.Text = "Очистить";
            this.buttonRichTextBoxClear.UseVisualStyleBackColor = true;
            this.buttonRichTextBoxClear.Click += new System.EventHandler(this.buttonRichTextBoxClear_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.buttonCancel.Location = new System.Drawing.Point(418, 474);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(140, 45);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormLSInputMany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 547);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "FormLSInputMany";
            this.Text = "FormLSInputMany";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRichTextBoxAddLS;
        private System.Windows.Forms.RichTextBox richTextBoxLS;
        private System.Windows.Forms.Button buttonRichTextBoxClear;
        private System.Windows.Forms.Button buttonCancel;
    }
}