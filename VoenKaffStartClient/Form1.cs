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
using VoenKaffStartClient.Binders;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient
{
    public partial class Form1 : Form
    {
        List<String> listPanelsTasks;
        public string currentTest;
        public string currentVzvod;
        public string currentStudent;

        Tests listOfFormDefaultTest;
        List<FormTest> listFormTests = new List<FormTest> { };
        List<FormStudy> listFormStudy = new List<FormStudy> { };

        FormTest _formTest;
        FormStudy _formStudy;
        private string _pathForTest = "E:\\";

        

        public Form1()
        {
            InitializeComponent();

            var testLoader = new TestLoader();
            listOfFormDefaultTest = testLoader.LoadTestsFromFolder(_pathForTest);

            foreach (Test test in listOfFormDefaultTest.TestList)
            {
                testName.Items.Add(test.Name);
                
            }




            //testName.Items.AddRange(new string[] { "Номенклатура карт", "Дальность до цели" });
            vzvodName.Items.AddRange(new string[] { "121", "122", "123", "131", "132", "133", "141", "142", "143" });

            

            vzvodName.SelectedIndexChanged += nameVzvod_SelectedIndexChanged;


            testName.SelectedIndexChanged += startButtonEnabled;
            vzvodName.SelectedIndexChanged += startButtonEnabled;
            FIOName.SelectedIndexChanged += startButtonEnabled;

            radioButtonTestModeTest.Checked = true;
            listPanelsTasks = new List<String>();
            //nameFIO.Items.AddRange(new string[] {""});
            
        }

        private void nameVzvod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string selectedVzvod = (string)vzvodName.SelectedItem;
            FIOName.SelectedItem = null;
            FIOName.Items.Clear();
            FIOName.Items.AddRange(getStudentsByVzvod(selectedVzvod));
        }

        private void startButtonEnabled(object sender, System.EventArgs e)
        {
            if (testName.SelectedItem != null && vzvodName.SelectedItem!=null && FIOName.SelectedItem != null)
            {
                startButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }

        private string[] getStudentsByVzvod(string selectedVzvod)
        {

            if (selectedVzvod.Equals("141")) return new string[] { "Дмитриев", "Целищев" };
            if (selectedVzvod.Equals("142")) return new string[] { "Минаев", "НеМинаев" };

            return new string[] { "temp1", "temp2", "temp3" };
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            currentTest = testName.SelectedItem.ToString();
            currentVzvod = vzvodName.SelectedItem.ToString();
            currentStudent = FIOName.SelectedItem.ToString();



            //Test currentTestInLists = new Test();
            int index = 0;
            for ( int i=0; i< listOfFormDefaultTest.TestList.Count; i++  )
            {
                if (listOfFormDefaultTest.TestList[i].Name.Equals(currentTest))
                {
                    index = i;
                }
            }
            
            initTest(listOfFormDefaultTest.TestList[index]);
            
            if (radioButtonTestModeTest.Checked)
            {
                _formTest.Visible = true;
                _formTest._listPanelTasks[0].Visible = true;
            }

            if (radioButtonTestModeStudy.Checked)
            {
                _formStudy.Visible = true;
            }
            
        }



        private void initTest(Test objectsInCurrentTest)
        {
            
            FormTest formTest = new FormTest(currentTest, currentVzvod, currentStudent);
            FormStudy formStudy = new FormStudy(currentTest, currentVzvod, currentStudent);
            _formTest = formTest;
            _formStudy = formStudy;
            listFormTests.Add(formTest);
            listFormStudy.Add(formStudy);

            List<Task> _listTasksInTest = new List<Task> { };
            Dictionary<Task, List<RichTextBox>> _RTBInTask = new Dictionary<Task, List<RichTextBox>> { };
            Dictionary<Task, List<PictureBox>> _PBInTask = new Dictionary<Task, List<PictureBox>> { };
            Dictionary<Task, List<TextBox>> _TBInTask = new Dictionary<Task, List<TextBox>> { };
            List<Panel> _listPanelTasks = new List<Panel> { };
            Panel panelMain = (Panel)formTest.Controls.Find("panelMain", true)[0];

            Button btnNextTask;
            Button btnEndTest;

            foreach (Task paneltask in objectsInCurrentTest.Tasks)
            {
                _RTBInTask.Add(paneltask, new List<RichTextBox> { });
                _PBInTask.Add(paneltask, new List<PictureBox> { });
                _TBInTask.Add(paneltask, new List<TextBox> { });

                _listTasksInTest.Add(paneltask);

                foreach (TaskElement taskElem in paneltask.TaskElements)
                {
                    if (taskElem.Type.Equals("System.Windows.Forms.RichTextBox"))
                    {
                        _RTBInTask[paneltask].Add(new RichTextBox
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
                        var test = _pathForTest + taskElem.Media;
                        using (var stream = File.Open(_pathForTest+taskElem.Media, FileMode.Open))
                        {
                            var binaryFormatter = new BinaryFormatter {Binder = new PictureBinder()};
                            var picture = (SerializablePicture)binaryFormatter.Deserialize(stream);
                            var image = picture.Picture;
                        
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
                btnNextTask = new Button {
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

                

                foreach (RichTextBox rtb in _RTBInTask[task])
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

            formTest.Text = "ТЕСТ." + currentTest + ". " + currentVzvod + " взвод. " + "Студент " + currentStudent;
            formStudy.Text = "ОБУЧЕНИЕ. " + currentTest + ". " + currentVzvod + " взвод. " + "Студент " + currentStudent;

            formTest._listTasksInTest = _listTasksInTest;
            formTest._RTBInTask = _RTBInTask;
            formTest._PBInTask = _PBInTask;
            formTest._TBInTask = _TBInTask;
            formTest._listPanelTasks = _listPanelTasks;
            formTest._listPanelTasks[formTest._listPanelTasks.Count - 1].Controls.Find("btnNextTask" + (formTest._listPanelTasks.Count - 1), true)[0].Visible = false;
            formTest._listPanelTasks[formTest._listPanelTasks.Count - 1].Controls.Find("btnEndTest" + (formTest._listPanelTasks.Count - 1), true)[0].Visible = true;

            formStudy._listTasksInTest = _listTasksInTest;
            formStudy._RTBInTask = _RTBInTask;
            formStudy._PBInTask = _PBInTask;
            formStudy._TBInTask = _TBInTask;
            formStudy._listPanelTasks = _listPanelTasks;
            formStudy._listPanelTasks[formStudy._listPanelTasks.Count - 1].Controls.Find("btnNextTask" + (formStudy._listPanelTasks.Count - 1), true)[0].Visible = false;
            formStudy._listPanelTasks[formStudy._listPanelTasks.Count - 1].Controls.Find("btnEndTest" + (formStudy._listPanelTasks.Count - 1), true)[0].Visible = true;



        }

        private void nextTask(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int index = Int32.Parse(tempString.Substring(tempString.Length - 1));
            if (index != _formTest._listPanelTasks.Count-1)
            {
                _formTest._listPanelTasks[index].Visible = false;
                _formTest._listPanelTasks[index + 1].Visible = true;
            }
            
        }

        private void endTask(object sender, EventArgs e)
        {
            string tempString = ((Control)sender).Name;
            int index = Int32.Parse(tempString.Substring(tempString.Length - 1));
            
            _formTest._listPanelTasks[index].Visible = false;
        }

        private void buttonInstruction_Click(object sender, EventArgs e)
        {
            FormInstruction formInstruction = new FormInstruction();
            formInstruction.Visible = true;
            formInstruction.Text = "Инструкция";
        }

        private void загрузитьТестыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Тут должно быть заполнение коллекции listOfFormDefaultTest тестами из файла
        }
    }
}
