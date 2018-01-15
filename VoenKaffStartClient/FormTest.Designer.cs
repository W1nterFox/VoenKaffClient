namespace VoenKaffStartClient
{
    partial class FormTest
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
            this.panelTask = new System.Windows.Forms.Panel();
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.panelAnswers = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFIOName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTask.SuspendLayout();
            this.panelQuestion.SuspendLayout();
            this.panelAnswers.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTask
            // 
            this.panelTask.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTask.Controls.Add(this.panelAnswers);
            this.panelTask.Controls.Add(this.panelQuestion);
            this.panelTask.Location = new System.Drawing.Point(16, 16);
            this.panelTask.Name = "panelTask";
            this.panelTask.Size = new System.Drawing.Size(929, 677);
            this.panelTask.TabIndex = 0;
            this.panelTask.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // panelQuestion
            // 
            this.panelQuestion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelQuestion.Controls.Add(this.label2);
            this.panelQuestion.Location = new System.Drawing.Point(3, 3);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(923, 494);
            this.panelQuestion.TabIndex = 0;
            // 
            // panelAnswers
            // 
            this.panelAnswers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelAnswers.Controls.Add(this.label1);
            this.panelAnswers.Controls.Add(this.textBox6);
            this.panelAnswers.Controls.Add(this.textBox5);
            this.panelAnswers.Controls.Add(this.textBox4);
            this.panelAnswers.Controls.Add(this.textBox3);
            this.panelAnswers.Controls.Add(this.textBox2);
            this.panelAnswers.Controls.Add(this.textBox1);
            this.panelAnswers.Controls.Add(this.button1);
            this.panelAnswers.Location = new System.Drawing.Point(6, 503);
            this.panelAnswers.Name = "panelAnswers";
            this.panelAnswers.Size = new System.Drawing.Size(920, 171);
            this.panelAnswers.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelFIOName,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 699);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(960, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(163, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabeltestName";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(176, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabelVzvodName";
            // 
            // toolStripStatusLabelFIOName
            // 
            this.toolStripStatusLabelFIOName.Name = "toolStripStatusLabelFIOName";
            this.toolStripStatusLabelFIOName.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabelFIOName.Text = "toolStripStatusLabel";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(257, 17);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabelTaskNumberAndTaskCount";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.button1.Location = new System.Drawing.Point(415, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ответить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(63, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(188, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(312, 64);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(433, 64);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(557, 64);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(678, 64);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Типа поля для ответов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Тут типа все контроллеры из панели с заданием";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMain.Location = new System.Drawing.Point(13, 13);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(935, 683);
            this.panelMain.TabIndex = 2;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 721);
            this.Controls.Add(this.panelTask);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.panelTask.ResumeLayout(false);
            this.panelQuestion.ResumeLayout(false);
            this.panelQuestion.PerformLayout();
            this.panelAnswers.ResumeLayout(false);
            this.panelAnswers.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTask;
        private System.Windows.Forms.Panel panelAnswers;
        private System.Windows.Forms.Panel panelQuestion;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFIOName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelMain;
    }
}