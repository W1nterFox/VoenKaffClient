using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoenKaffStartClient
{
    public partial class FormStudy : Form
    {
        string _currentTest;
        string _currentVzvod;
        string _currentStudent;
        public FormStudy(string currentTest, string currentVzvod, string currentStudent)
        {
            InitializeComponent();
            _currentTest = currentTest;
            _currentVzvod = currentVzvod;
            _currentStudent = currentStudent;
        }

        private void buttonNextTask_Click(object sender, EventArgs e)
        {

        }

        private void buttonEndTest_Click(object sender, EventArgs e)
        {
            FormResults formResults = new FormResults(_currentTest, _currentVzvod, _currentStudent);
            this.Visible = false;
            formResults.Text = "ОБУЧЕНИЕ. " + _currentTest + ". " + _currentVzvod + " взвод. " + "Студент " + _currentStudent;
            formResults.Visible = true;
        }
    }
}
