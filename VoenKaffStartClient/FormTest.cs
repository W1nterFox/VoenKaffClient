using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient
{
    public partial class FormTest : Form
    {
        string _currentTest;
        string _currentVzvod;
        string _currentStudent;
        //Коллекция тасков в тесте
        public List<Task> _listTasksInTest=new List<Task> { };
        public Dictionary<Task, List<Label>> _RTBInTask = new Dictionary<Task, List<Label>> { };
        public Dictionary<Task, List<PictureBox>> _PBInTask = new Dictionary<Task, List<PictureBox>> { };
        public Dictionary<Task, List<TextBox>> _TBInTask = new Dictionary<Task, List<TextBox>> { };
        public List<Panel> _listPanelTasks = new List<Panel> { };
        Button btnNextTask;
        Button btnEndTest;


        public FormTest(string currentTest, string currentVzvod, string currentStudent)
        {
            InitializeComponent();
            _currentTest = currentTest;
            _currentVzvod = currentVzvod;
            _currentStudent = currentStudent;
            

            

            

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonNextTask_Click(object sender, EventArgs e)
        {

        }

        private void buttonEndTest_Click(object sender, EventArgs e)
        {
            FormResults formResults = new FormResults(_currentTest, _currentVzvod, _currentStudent);
            this.Visible = false;
            formResults.Text = "ТЕСТ. " + _currentTest + ". " + _currentVzvod + " взвод. " + "Студент " + _currentStudent;
            formResults.Visible = true;
        }








        public void initTest(Test objectsInCurrentTest)
        {
            
            

            foreach (Task paneltask in objectsInCurrentTest.Tasks)
            {
                _RTBInTask.Add(paneltask, new List<Label> { });
                _PBInTask.Add(paneltask, new List<PictureBox> { });
                _TBInTask.Add(paneltask, new List<TextBox> { });

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
                            Text = taskElem.Text

                        });
                    }

                    if (taskElem.Type.Equals("System.Windows.Forms.PictureBox"))
                    {
                        var image = new Bitmap(taskElem.Media);
                        _PBInTask[paneltask].Add(new PictureBox
                        {
                            Size = image.Size,
                            Image = image,
                            //Height = taskElem.Height,
                            //Width = taskElem.Width,
                            Name = taskElem.Name,
                            Location = taskElem.Point
                        });


                    }

                    if (taskElem.Type.Equals("System.Windows.Forms.TextBox"))
                    {
                        _TBInTask[paneltask].Add(new TextBox
                        {
                            Height = taskElem.Height,
                            Width = taskElem.Width,
                            Name = taskElem.Name,
                            Location = taskElem.Point,
                            Tag = taskElem.Answer,
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
                    Size = new System.Drawing.Size(1109, 630),
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
                    Size = new System.Drawing.Size(1105, 510),
                    TabIndex = 0
                };
                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(panelQestionFoo);

                //Добавление панели с ответами
                Panel panelAnswerFoo = new Panel
                {
                    BackColor = System.Drawing.Color.Linen,
                    //Controls.Add(this.buttonEndTest);
                    //Controls.Add(this.buttonNextTask);
                    Location = new System.Drawing.Point(0, 520),
                    Name = "panelAnswers",
                    Size = new System.Drawing.Size(1105, 118),
                    TabIndex = 1,
                };
                _listPanelTasks[_listPanelTasks.Count - 1].Controls.Add(panelAnswerFoo);

                int perem = 0;
                for (int i = 0; i < _TBInTask[task].Count; i++)
                {


                    panelAnswerFoo.Controls.Add(new Label
                    {
                        AutoSize = true,
                        Font = new System.Drawing.Font("Century Gothic", 9.25F),

                        Location = new System.Drawing.Point(perem * panelAnswerFoo.Controls.Count, 10),
                        Text = "Правильный ответ #" + (i + 1) + ": " + _TBInTask[task][i].Tag,
                    });

                    perem = panelAnswerFoo.Controls[panelAnswerFoo.Controls.Count - 1].Width;
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



                foreach (Label rtb in _RTBInTask[task])
                {
                    panelQestionFoo.Controls.Add(rtb);
                }
                foreach (PictureBox pb in _PBInTask[task])
                {
                    panelQestionFoo.Controls.Add(pb);
                }
                foreach (TextBox tb in _TBInTask[task])
                {
                    panelQestionFoo.Controls.Add(tb);
                }

            }

            
            _listPanelTasks[_listPanelTasks.Count - 1].Controls.Find("btnNextTask" + (_listPanelTasks.Count - 1), true)[0].Visible = false;
            _listPanelTasks[_listPanelTasks.Count - 1].Controls.Find("btnEndTest" + (_listPanelTasks.Count - 1), true)[0].Visible = true;

           



        }

        private void nextTask(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int index = Int32.Parse(tempString.Substring(tempString.Length - 1));
            if (index != _listPanelTasks.Count - 1)
            {
                _listPanelTasks[index].Visible = false;
                _listPanelTasks[index + 1].Visible = true;
            }

        }

        private void endTask(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int index = Int32.Parse(tempString.Substring(tempString.Length - 1));

            _listPanelTasks[index].Visible = false;
        }








    }
}
