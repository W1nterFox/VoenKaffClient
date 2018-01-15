namespace VoenKaffStartClient
{
    partial class FormStudy
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
            this.panelRightAnswersAndUserButtons = new System.Windows.Forms.Panel();
            this.buttonAskQuestionNotRight = new System.Windows.Forms.Button();
            this.buttonAskQuestionMiddle = new System.Windows.Forms.Button();
            this.buttonAskQuestionRight = new System.Windows.Forms.Button();
            this.panelAnswersUserChooseRightOrNot = new System.Windows.Forms.Panel();
            this.panelAnswers = new System.Windows.Forms.Panel();
            this.buttonEndTest = new System.Windows.Forms.Button();
            this.buttonNextTask = new System.Windows.Forms.Button();
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTaskNumberAndTaskCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTask.SuspendLayout();
            this.panelRightAnswersAndUserButtons.SuspendLayout();
            this.panelAnswers.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTask
            // 
            this.panelTask.BackColor = System.Drawing.Color.White;
            this.panelTask.Controls.Add(this.panelRightAnswersAndUserButtons);
            this.panelTask.Controls.Add(this.panelAnswers);
            this.panelTask.Controls.Add(this.panelQuestion);
            this.panelTask.Location = new System.Drawing.Point(15, 15);
            this.panelTask.Name = "panelTask";
            this.panelTask.Size = new System.Drawing.Size(930, 882);
            this.panelTask.TabIndex = 0;
            // 
            // panelRightAnswersAndUserButtons
            // 
            this.panelRightAnswersAndUserButtons.BackColor = System.Drawing.Color.LightSlateGray;
            this.panelRightAnswersAndUserButtons.Controls.Add(this.buttonAskQuestionNotRight);
            this.panelRightAnswersAndUserButtons.Controls.Add(this.buttonAskQuestionMiddle);
            this.panelRightAnswersAndUserButtons.Controls.Add(this.buttonAskQuestionRight);
            this.panelRightAnswersAndUserButtons.Controls.Add(this.panelAnswersUserChooseRightOrNot);
            this.panelRightAnswersAndUserButtons.Location = new System.Drawing.Point(4, 683);
            this.panelRightAnswersAndUserButtons.Name = "panelRightAnswersAndUserButtons";
            this.panelRightAnswersAndUserButtons.Size = new System.Drawing.Size(920, 196);
            this.panelRightAnswersAndUserButtons.TabIndex = 3;
            // 
            // buttonAskQuestionNotRight
            // 
            this.buttonAskQuestionNotRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonAskQuestionNotRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAskQuestionNotRight.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonAskQuestionNotRight.Location = new System.Drawing.Point(609, 111);
            this.buttonAskQuestionNotRight.Name = "buttonAskQuestionNotRight";
            this.buttonAskQuestionNotRight.Size = new System.Drawing.Size(160, 55);
            this.buttonAskQuestionNotRight.TabIndex = 5;
            this.buttonAskQuestionNotRight.Text = "Ответил неверно";
            this.buttonAskQuestionNotRight.UseVisualStyleBackColor = false;
            // 
            // buttonAskQuestionMiddle
            // 
            this.buttonAskQuestionMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonAskQuestionMiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAskQuestionMiddle.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonAskQuestionMiddle.Location = new System.Drawing.Point(352, 111);
            this.buttonAskQuestionMiddle.Name = "buttonAskQuestionMiddle";
            this.buttonAskQuestionMiddle.Size = new System.Drawing.Size(231, 55);
            this.buttonAskQuestionMiddle.TabIndex = 4;
            this.buttonAskQuestionMiddle.Text = "Ответил неувернно, наугад или с чужой помощью";
            this.buttonAskQuestionMiddle.UseVisualStyleBackColor = false;
            // 
            // buttonAskQuestionRight
            // 
            this.buttonAskQuestionRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonAskQuestionRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAskQuestionRight.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonAskQuestionRight.ForeColor = System.Drawing.Color.Black;
            this.buttonAskQuestionRight.Location = new System.Drawing.Point(161, 111);
            this.buttonAskQuestionRight.Name = "buttonAskQuestionRight";
            this.buttonAskQuestionRight.Size = new System.Drawing.Size(160, 55);
            this.buttonAskQuestionRight.TabIndex = 3;
            this.buttonAskQuestionRight.Text = "Ответил верно";
            this.buttonAskQuestionRight.UseVisualStyleBackColor = false;
            // 
            // panelAnswersUserChooseRightOrNot
            // 
            this.panelAnswersUserChooseRightOrNot.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelAnswersUserChooseRightOrNot.Location = new System.Drawing.Point(3, 3);
            this.panelAnswersUserChooseRightOrNot.Name = "panelAnswersUserChooseRightOrNot";
            this.panelAnswersUserChooseRightOrNot.Size = new System.Drawing.Size(914, 89);
            this.panelAnswersUserChooseRightOrNot.TabIndex = 2;
            // 
            // panelAnswers
            // 
            this.panelAnswers.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelAnswers.Controls.Add(this.buttonEndTest);
            this.panelAnswers.Controls.Add(this.buttonNextTask);
            this.panelAnswers.Location = new System.Drawing.Point(4, 572);
            this.panelAnswers.Name = "panelAnswers";
            this.panelAnswers.Size = new System.Drawing.Size(920, 104);
            this.panelAnswers.TabIndex = 1;
            // 
            // buttonEndTest
            // 
            this.buttonEndTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEndTest.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonEndTest.Location = new System.Drawing.Point(29, 59);
            this.buttonEndTest.Name = "buttonEndTest";
            this.buttonEndTest.Size = new System.Drawing.Size(143, 42);
            this.buttonEndTest.TabIndex = 8;
            this.buttonEndTest.Text = "Закончить тест";
            this.buttonEndTest.UseVisualStyleBackColor = true;
            this.buttonEndTest.Click += new System.EventHandler(this.buttonEndTest_Click);
            // 
            // buttonNextTask
            // 
            this.buttonNextTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextTask.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonNextTask.Location = new System.Drawing.Point(406, 59);
            this.buttonNextTask.Name = "buttonNextTask";
            this.buttonNextTask.Size = new System.Drawing.Size(106, 42);
            this.buttonNextTask.TabIndex = 0;
            this.buttonNextTask.Text = "Проверить";
            this.buttonNextTask.UseVisualStyleBackColor = true;
            this.buttonNextTask.Click += new System.EventHandler(this.buttonNextTask_Click);
            // 
            // panelQuestion
            // 
            this.panelQuestion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelQuestion.Location = new System.Drawing.Point(4, 4);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(923, 561);
            this.panelQuestion.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTaskNumberAndTaskCount,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 903);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(960, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelTaskNumberAndTaskCount
            // 
            this.toolStripStatusLabelTaskNumberAndTaskCount.Name = "toolStripStatusLabelTaskNumberAndTaskCount";
            this.toolStripStatusLabelTaskNumberAndTaskCount.Size = new System.Drawing.Size(160, 17);
            this.toolStripStatusLabelTaskNumberAndTaskCount.Text = "Выполнено заданий: 0 из 30";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMain.Location = new System.Drawing.Point(12, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(936, 888);
            this.panelMain.TabIndex = 2;
            // 
            // FormStudy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 925);
            this.Controls.Add(this.panelTask);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormStudy";
            this.Text = "FormStudy";
            this.panelTask.ResumeLayout(false);
            this.panelRightAnswersAndUserButtons.ResumeLayout(false);
            this.panelAnswers.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTask;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTaskNumberAndTaskCount;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Panel panelQuestion;
        private System.Windows.Forms.Panel panelAnswers;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelAnswersUserChooseRightOrNot;
        private System.Windows.Forms.Panel panelRightAnswersAndUserButtons;
        private System.Windows.Forms.Button buttonAskQuestionRight;
        private System.Windows.Forms.Button buttonAskQuestionNotRight;
        private System.Windows.Forms.Button buttonAskQuestionMiddle;
        private System.Windows.Forms.Button buttonNextTask;
        private System.Windows.Forms.Button buttonEndTest;
    }
}