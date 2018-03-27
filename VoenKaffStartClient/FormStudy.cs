using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using SerializablePicutre;
using VoenKaffStartClient.Properties;
using VoenKaffStartClient.Wrappers;
using System.Runtime.InteropServices;
using VoenKaffStartClient.Senders;

namespace VoenKaffStartClient
{
    public partial class FormStudy : Form
    {

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public string _currentTest;
        public string _currentVzvod;
        public string _currentStudent;
        public string _currentCourse;


        public Dictionary<Panel, int> _countTaskSuccess = new Dictionary<Panel, int> { };
        public Dictionary<Panel, int> _countTaskNotSure = new Dictionary<Panel, int> { };
        public Dictionary<Panel, int> _countTaskFail = new Dictionary<Panel, int> { };

        public List<Task> _listTasksInTest = new List<Task> { };
        public Dictionary<Task, List<Label>> _RTBInTask = new Dictionary<Task, List<Label>> { };
        public Dictionary<Task, List<PictureBox>> _PBInTask = new Dictionary<Task, List<PictureBox>> { };
        public Dictionary<Task, List<TextBox>> _TBInTask = new Dictionary<Task, List<TextBox>> { };
        public List<Panel> _listPanelTasks = new List<Panel> { };


        Button btnNextTask;
        Button btnCheckAnswers;
        Button btnTaskUserkSuccess;
        Button btnTaskUserkNotSure;
        
        public Dictionary<Task, List<Label>> _listTBLabels = new Dictionary<Task, List<Label>> { };
        int currentTaskNum = 0;



        public FormStudy(string currentTest, string currentVzvod, string currentStudent, string currentCourse)
        {
            InitializeComponent();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;


            _currentTest = currentTest;
            _currentVzvod = currentVzvod;
            _currentStudent = currentStudent;
            _currentCourse = currentCourse;
        }


        public void InitTest(Test objectsInCurrentTest)
        {
            foreach (var paneltask in objectsInCurrentTest.Tasks)
            {             
                _RTBInTask.Add(paneltask, new List<Label> { });
                _PBInTask.Add(paneltask, new List<PictureBox> { });
                _TBInTask.Add(paneltask, new List<TextBox> { });
                _listTBLabels.Add(paneltask, new List<Label> { });

                _listTasksInTest.Add(paneltask);
                
                foreach (var taskElem in paneltask.TaskElements)
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
                            Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204),

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
                        _TBInTask[paneltask].Add((new TextBox
                        {
                            Height = taskElem.Height,
                            Width = taskElem.Width,
                            Name = taskElem.Name,
                            Location = taskElem.Point,
                            Tag = taskElem.Answer,
                            TabIndex = taskElem.Index
                        }));
                        _listTBLabels[paneltask].Add(new Label
                        {
                            Location = new Point(taskElem.Point.X, taskElem.Point.Y - 25),
                            Text = "Поле №" + taskElem.Index,
                            Font = new Font("Century Gothic", 10.25F),
                        });
                    }
                }
            }

            foreach (Task task in _listTasksInTest)
            {

                _listPanelTasks.Add(new Panel
                {
                    BackColor = SystemColors.GradientInactiveCaption,
                    Location = new Point(0, 0),
                    Name = task.Name,
                    Size = new Size(1109, 730),
                    TabIndex = 0,
                    Parent = panelMain
                });

                _countTaskSuccess.Add(_listPanelTasks[_listPanelTasks.Count - 1], 0);
                _countTaskNotSure.Add(_listPanelTasks[_listPanelTasks.Count - 1], 0);
                _countTaskFail.Add(_listPanelTasks[_listPanelTasks.Count - 1], 0);


                //Добавление панели с заданием
                Panel panelQestionFoo = new Panel
                {
                    BackColor = SystemColors.GradientInactiveCaption,
                    //Controls.Add(this.label2),
                    Location = new Point(0, 0),
                    Name = "panelQuestion",
                    Size = new Size(1105, 610),
                    TabIndex = 0
                };
                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(panelQestionFoo);

                //Добавление панели с ответами
                Panel panelAnswerFoo = new Panel
                {
                    BackColor = Color.Linen,
                    Location = new Point(0, 610),
                    Name = "panelAnswers",
                    Size = new Size(1105, 118),
                    TabIndex = 1,
                    AutoScroll = true,
                };
                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(panelAnswerFoo);

                SortedList<int, TextBox> mySLofTB = new SortedList<int, TextBox>(new DecendingComparer<int>());

                foreach (TextBox tb in _TBInTask[task])
                {
                    mySLofTB.Add(tb.TabIndex, tb);
                }

                foreach (KeyValuePair<int, TextBox> keyValuetb in mySLofTB)
                {

                    Label answerLabel = new Label();

                    answerLabel.AutoSize = true;
                    answerLabel.Font = new Font("Century Gothic", 18.25F, FontStyle.Bold);
                    answerLabel.Text = "Ответ №" + keyValuetb.Key + ": " + keyValuetb.Value.Tag + "  |  ";
                    answerLabel.Dock = DockStyle.Left;

                    panelAnswerFoo.Controls.Add(answerLabel);

                }


                //Ответил верно
                btnTaskUserkSuccess = new Button
                {
                    BackColor = Color.LightGreen,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Century Gothic", 11.25F),
                    Location = new Point(340, 50),
                    Name = "btnTaskUserkSuccess" + (_listPanelTasks.Count - 1),
                    Size = new Size(200, 45),
                    Text = "Ответил верно",
                    Visible = false,
                };
                btnTaskUserkSuccess.Click += TaskUserkSuccess;
                panelAnswerFoo.Controls.Add(btnTaskUserkSuccess);


                //Ответил неуверенно
                btnTaskUserkNotSure = new Button
                {
                    BackColor = Color.Gold,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Century Gothic", 11.25F),
                    Location = new Point(540, 50),
                    Name = "btnTaskUserkNotSure" + (_listPanelTasks.Count - 1),
                    Size = new Size(300, 45),
                    Text = "Ответил, но не был уверен",
                    Visible = false,
                };
                btnTaskUserkNotSure.Click += TaskUserkNotSure;
                panelAnswerFoo.Controls.Add(btnTaskUserkNotSure);

                //Следующее задание
                btnNextTask = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Century Gothic", 11.25F),
                    Location = new Point(450, 50),
                    Name = "btnNextTask" + (_listPanelTasks.Count - 1),
                    Size = new Size(162, 45),
                    Text = "Следующее задание",
                    Visible = false,
                };
                btnNextTask.Click += nextTask;
                panelAnswerFoo.Controls.Add(btnNextTask);

                

                //Показать ответы
                btnCheckAnswers = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Century Gothic", 11.25F),
                    Location = new Point(450, 650),
                    Name = "btnCheckAnswers" + (_listPanelTasks.Count - 1),
                    Size = new Size(162, 45),
                    Text = "Ответить",
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
                    SendMessage(tb.Handle, EM_SETCUEBANNER, 0, "Ответ №" + tb.TabIndex);
                }

            }

            foreach (var panelTask in _listPanelTasks)
            {
                panelTask.Controls.Find("panelAnswers", true)[0].Visible = false;
            }

            toolStripProgressBar1.Value = 100 / _listTasksInTest.Count;
            toolStripProgressBar1.Step = 100 / _listTasksInTest.Count;
            toolStripStatusLabelTaskNumberAndTaskCount.Text = "Выполняется задание: " + (currentTaskNum + 1) + " из " + _listTasksInTest.Count;
        }


        private void TaskUserkSuccess(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int indexOld = Int32.Parse(tempString.Replace("btnTaskUserkSuccess",""));
            int index = currentTaskNum;
            //Приведение контроллеров в исходное состояние
            _listPanelTasks[index].Controls.Find("panelAnswers", true)[0].Visible = false;
            _listPanelTasks[index].Controls.Find("btnTaskUserkSuccess" + indexOld, true)[0].Visible = false;
            _listPanelTasks[index].Controls.Find("btnTaskUserkNotSure" + indexOld, true)[0].Visible = false;
            _listPanelTasks[index].Controls.Find("btnNextTask" + indexOld, true)[0].Visible = false;
            

            //Очистка всех текстбоксов
            for (int i = 0; i < _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls.Count; i++)
            {

                Control buf = _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls[i];
                if (buf is TextBox)
                {
                    buf.Enabled = true;
                    buf.Text = "";
                }
            }

            if (_countTaskSuccess[_listPanelTasks[index]]<1)
            {
                _countTaskSuccess[_listPanelTasks[index]]++;

                //Добавление в конец копии текущего таска ОДИН раз
                Panel buf = _listPanelTasks[index];
                _listPanelTasks.Add(buf);
            }

            
            
            //Переключение на следующий таск
            if (currentTaskNum != _listPanelTasks.Count - 1)
            {
                _listPanelTasks[index].Visible = false;
                _listPanelTasks[index + 1].Visible = true;
                currentTaskNum++;
                toolStripProgressBar1.Value = 100 * (currentTaskNum + 1) / _listPanelTasks.Count;
            }
            else
            {
                FormResultsStudy formResultStudy = new FormResultsStudy(this);
                this.Visible = false;
                formResultStudy.Visible = true;
            }

            
            toolStripStatusLabelTaskNumberAndTaskCount.Text = "Выполняется задание: " + (currentTaskNum + 1) + " из " + _listPanelTasks.Count;
            

        }

        private void TaskUserkNotSure(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int indexOld = Int32.Parse(tempString.Replace("btnTaskUserkNotSure", ""));
            int index = currentTaskNum;

            //Приведение контроллеров в исходное состояние
            _listPanelTasks[index].Controls.Find("panelAnswers", true)[0].Visible = false;
            _listPanelTasks[index].Controls.Find("btnTaskUserkSuccess" + indexOld, true)[0].Visible = false;
            _listPanelTasks[index].Controls.Find("btnTaskUserkNotSure" + indexOld, true)[0].Visible = false;
            _listPanelTasks[index].Controls.Find("btnNextTask" + indexOld, true)[0].Visible = false;
            //Очистка всех текстбоксов
            for (int i = 0; i < _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls.Count; i++)
            {

                Control buf = _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls[i];
                if (buf is TextBox)
                {
                    buf.Enabled = true;
                    buf.Text = "";
                }
            }

            if (_countTaskNotSure[_listPanelTasks[index]] < 3)
            {
                

                //Добавление в конец 3 копии текущего таска
                Panel buf = _listPanelTasks[index];
                _listPanelTasks.Add(buf);
                _listPanelTasks.Add(buf);
                _listPanelTasks.Add(buf);

                _countTaskNotSure[_listPanelTasks[index]] += 3;
            }
            else
            {


                //Добавление в конец 1 копию текущего таска
                Panel buf = _listPanelTasks[index];
                _listPanelTasks.Add(buf);

                _countTaskNotSure[_listPanelTasks[index]] += 1;
            }



            //Переключение на следующий таск
            if (currentTaskNum != _listPanelTasks.Count - 1)
            {
                _listPanelTasks[index].Visible = false;
                _listPanelTasks[index + 1].Visible = true;
                currentTaskNum++;
                toolStripProgressBar1.Value = 100 * (currentTaskNum + 1) / _listPanelTasks.Count;
            }
            toolStripStatusLabelTaskNumberAndTaskCount.Text = "Выполняется задание: " + (currentTaskNum + 1) + " из " + _listPanelTasks.Count;
        }

        private void nextTask(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int indexOld = Int32.Parse(tempString.Replace("btnNextTask", ""));
            int index = currentTaskNum;

            //Приведение контроллеров в исходное состояние
            _listPanelTasks[index].Controls.Find("panelAnswers", true)[0].Visible = false;
            _listPanelTasks[index].Controls.Find("btnTaskUserkSuccess" + indexOld, true)[0].Visible = false;
            _listPanelTasks[index].Controls.Find("btnTaskUserkNotSure" + indexOld, true)[0].Visible = false;
            _listPanelTasks[index].Controls.Find("btnNextTask" + indexOld, true)[0].Visible = false;
            //Очистка всех текстбоксов
            for (int i = 0; i < _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls.Count; i++)
            {

                Control buf = _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls[i];
                if (buf is TextBox)
                {
                    buf.Enabled = true;
                    buf.Text = "";
                }
            }

            //Добавление в конец копии текущего таска, если ответ неверный
            Panel buffer = _listPanelTasks[index];
            _listPanelTasks.Add(buffer);

            //Переключение на следующий таск
            if (currentTaskNum != _listPanelTasks.Count - 1)
            {
                _listPanelTasks[index].Visible = false;
                _listPanelTasks[index + 1].Visible = true;
                currentTaskNum++;
                toolStripProgressBar1.Value = 100 * (currentTaskNum + 1) / _listPanelTasks.Count;
            }

            toolStripStatusLabelTaskNumberAndTaskCount.Text = "Выполняется задание: " + (currentTaskNum + 1) + " из " + _listPanelTasks.Count;
            
        }


        private bool GrammarCheck(string rightAnswer,string userAnswer)
        {
            var length = rightAnswer.Length > userAnswer.Length ? userAnswer.Length : rightAnswer.Length;
            var checker = 0;
            for (var i = 0; i < length; i++)
            {
                if (rightAnswer[i] == userAnswer[i] 
                    || (i + 1 < rightAnswer.Length && rightAnswer[i+1] == userAnswer[i]) 
                    || (i + 1 < userAnswer.Length && rightAnswer[i] == userAnswer[i+1])
                    || (i + 2 < rightAnswer.Length && rightAnswer[i + 2] == userAnswer[i])
                    || (i + 2 < userAnswer.Length && rightAnswer[i] == userAnswer[i + 2]))
                {
                    checker++;
                }
            }

            if ((float) checker/ length >= 0.7)
            {
                return true;
            }
            return false;
        }
        private void checkAnswers(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int indexOld = Int32.Parse(tempString.Replace("btnCheckAnswers", ""));
            int index = currentTaskNum;
            bool thisTaskSuccess = true;


            //в текстбоксах в tag Хранятся правильные ответы, их нужно сравнивать с введенным тестом

            for (int i = 0; i < _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls.Count; i++)
            {

                Control buf = _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls[i];
                if (!(buf is TextBox)) continue;
                buf.Enabled = false;
                    
                    
                if (!GrammarCheck(buf.Text.ToLower().Replace(" ", "").Replace(".", ",").Replace("ё", "е"), buf.Tag.ToString().ToLower().Replace(" ", "").Replace(".", ",").Replace("ё", "е")))
                {
                    thisTaskSuccess = false;
                }
            }
            
            
            _listPanelTasks[index].Controls.Find("panelAnswers", true)[0].Visible = true;

            if (thisTaskSuccess == true)
            {
                _listPanelTasks[index].Controls.Find("btnTaskUserkSuccess" + indexOld, true)[0].Visible = true;
                _listPanelTasks[index].Controls.Find("btnTaskUserkNotSure" + indexOld, true)[0].Visible = true;
                _listPanelTasks[index].Controls.Find("btnNextTask" + indexOld, true)[0].Visible = false;
                
            }
            else
            {
                _listPanelTasks[index].Controls.Find("btnTaskUserkSuccess" + indexOld, true)[0].Visible = false;
                _listPanelTasks[index].Controls.Find("btnTaskUserkNotSure" + indexOld, true)[0].Visible = false;
                _listPanelTasks[index].Controls.Find("btnNextTask" + indexOld, true)[0].Visible = true;
                

                toolStripProgressBar1.Value = 100 * currentTaskNum/ _listPanelTasks.Count;
                toolStripStatusLabelTaskNumberAndTaskCount.Text = "Выполняется задание: " + (currentTaskNum + 1) + " из " + _listPanelTasks.Count;       

            }
        }

        private void FormStudy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
