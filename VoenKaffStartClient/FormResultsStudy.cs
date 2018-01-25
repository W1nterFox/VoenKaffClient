using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using VoenKaffStartClient.Senders;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient
{
    public partial class FormResultsStudy : Form
    {
        string _currentTest;
        string _currentVzvod;
        string _currentStudent;
        string _currentCourse;

        public FormResultsStudy(FormStudy formStudy)
        {
            InitializeComponent();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            _currentTest = formStudy._currentTest;
            _currentVzvod = formStudy._currentVzvod;
            _currentStudent = formStudy._currentStudent;
            _currentCourse = formStudy._currentCourse;

            labelTestName.Text = _currentTest;
            labelVzvodName.Text = _currentVzvod;
            labelFIOName.Text = _currentStudent;
            labelCurrentCourse.Text = _currentCourse;

            var json = JsonConvert.SerializeObject(new Result
            {
                Mark = "Пройдено",
                Platoon = labelVzvodName.Text,
                StudentName = labelFIOName.Text,
                TestName = labelTestName.Text,
                Timestamp = DateTime.Now,
                ResultType = "Тренировка",
                Course = labelCurrentCourse.Text
            });
            var connectToServer=SendMessageFromServer(json);

            if (connectToServer) return;
            var path = "res.data";
            var results = new List<Result>();
            if (File.Exists(path))
            {
                results = JsonConvert.DeserializeObject<List<Result>>(File.ReadAllText(path));
            }

            results.Add(new Result{
                Mark = "Пройдено",
                Platoon = labelVzvodName.Text,
                StudentName = labelFIOName.Text,
                TestName = labelTestName.Text,
                Timestamp = DateTime.Now,
                ResultType = "Тренировка",
                Course = labelCurrentCourse.Text
            });
            File.AppendAllText(path, JsonConvert.SerializeObject(results));

        }

        private bool SendMessageFromServer(string result)
        {
            try
            {
                return new ResultSender().Connect(result);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
        }

        private void buttonCloseTest_Click(object sender, EventArgs e)
        {
            var rz = MessageBox.Show("Завершить программу?", "Завершение", MessageBoxButtons.YesNo);

            if (rz == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void FormResultsStudy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
