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
            this.panel1.SuspendLayout();
            this.chooseMode.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 333);
            this.panel1.TabIndex = 0;
            // 
            // buttonInstruction
            // 
            this.buttonInstruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstruction.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonInstruction.Location = new System.Drawing.Point(276, 266);
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
            this.startButton.Location = new System.Drawing.Point(257, 215);
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
            this.chooseMode.Location = new System.Drawing.Point(208, 127);
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
            this.FIOName.Location = new System.Drawing.Point(434, 100);
            this.FIOName.Name = "FIOName";
            this.FIOName.Size = new System.Drawing.Size(180, 21);
            this.FIOName.TabIndex = 5;
            // 
            // vzvodName
            // 
            this.vzvodName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vzvodName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vzvodName.FormattingEnabled = true;
            this.vzvodName.Location = new System.Drawing.Point(248, 100);
            this.vzvodName.Name = "vzvodName";
            this.vzvodName.Size = new System.Drawing.Size(180, 21);
            this.vzvodName.TabIndex = 3;
            // 
            // testName
            // 
            this.testName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.testName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testName.FormattingEnabled = true;
            this.testName.Location = new System.Drawing.Point(62, 100);
            this.testName.Name = "testName";
            this.testName.Size = new System.Drawing.Size(180, 21);
            this.testName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label4.Location = new System.Drawing.Point(439, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Выберите стедуента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label3.Location = new System.Drawing.Point(274, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выберите взвод";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label2.Location = new System.Drawing.Point(92, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите тест";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(192, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тестирование нормативов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 358);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.chooseMode.ResumeLayout(false);
            this.chooseMode.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

