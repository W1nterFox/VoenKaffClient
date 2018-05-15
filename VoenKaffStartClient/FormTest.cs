
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VoenKaffStartClient.Properties;
using VoenKaffStartClient.Wrappers;
using System.Runtime.InteropServices;

namespace VoenKaffStartClient
{
    public partial class FormTest : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        private bool _backdoorMode = false;
        private string _btnCheckAnswersName = "btnCheckAnswers0";


        public string _currentTest;
        public string _currentVzvod;
        public string _currentStudent;
        public string _currentCourse;

        public Marks _marks = new Marks();
        //Коллекция тасков в тесте
        public List<Task> _listTasksInTest=new List<Task> { };
        public Dictionary<Task, List<Label>> _RTBInTask = new Dictionary<Task, List<Label>> { };
        public Dictionary<Task, List<PictureBox>> _PBInTask = new Dictionary<Task, List<PictureBox>> { };
        public Dictionary<Task, List<TextBox>> _TBInTask = new Dictionary<Task, List<TextBox>> { };
        public List<Panel> _listPanelTasks = new List<Panel> { };

        Button btnNextTask;
        Button btnEndTest;
        Button btnCheckAnswers;

        
        public Dictionary<Task, List<Label>> _listTBLabels = new Dictionary<Task, List<Label>> { };


        public int countRightAnswers;

        int currentTaskNum = 1;

        public FormTest(string currentTest, string currentVzvod, string currentStudent, string currentCourse)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            _currentTest = currentTest;
            _currentVzvod = currentVzvod;
            _currentStudent = currentStudent;
            _currentCourse = currentCourse;
            statusStrip1.BringToFront();
        }

        private void buttonEndTest_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        public void AddTestName(string name)
        {
            TestName.Text = name;
        }

        public void initTest(Test objectsInCurrentTest)
        {
            objectsInCurrentTest.Tasks = RandomSort<Task>.Sort(objectsInCurrentTest.Tasks);

            _marks = objectsInCurrentTest.Marks;

            foreach (Task paneltask in objectsInCurrentTest.Tasks)
            {
                
                _RTBInTask.Add(paneltask, new List<Label> { });
                _PBInTask.Add(paneltask, new List<PictureBox> { });
                _TBInTask.Add(paneltask, new List<TextBox> { });
                _listTBLabels.Add(paneltask, new List<Label> { });

                _listTasksInTest.Add(paneltask);

                

                foreach (TaskElement taskElem in paneltask.TaskElements)
                {
                    if (taskElem.Type.Equals("System.Windows.Forms.RichTextBox"))
                    {
                        _RTBInTask[paneltask].Add(new Label
                        {
                            Height = taskElem.Height,
                            Width = taskElem.Width,
                            Name = taskElem.Name,
                            Location = taskElem.Point,
                            Text = taskElem.Text,
                            Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),

                    });
                    }

                    if (taskElem.Type.Equals("System.Windows.Forms.PictureBox"))
                    {
                        _PBInTask[paneltask].Add(new PictureBox
                        {
                            Size = new Size(taskElem.Width, taskElem.Height),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Image = new Bitmap(Resources.PathForTest + "\\" + taskElem.Media),
                            //Height = taskElem.Height,
                            //Width = taskElem.Width,
                            Name = taskElem.Name,
                            Location = taskElem.Point
                        });
                    }



                    if (taskElem.Type.Equals("System.Windows.Forms.TextBox"))
                    {
                        var temp = new TextBox
                        {
                            Height = taskElem.Height,
                            Width = taskElem.Width,
                            Name = taskElem.Name,
                            Location = taskElem.Point,
                            Tag = taskElem.Answer,
                            TabIndex = taskElem.Index
                        };
                        temp.KeyUp += KeyUpEvent;
                        _TBInTask[paneltask].Add(temp);
                        _listTBLabels[paneltask].Add(new Label
                        {
                            Location = new Point(taskElem.Point.X, taskElem.Point.Y - 25),
                            Text = "Поле №" + taskElem.Index,
                            Font = new System.Drawing.Font("Century Gothic", 10.25F),
                        });
                    }
                }
            }

            foreach (var task in _listTasksInTest)
            {

                _listPanelTasks.Add(new Panel
                {
                    BackColor = System.Drawing.SystemColors.GradientInactiveCaption,
                    Location = new System.Drawing.Point(0, 0),
                    Name = task.Name,
                    Size = SystemInformation.PrimaryMonitorSize,
                    TabIndex = 0,
                    Parent = panelMain
                });

                const int panelAnswerSizeHeigth = 160;
                const int panelAnswerWidth = 800;
                //Добавление панели с заданием
                Panel panelQestionFoo = new Panel
                {
                    BackColor = SystemColors.GradientInactiveCaption,
                    Location = new Point(SystemInformation.PrimaryMonitorSize.Width/2- panelAnswerWidth/2, 40),
                    Name = "panelQuestion",
                    Size = new Size(panelAnswerWidth, SystemInformation.PrimaryMonitorSize.Height - panelAnswerSizeHeigth - 70),
                    TabIndex = 0
                };
                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(panelQestionFoo);

                
                //Добавление панели с ответами
                Panel panelAnswerFoo = new Panel
                {
                    BackColor = Color.Linen,
                    Location = new Point(0, SystemInformation.PrimaryMonitorSize.Height- panelAnswerSizeHeigth-30),
                    Name = "panelAnswers",
                    Size = new Size(_listPanelTasks[_listPanelTasks.Count - 1].Size.Width, panelAnswerSizeHeigth),
                    TabIndex = 1,
                    AutoScroll = true
                };
                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(panelAnswerFoo);

                SortedList<int, TextBox> mySLofTb = new SortedList<int, TextBox>(new DecendingComparer<int>());
                
                foreach (TextBox tb in _TBInTask[task])
                {
                    mySLofTb.Add(tb.TabIndex, tb);
                }
                
                foreach (KeyValuePair<int, TextBox> keyValuetb in mySLofTb)
                {

                    Label answerLabel = new Label
                    {
                        AutoSize = true,
                        Font = new System.Drawing.Font("Century Gothic", 18.25F, System.Drawing.FontStyle.Bold),
                        Text = "Ответ №" + keyValuetb.Key + ": " + keyValuetb.Value.Tag + "  |  ",
                        Dock = DockStyle.Left
                    };


                    panelAnswerFoo.Controls.Add(answerLabel);
                    
                }

                

                //Следующее задание
                btnNextTask = new Button
                {
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Font = new System.Drawing.Font("Century Gothic", 11.25F),
                    Location = new System.Drawing.Point(SystemInformation.PrimaryMonitorSize.Width / 2 - 81, 40),
                    Name = "btnNextTask" + (_listPanelTasks.Count - 1),
                    Size = new System.Drawing.Size(162, 45),
                    Text = "Следующее задание",
                };
                btnNextTask.Click += nextTask;
                panelAnswerFoo.Controls.Add(btnNextTask);

                //Закончить тест
                btnEndTest = new Button
                {
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Font = new System.Drawing.Font("Century Gothic", 11.25F),
                    Location = new System.Drawing.Point(SystemInformation.PrimaryMonitorSize.Width / 2 - 81, 40),
                    Name = "btnEndTest" + (_listPanelTasks.Count - 1),
                    Size = new System.Drawing.Size(162, 45),
                    Text = "Закончить тест",
                };
                btnEndTest.Click += endTask;
                panelAnswerFoo.Controls.Add(btnEndTest);

                //Показать ответы
                btnCheckAnswers = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Century Gothic", 11.25F),
                    Location = new Point(SystemInformation.PrimaryMonitorSize.Width/2-81, SystemInformation.PrimaryMonitorSize.Height - 118),
                    Name = "btnCheckAnswers" + (_listPanelTasks.Count - 1),
                    Size = new Size(162, 45),
                    Text = "Ответить",
                    AutoSize = true
                };
                btnCheckAnswers.Click += checkAnswers;
                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(btnCheckAnswers);

                foreach (PictureBox pb in _PBInTask[task])
                {
                    panelQestionFoo.Controls.Add(pb);
                }
                foreach (Label rtb in _RTBInTask[task])
                {
                    panelQestionFoo.Controls.Add(rtb);
                    rtb.BringToFront();
                }

                foreach (TextBox tb in _TBInTask[task])
                {
                    panelQestionFoo.Controls.Add(tb);
                    tb.BringToFront();
                    Size lenTBText = TextRenderer.MeasureText("Ответ №" + tb.TabIndex, tb.Font);
                    if (lenTBText.Width > tb.Width)
                    {
                        tb.Width = lenTBText.Width + 3;
                    }
                    SendMessage(tb.Handle, EM_SETCUEBANNER, 0, "Ответ №" + tb.TabIndex);
                }
                
                //foreach (Label label in _listTBLabels[task])
                //{
                //    panelQestionFoo.Controls.Add(label);
                //    label.BringToFront();
                //}

            }

            
            _listPanelTasks[_listPanelTasks.Count - 1].Controls.Find("btnNextTask" + (_listPanelTasks.Count - 1), true)[0].Visible = false;
            _listPanelTasks[_listPanelTasks.Count - 1].Controls.Find("btnEndTest" + (_listPanelTasks.Count - 1), true)[0].Visible = true;

            for (int i=0;i< _listPanelTasks.Count; i++)
            {
                _listPanelTasks[i].Controls.Find("panelAnswers", true)[0].Visible = false;
            }

            toolStripProgressBar1.Value = 100 / _listTasksInTest.Count;
            toolStripProgressBar1.Step = 100 / _listTasksInTest.Count;
            toolStripStatusLabelTaskNumberAndTaskCount.Text = "Выполняется задание: " + currentTaskNum + " из " + _listTasksInTest.Count;
        }

        private void nextTask(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name.Replace("btnNextTask", "");
            int index = Int32.Parse(tempString);
            if (index != _listPanelTasks.Count - 1)
            {
                _listPanelTasks[index].Visible = false;
                _listPanelTasks[index + 1].Visible = true;
            }
            currentTaskNum++;
            toolStripStatusLabelTaskNumberAndTaskCount.Text = "Выполняется задание: " + currentTaskNum + " из " + _listTasksInTest.Count;
            toolStripProgressBar1.PerformStep();
        }

        private void endTask(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name.Replace("btnEndTest", "");
            int index = Int32.Parse(tempString);

            _listPanelTasks[index].Visible = false;

            FormResults formResults = new FormResults(this);
            formResults.Text = "ТЕСТ. " + _currentTest + ". " + _currentVzvod + " взвод. " + "Студент " + _currentStudent;
            this.Visible = false;
            formResults.Visible = true;
        }
        private bool GrammarCheck(string rightAnswer, string userAnswer)
        {
            var length = rightAnswer.Length > userAnswer.Length ? userAnswer.Length : rightAnswer.Length;
            var checker = 0;
            for (var i = 0; i < length; i++)
            {
                if (rightAnswer[i] == userAnswer[i]
                    || (i + 1 < rightAnswer.Length && rightAnswer[i + 1] == userAnswer[i])
                    || (i + 1 < userAnswer.Length && rightAnswer[i] == userAnswer[i + 1])
                    || (i + 2 < rightAnswer.Length && rightAnswer[i + 2] == userAnswer[i])
                    || (i + 2 < userAnswer.Length && rightAnswer[i] == userAnswer[i + 2]))
                {
                    checker++;
                }
            }

            if ((float)checker / length >= 0.7)
            {
                return true;
            }
            return false;
        }

        private void checkAnswers(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int index = Int32.Parse(tempString.Replace("btnCheckAnswers",""));
            bool thisTaskSuccess = true;


            //в текстбоксах в tag Хранятся правильные ответы, их нужно сравнивать с введенным текстом

            for (int i = 0; i < _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls.Count; i++)
            {

                Control buf = _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls[i];
                buf.Enabled = false;
                if (buf is TextBox)
                {
                    /*if (buf.Text == "HESOYAM")
                    {
                        break;
                    }*/
                    if (!GrammarCheck(buf.Text.ToLower().Replace(" ", "").Replace(".",",").Replace("ё","е"), buf.Tag.ToString().ToLower().Replace(" ", "").Replace(".", ",").Replace("ё", "е")))
                    {
                        thisTaskSuccess = false;
                    }
                }
            }

            if (thisTaskSuccess) countRightAnswers++;

            //System.Windows.Forms.TextBox, Text: 1
            var test = _listPanelTasks[index].Controls.Find("panelAnswers", true)[0];
            _listPanelTasks[index].Controls.Find("panelAnswers", true)[0].Visible = true;

            _btnCheckAnswersName = "btnCheckAnswers" + (index + 1);
            _backdoorMode = false;
        }

        private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                var index = Int32.Parse(_btnCheckAnswersName.Replace("btnCheckAnswers", ""));
                var smth = _listPanelTasks[index].Controls.Find("panelQuestion", true);
                for (var i = 0; i < smth[0].Controls.Count; i++)
                {
                    var buf = smth[0].Controls[i];
                    if (buf is TextBox)
                    {
                        if (!_backdoorMode)
                        {
                            //buf.Enabled = false;
                            buf.Text = buf.Tag.ToString();
                        }
                        else
                        {
                            //buf.Enabled = true;
                            buf.Text = "";
                        }
                    }
                }
                _backdoorMode = !_backdoorMode;
            }
        }
    }
}
