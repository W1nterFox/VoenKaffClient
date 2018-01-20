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
        Test _objectsInCurrentTest;
        //Коллекция тасков в тесте
        List<Task> _listTasksInTest=new List<Task> { };
        public Dictionary<Task, List<RichTextBox>> _RTBInTask = new Dictionary<Task, List<RichTextBox>> { };
        public Dictionary<Task, List<PictureBox>> _PBInTask = new Dictionary<Task, List<PictureBox>> { };
        public Dictionary<Task, List<TextBox>> _TBInTask = new Dictionary<Task, List<TextBox>> { };

        public FormTest(string currentTest, string currentVzvod, string currentStudent, Test objectsInCurrentTest)
        {
            InitializeComponent();
            _currentTest = currentTest;
            _currentVzvod = currentVzvod;
            _currentStudent = currentStudent;

            _objectsInCurrentTest = objectsInCurrentTest;

            foreach (Task paneltask in objectsInCurrentTest.Tasks)
            {
                _RTBInTask.Add(paneltask, new List<RichTextBox> { });
                _PBInTask.Add(paneltask, new List<PictureBox> { });
                _TBInTask.Add(paneltask, new List<TextBox> { });

                _listTasksInTest.Add(paneltask);

                foreach (TaskElement taskElem in paneltask.TaskElements)
                {
                    if ( taskElem.Type.Equals("System.Windows.Forms.RichTextBox"))
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
                        _PBInTask[paneltask].Add(new PictureBox
                        {
                            Image = new Bitmap(taskElem.Media),
                            Height = taskElem.Height,
                            Width = taskElem.Width,
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
    }
}
