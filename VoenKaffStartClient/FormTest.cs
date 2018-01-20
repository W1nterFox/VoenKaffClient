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
        public Dictionary<Task, List<RichTextBox>> _RTBInTask = new Dictionary<Task, List<RichTextBox>> { };
        public Dictionary<Task, List<PictureBox>> _PBInTask = new Dictionary<Task, List<PictureBox>> { };
        public Dictionary<Task, List<TextBox>> _TBInTask = new Dictionary<Task, List<TextBox>> { };
        public List<Panel> _listPanelTasks = new List<Panel> { };



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
    }
}
