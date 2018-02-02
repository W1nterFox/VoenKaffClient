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
using System.Collections;

namespace VoenKaffStartClient
{
    public partial class FormTest : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);


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


        public int countRightAnswers = 0;

        int currentTaskNum = 1;

        public FormTest(string currentTest, string currentVzvod, string currentStudent, string currentCourse)
        {
            InitializeComponent();
            _currentTest = currentTest;
            _currentVzvod = currentVzvod;
            _currentStudent = currentStudent;
            _currentCourse = currentCourse;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            

        }

        

        

        private void buttonEndTest_Click(object sender, EventArgs e)
        {
            //FormResults formResults = new FormResults(_currentTest, _currentVzvod, _currentStudent);
            this.Visible = false;
            //formResults.Text = "ТЕСТ. " + _currentTest + ". " + _currentVzvod + " взвод. " + "Студент " + _currentStudent;
            //formResults.Visible = true;
        }








        public void initTest(Test objectsInCurrentTest)
        {

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
                        using (var stream = File.Open(Resources.PathForTest+"\\"+taskElem.Media, FileMode.Open))
                        {
                            var binaryFormatter = new BinaryFormatter();
                            var image = ((SerializablePicture) binaryFormatter.Deserialize(stream)).Picture;
                            _PBInTask[paneltask].Add(new PictureBox
                            {
                                Size = new Size(taskElem.Width, taskElem.Height),
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Image = image,
                                //Height = taskElem.Height,
                                //Width = taskElem.Width,
                                Name = taskElem.Name,
                                Location = taskElem.Point
                            });
                        }

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
                            Font = new System.Drawing.Font("Century Gothic", 10.25F),
                        });

                        


                    }
                }
            }

            foreach (Task task in _listTasksInTest)
            {

                _listPanelTasks.Add(new Panel
                {
                    BackColor = System.Drawing.SystemColors.GradientInactiveCaption,
                    Location = new System.Drawing.Point(0, 0),
                    Name = task.Name,
                    Size = new System.Drawing.Size(1109, 730),
                    TabIndex = 0,
                    Parent = panelMain
                });

                //Добавление панели с заданием
                Panel panelQestionFoo = new Panel
                {
                    BackColor = System.Drawing.SystemColors.GradientInactiveCaption,
                    //Controls.Add(this.label2),
                    Location = new System.Drawing.Point(0, 0),
                    Name = "panelQuestion",
                    Size = new System.Drawing.Size(1105, 610),
                    TabIndex = 0
                };
                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(panelQestionFoo);

                //Добавление панели с ответами
                Panel panelAnswerFoo = new Panel
                {
                    BackColor = System.Drawing.Color.Linen,
                    Location = new System.Drawing.Point(0, 610),
                    Name = "panelAnswers",
                    Size = new System.Drawing.Size(1105, 118),
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
                    answerLabel.Font = new System.Drawing.Font("Century Gothic", 18.25F, System.Drawing.FontStyle.Bold);
                    answerLabel.Text = "Ответ №" + keyValuetb.Key + ": " + keyValuetb.Value.Tag + "  |  ";
                    answerLabel.Dock = DockStyle.Left;
                    
                    panelAnswerFoo.Controls.Add(answerLabel);
                    
                }

                

                //Следующее задание
                btnNextTask = new Button
                {
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Font = new System.Drawing.Font("Century Gothic", 11.25F),
                    Location = new System.Drawing.Point(450, 50),
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
                    Location = new System.Drawing.Point(450, 50),
                    Name = "btnEndTest" + (_listPanelTasks.Count - 1),
                    Size = new System.Drawing.Size(162, 45),
                    Text = "Закончить тест",
                };
                btnEndTest.Click += endTask;
                panelAnswerFoo.Controls.Add(btnEndTest);

                //Показать ответы
                btnCheckAnswers = new Button
                {
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Font = new System.Drawing.Font("Century Gothic", 11.25F),
                    Location = new System.Drawing.Point(450, 650),
                    Name = "btnCheckAnswers" + (_listPanelTasks.Count - 1),
                    Size = new System.Drawing.Size(162, 45),
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

        private void checkAnswers(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int index = Int32.Parse(tempString.Replace("btnCheckAnswers",""));
            bool thisTaskSuccess = true;


            //в текстбоксах в tag Хранятся правильные ответы, их нужно сравнивать с введенным тестом

            for (int i = 0; i < _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls.Count; i++)
            {

                Control buf = _listPanelTasks[index].Controls.Find("panelQuestion", true)[0].Controls[i];

                if (buf is TextBox)
                {
                    var answer = buf.Text.ToLower().Trim().Replace("жы", "жи").Replace("пре", "при");
                    var tagText = buf.Tag.ToString().ToLower().Trim().Replace("жы", "жи").Replace("пре", "при");

                    if (answer != "")
                    {
                        if (tagText.Substring(0, tagText.Length - 1) !=
                        answer.Substring(0, answer.Length - 1)
                        )
                        {
                            thisTaskSuccess = false;
                        }
                    }
                    else
                    {
                        if (answer != tagText)
                        {
                            thisTaskSuccess = false;
                        }
                    }
                    
                }
            }

            if (thisTaskSuccess) countRightAnswers++;

            //System.Windows.Forms.TextBox, Text: 1
            var test = _listPanelTasks[index].Controls.Find("panelAnswers", true)[0];
            _listPanelTasks[index].Controls.Find("panelAnswers", true)[0].Visible = true;
        }

        
    }
}
