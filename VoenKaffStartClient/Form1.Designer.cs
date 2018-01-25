namespace VoenKaffStartClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonInstruction = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.chooseMode = new System.Windows.Forms.GroupBox();
            this.radioButtonTestModeStudy = new System.Windows.Forms.RadioButton();
            this.radioButtonTestModeTest = new System.Windows.Forms.RadioButton();
            this.FIOName = new System.Windows.Forms.ComboBox();
            this.vzvodName = new System.Windows.Forms.ComboBox();
            this.testName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.закрытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.chooseMode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.buttonInstruction);
            this.panel1.Controls.Add(this.startButton);
            this.panel1.Controls.Add(this.chooseMode);
            this.panel1.Controls.Add(this.FIOName);
            this.panel1.Controls.Add(this.vzvodName);
            this.panel1.Controls.Add(this.testName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(17, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 393);
            this.panel1.TabIndex = 0;
            // 
            // buttonInstruction
            // 
            this.buttonInstruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstruction.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonInstruction.Location = new System.Drawing.Point(368, 327);
            this.buttonInstruction.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInstruction.Name = "buttonInstruction";
            this.buttonInstruction.Size = new System.Drawing.Size(165, 47);
            this.buttonInstruction.TabIndex = 9;
            this.buttonInstruction.Text = "Инструкция";
            this.buttonInstruction.UseVisualStyleBackColor = true;
            this.buttonInstruction.Click += new System.EventHandler(this.buttonInstruction_Click);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.startButton.Location = new System.Drawing.Point(343, 265);
            this.startButton.Margin = new System.Windows.Forms.Padding(4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(216, 55);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Начать тест";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // chooseMode
            // 
            this.chooseMode.Controls.Add(this.radioButtonTestModeStudy);
            this.chooseMode.Controls.Add(this.radioButtonTestModeTest);
            this.chooseMode.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.chooseMode.Location = new System.Drawing.Point(277, 156);
            this.chooseMode.Margin = new System.Windows.Forms.Padding(4);
            this.chooseMode.Name = "chooseMode";
            this.chooseMode.Padding = new System.Windows.Forms.Padding(4);
            this.chooseMode.Size = new System.Drawing.Size(333, 101);
            this.chooseMode.TabIndex = 7;
            this.chooseMode.TabStop = false;
            // 
            // radioButtonTestModeStudy
            // 
            this.radioButtonTestModeStudy.AutoSize = true;
            this.radioButtonTestModeStudy.Location = new System.Drawing.Point(55, 60);
            this.radioButtonTestModeStudy.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonTestModeStudy.Name = "radioButtonTestModeStudy";
            this.radioButtonTestModeStudy.Size = new System.Drawing.Size(191, 26);
            this.radioButtonTestModeStudy.TabIndex = 1;
            this.radioButtonTestModeStudy.TabStop = true;
            this.radioButtonTestModeStudy.Text = "Режим обучения";
            this.radioButtonTestModeStudy.UseVisualStyleBackColor = true;
            // 
            // radioButtonTestModeTest
            // 
            this.radioButtonTestModeTest.AutoSize = true;
            this.radioButtonTestModeTest.Location = new System.Drawing.Point(55, 23);
            this.radioButtonTestModeTest.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonTestModeTest.Name = "radioButtonTestModeTest";
            this.radioButtonTestModeTest.Size = new System.Drawing.Size(231, 26);
            this.radioButtonTestModeTest.TabIndex = 0;
            this.radioButtonTestModeTest.TabStop = true;
            this.radioButtonTestModeTest.Text = "Режим тестирования";
            this.radioButtonTestModeTest.UseVisualStyleBackColor = true;
            // 
            // FIOName
            // 
            this.FIOName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FIOName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FIOName.FormattingEnabled = true;
            this.FIOName.Location = new System.Drawing.Point(579, 123);
            this.FIOName.Margin = new System.Windows.Forms.Padding(4);
            this.FIOName.Name = "FIOName";
            this.FIOName.Size = new System.Drawing.Size(239, 24);
            this.FIOName.TabIndex = 5;
            // 
            // vzvodName
            // 
            this.vzvodName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vzvodName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vzvodName.FormattingEnabled = true;
            this.vzvodName.Location = new System.Drawing.Point(331, 123);
            this.vzvodName.Margin = new System.Windows.Forms.Padding(4);
            this.vzvodName.Name = "vzvodName";
            this.vzvodName.Size = new System.Drawing.Size(239, 24);
            this.vzvodName.TabIndex = 3;
            // 
            // testName
            // 
            this.testName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.testName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testName.FormattingEnabled = true;
            this.testName.Location = new System.Drawing.Point(83, 123);
            this.testName.Margin = new System.Windows.Forms.Padding(4);
            this.testName.Name = "testName";
            this.testName.Size = new System.Drawing.Size(239, 24);
            this.testName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label4.Location = new System.Drawing.Point(585, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Выберите стедуента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label3.Location = new System.Drawing.Point(365, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выберите взвод";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label2.Location = new System.Drawing.Point(123, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите тест";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(256, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тестирование нормативов";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem1,
            this.Settings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(921, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // закрытьToolStripMenuItem1
            // 
            this.закрытьToolStripMenuItem1.Name = "закрытьToolStripMenuItem1";
            this.закрытьToolStripMenuItem1.Size = new System.Drawing.Size(78, 24);
            this.закрытьToolStripMenuItem1.Text = "Закрыть";
            this.закрытьToolStripMenuItem1.Click += new System.EventHandler(this.закрытьToolStripMenuItem1_Click);
            // 
            // Settings
            // 
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(96, 24);
            this.Settings.Text = "Настройки";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 441);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.chooseMode.ResumeLayout(false);
            this.chooseMode.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FIOName;
        private System.Windows.Forms.ComboBox vzvodName;
        private System.Windows.Forms.ComboBox testName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox chooseMode;
        private System.Windows.Forms.RadioButton radioButtonTestModeStudy;
        private System.Windows.Forms.RadioButton radioButtonTestModeTest;
        private System.Windows.Forms.Button buttonInstruction;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Settings;
    }
}

