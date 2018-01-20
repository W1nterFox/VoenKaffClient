namespace VoenKaffStartClient
{
    partial class FormPlatoon
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonLSAddMany = new System.Windows.Forms.Button();
            this.buttonLSSort = new System.Windows.Forms.Button();
            this.buttonLSClear = new System.Windows.Forms.Button();
            this.buttonLSDelete = new System.Windows.Forms.Button();
            this.buttonLSAdd = new System.Windows.Forms.Button();
            this.textBoxLicnySostav = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxLS = new System.Windows.Forms.ListBox();
            this.buttonVzvodSort = new System.Windows.Forms.Button();
            this.buttonVzvodClear = new System.Windows.Forms.Button();
            this.buttonVzvodDelete = new System.Windows.Forms.Button();
            this.buttonVzvodAdd = new System.Windows.Forms.Button();
            this.textBoxVzvoda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxVzvoda = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonLSAddMany);
            this.panel1.Controls.Add(this.buttonLSSort);
            this.panel1.Controls.Add(this.buttonLSClear);
            this.panel1.Controls.Add(this.buttonLSDelete);
            this.panel1.Controls.Add(this.buttonLSAdd);
            this.panel1.Controls.Add(this.textBoxLicnySostav);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listBoxLS);
            this.panel1.Controls.Add(this.buttonVzvodSort);
            this.panel1.Controls.Add(this.buttonVzvodClear);
            this.panel1.Controls.Add(this.buttonVzvodDelete);
            this.panel1.Controls.Add(this.buttonVzvodAdd);
            this.panel1.Controls.Add(this.textBoxVzvoda);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBoxVzvoda);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 444);
            this.panel1.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.buttonClose.Location = new System.Drawing.Point(297, 379);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(140, 45);
            this.buttonClose.TabIndex = 15;
            this.buttonClose.Text = "Сохранить";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonLSAddMany
            // 
            this.buttonLSAddMany.Enabled = false;
            this.buttonLSAddMany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLSAddMany.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonLSAddMany.Location = new System.Drawing.Point(600, 315);
            this.buttonLSAddMany.Name = "buttonLSAddMany";
            this.buttonLSAddMany.Size = new System.Drawing.Size(110, 58);
            this.buttonLSAddMany.TabIndex = 14;
            this.buttonLSAddMany.Text = "Добавить сразу много";
            this.buttonLSAddMany.UseVisualStyleBackColor = true;
            this.buttonLSAddMany.Click += new System.EventHandler(this.buttonLSAddMany_Click);
            // 
            // buttonLSSort
            // 
            this.buttonLSSort.Enabled = false;
            this.buttonLSSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLSSort.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonLSSort.Location = new System.Drawing.Point(600, 168);
            this.buttonLSSort.Name = "buttonLSSort";
            this.buttonLSSort.Size = new System.Drawing.Size(110, 35);
            this.buttonLSSort.TabIndex = 13;
            this.buttonLSSort.Text = "Сортировать";
            this.buttonLSSort.UseVisualStyleBackColor = true;
            this.buttonLSSort.Click += new System.EventHandler(this.buttonLSSort_Click);
            // 
            // buttonLSClear
            // 
            this.buttonLSClear.Enabled = false;
            this.buttonLSClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLSClear.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonLSClear.Location = new System.Drawing.Point(600, 127);
            this.buttonLSClear.Name = "buttonLSClear";
            this.buttonLSClear.Size = new System.Drawing.Size(110, 35);
            this.buttonLSClear.TabIndex = 12;
            this.buttonLSClear.Text = "Очистить";
            this.buttonLSClear.UseVisualStyleBackColor = true;
            this.buttonLSClear.Click += new System.EventHandler(this.buttonLSClear_Click);
            // 
            // buttonLSDelete
            // 
            this.buttonLSDelete.Enabled = false;
            this.buttonLSDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLSDelete.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonLSDelete.Location = new System.Drawing.Point(600, 86);
            this.buttonLSDelete.Name = "buttonLSDelete";
            this.buttonLSDelete.Size = new System.Drawing.Size(110, 35);
            this.buttonLSDelete.TabIndex = 11;
            this.buttonLSDelete.Text = "Удалить";
            this.buttonLSDelete.UseVisualStyleBackColor = true;
            this.buttonLSDelete.Click += new System.EventHandler(this.buttonLSDelete_Click);
            // 
            // buttonLSAdd
            // 
            this.buttonLSAdd.Enabled = false;
            this.buttonLSAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLSAdd.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonLSAdd.Location = new System.Drawing.Point(600, 45);
            this.buttonLSAdd.Name = "buttonLSAdd";
            this.buttonLSAdd.Size = new System.Drawing.Size(110, 35);
            this.buttonLSAdd.TabIndex = 10;
            this.buttonLSAdd.Text = "Добавить";
            this.buttonLSAdd.UseVisualStyleBackColor = true;
            this.buttonLSAdd.Click += new System.EventHandler(this.buttonLSAdd_Click);
            // 
            // textBoxLicnySostav
            // 
            this.textBoxLicnySostav.Enabled = false;
            this.textBoxLicnySostav.Location = new System.Drawing.Point(367, 45);
            this.textBoxLicnySostav.Name = "textBoxLicnySostav";
            this.textBoxLicnySostav.Size = new System.Drawing.Size(227, 20);
            this.textBoxLicnySostav.TabIndex = 9;
            this.textBoxLicnySostav.TextChanged += new System.EventHandler(this.textBoxLicnySostav_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.label2.Location = new System.Drawing.Point(411, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Личный состав";
            // 
            // listBoxLS
            // 
            this.listBoxLS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxLS.Enabled = false;
            this.listBoxLS.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.listBoxLS.FormattingEnabled = true;
            this.listBoxLS.ItemHeight = 20;
            this.listBoxLS.Location = new System.Drawing.Point(367, 71);
            this.listBoxLS.Name = "listBoxLS";
            this.listBoxLS.Size = new System.Drawing.Size(227, 302);
            this.listBoxLS.TabIndex = 7;
            this.listBoxLS.SelectedIndexChanged += new System.EventHandler(this.listBoxLS_SelectedIndexChanged);
            // 
            // buttonVzvodSort
            // 
            this.buttonVzvodSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVzvodSort.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonVzvodSort.Location = new System.Drawing.Point(18, 168);
            this.buttonVzvodSort.Name = "buttonVzvodSort";
            this.buttonVzvodSort.Size = new System.Drawing.Size(110, 35);
            this.buttonVzvodSort.TabIndex = 6;
            this.buttonVzvodSort.Text = "Сортировать";
            this.buttonVzvodSort.UseVisualStyleBackColor = true;
            this.buttonVzvodSort.Click += new System.EventHandler(this.buttonVzvodSort_Click);
            // 
            // buttonVzvodClear
            // 
            this.buttonVzvodClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVzvodClear.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonVzvodClear.Location = new System.Drawing.Point(18, 127);
            this.buttonVzvodClear.Name = "buttonVzvodClear";
            this.buttonVzvodClear.Size = new System.Drawing.Size(110, 35);
            this.buttonVzvodClear.TabIndex = 5;
            this.buttonVzvodClear.Text = "Очистить";
            this.buttonVzvodClear.UseVisualStyleBackColor = true;
            this.buttonVzvodClear.Click += new System.EventHandler(this.buttonVzvodClear_Click);
            // 
            // buttonVzvodDelete
            // 
            this.buttonVzvodDelete.Enabled = false;
            this.buttonVzvodDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVzvodDelete.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonVzvodDelete.Location = new System.Drawing.Point(18, 86);
            this.buttonVzvodDelete.Name = "buttonVzvodDelete";
            this.buttonVzvodDelete.Size = new System.Drawing.Size(110, 35);
            this.buttonVzvodDelete.TabIndex = 4;
            this.buttonVzvodDelete.Text = "Удалить";
            this.buttonVzvodDelete.UseVisualStyleBackColor = true;
            this.buttonVzvodDelete.Click += new System.EventHandler(this.buttonVzvodDelete_Click);
            // 
            // buttonVzvodAdd
            // 
            this.buttonVzvodAdd.Enabled = false;
            this.buttonVzvodAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVzvodAdd.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonVzvodAdd.Location = new System.Drawing.Point(18, 45);
            this.buttonVzvodAdd.Name = "buttonVzvodAdd";
            this.buttonVzvodAdd.Size = new System.Drawing.Size(110, 35);
            this.buttonVzvodAdd.TabIndex = 3;
            this.buttonVzvodAdd.Text = "Добавить";
            this.buttonVzvodAdd.UseVisualStyleBackColor = true;
            this.buttonVzvodAdd.Click += new System.EventHandler(this.buttonVzvodAdd_Click);
            // 
            // textBoxVzvoda
            // 
            this.textBoxVzvoda.Location = new System.Drawing.Point(134, 45);
            this.textBoxVzvoda.Name = "textBoxVzvoda";
            this.textBoxVzvoda.Size = new System.Drawing.Size(227, 20);
            this.textBoxVzvoda.TabIndex = 2;
            this.textBoxVzvoda.TextChanged += new System.EventHandler(this.textBoxVzvoda_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.label1.Location = new System.Drawing.Point(202, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Взвода";
            // 
            // listBoxVzvoda
            // 
            this.listBoxVzvoda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxVzvoda.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.listBoxVzvoda.FormattingEnabled = true;
            this.listBoxVzvoda.ItemHeight = 20;
            this.listBoxVzvoda.Location = new System.Drawing.Point(134, 71);
            this.listBoxVzvoda.Name = "listBoxVzvoda";
            this.listBoxVzvoda.Size = new System.Drawing.Size(227, 302);
            this.listBoxVzvoda.TabIndex = 0;
            // 
            // FormChooseVzvod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 468);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Name = "FormChooseVzvod";
            this.Text = "FormChooseVzvod";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxVzvoda;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonLSAddMany;
        private System.Windows.Forms.Button buttonLSSort;
        private System.Windows.Forms.Button buttonLSClear;
        private System.Windows.Forms.Button buttonLSDelete;
        private System.Windows.Forms.Button buttonLSAdd;
        private System.Windows.Forms.TextBox textBoxLicnySostav;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxLS;
        private System.Windows.Forms.Button buttonVzvodSort;
        private System.Windows.Forms.Button buttonVzvodClear;
        private System.Windows.Forms.Button buttonVzvodDelete;
        private System.Windows.Forms.Button buttonVzvodAdd;
        private System.Windows.Forms.TextBox textBoxVzvoda;
        private System.Windows.Forms.Label label1;
    }
}