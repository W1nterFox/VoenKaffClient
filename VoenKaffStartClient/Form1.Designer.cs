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
            this.comboBoxChooseCourse = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.chooseMode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.comboBoxChooseCourse);
            this.panel1.Controls.Add(this.label5);
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
            this.panel1.Location = new System.Drawing.Point(13, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 319);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxChooseCourse
            // 
            this.comboBoxChooseCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxChooseCourse.FormattingEnabled = true;
            this.comboBoxChooseCourse.Location = new System.Drawing.Point(28, 101);
            this.comboBoxChooseCourse.Name = "comboBoxChooseCourse";
            this.comboBoxChooseCourse.Size = new System.Drawing.Size(180, 21);
            this.comboBoxChooseCourse.TabIndex = 10;
            this.comboBoxChooseCourse.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseCourse_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label5.Location = new System.Drawing.Point(45, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Выберите предмет";
            // 
            // buttonInstruction
            // 
            this.buttonInstruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstruction.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonInstruction.Location = new System.Drawing.Point(339, 268);
            this.buttonInstruction.Name = "buttonInstruction";
            this.buttonInstruction.Size = new System.Drawing.Size(124, 38);
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
            this.startButton.Location = new System.Drawing.Point(320, 217);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(162, 45);
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
            this.chooseMode.Location = new System.Drawing.Point(271, 129);
            this.chooseMode.Name = "chooseMode";
            this.chooseMode.Size = new System.Drawing.Size(250, 82);
            this.chooseMode.TabIndex = 7;
            this.chooseMode.TabStop = false;
            // 
            // radioButtonTestModeStudy
            // 
            this.radioButtonTestModeStudy.AutoSize = true;
            this.radioButtonTestModeStudy.Location = new System.Drawing.Point(41, 49);
            this.radioButtonTestModeStudy.Name = "radioButtonTestModeStudy";
            this.radioButtonTestModeStudy.Size = new System.Drawing.Size(144, 24);
            this.radioButtonTestModeStudy.TabIndex = 1;
            this.radioButtonTestModeStudy.TabStop = true;
            this.radioButtonTestModeStudy.Text = "Режим обучения";
            this.radioButtonTestModeStudy.UseVisualStyleBackColor = true;
            // 
            // radioButtonTestModeTest
            // 
            this.radioButtonTestModeTest.AutoSize = true;
            this.radioButtonTestModeTest.Location = new System.Drawing.Point(41, 19);
            this.radioButtonTestModeTest.Name = "radioButtonTestModeTest";
            this.radioButtonTestModeTest.Size = new System.Drawing.Size(174, 24);
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
            this.FIOName.Location = new System.Drawing.Point(588, 101);
            this.FIOName.Name = "FIOName";
            this.FIOName.Size = new System.Drawing.Size(180, 21);
            this.FIOName.TabIndex = 5;
            // 
            // vzvodName
            // 
            this.vzvodName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vzvodName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vzvodName.FormattingEnabled = true;
            this.vzvodName.Location = new System.Drawing.Point(402, 101);
            this.vzvodName.Name = "vzvodName";
            this.vzvodName.Size = new System.Drawing.Size(180, 21);
            this.vzvodName.TabIndex = 3;
            // 
            // testName
            // 
            this.testName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.testName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.testName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testName.FormattingEnabled = true;
            this.testName.Location = new System.Drawing.Point(216, 101);
            this.testName.Name = "testName";
            this.testName.Size = new System.Drawing.Size(180, 21);
            this.testName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label4.Location = new System.Drawing.Point(593, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Выберите студента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label3.Location = new System.Drawing.Point(428, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выберите взвод";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label2.Location = new System.Drawing.Point(246, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите тест";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(255, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тестирование знаний";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Settings
            // 
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(79, 20);
            this.Settings.Text = "Настройки";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 358);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Тестирование знаний";
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
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.ComboBox comboBoxChooseCourse;
        private System.Windows.Forms.Label label5;
    }
}

