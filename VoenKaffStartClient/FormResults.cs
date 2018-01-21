using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient
{
    public partial class FormResults : Form
    {
        string _currentTest;
        string _currentVzvod;
        string _currentStudent;
        int _countRightAnswers;
        int _countTasks;
        Marks _marks; 
        public FormResults(FormTest formTest)
        {
            InitializeComponent();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;


            _currentTest = formTest._currentTest;
            _currentVzvod = formTest._currentVzvod;
            _currentStudent = formTest._currentStudent;
            _countRightAnswers = formTest.countRightAnswers;
            _countTasks = formTest._listTasksInTest.Count;
            _marks = formTest._marks;

            labelTestName.Text = _currentTest;
            labelVzvodName.Text = _currentVzvod;
            labelFIOName.Text = _currentStudent;

            labelTasksCount.Text = _countTasks.ToString();
            labelTasksRight.Text = _countRightAnswers.ToString();
            labelTasksPercent.Text = ((float)_countRightAnswers / (float)_countTasks)*100 + "%".ToString();

            //labelFinalMark

            if (((float)_countRightAnswers / (float)_countTasks) * 100 >= _marks.Excellent)
            {
                labelFinalMark.Text = "Отлично";
                labelFinalMark.ForeColor = Color.Green;
            }
            else
            if (((float)_countRightAnswers / (float)_countTasks) * 100 >= _marks.Good)
            {
                labelFinalMark.Text = "Хорошо";
                labelFinalMark.ForeColor = Color.Blue;
            }
            else
            if (((float)_countRightAnswers / (float)_countTasks) * 100 >= _marks.Satisfactory)
            {
                labelFinalMark.Text = "Удовлетворительно";
                labelFinalMark.ForeColor = Color.Orange;
            }
            else
            if (((float)_countRightAnswers / (float)_countTasks) * 100 < _marks.Satisfactory)
            {
                labelFinalMark.Text = "Неудовлетворительно";
                labelFinalMark.ForeColor = Color.Red;
            }

        }



        private void buttonCloseTest_Click(object sender, EventArgs e)
        {
            var rz = MessageBox.Show("Завершить программу?", "Завершение", MessageBoxButtons.YesNo);

            if (rz == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
