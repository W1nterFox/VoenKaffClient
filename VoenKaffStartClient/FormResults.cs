﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using VoenKaffStartClient.Senders;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient
{
    public partial class FormResults : Form
    {
        string _currentTest;
        string _currentVzvod;
        string _currentStudent;
        string _currentCourse;

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
            _currentCourse = formTest._currentCourse;

            _countRightAnswers = formTest.countRightAnswers;
            _countTasks = formTest._listTasksInTest.Count;
            _marks = formTest._marks;

            labelTestName.Text = _currentTest;
            labelVzvodName.Text = _currentVzvod;
            labelFIOName.Text = _currentStudent;
            labelCurrentCourse.Text = _currentCourse;

            labelTasksCount.Text = _countTasks.ToString();
            labelTasksRight.Text = _countRightAnswers.ToString();
            double percentRight = Math.Round((((float)_countRightAnswers / (float)_countTasks) * 100), 0, MidpointRounding.AwayFromZero);
            labelTasksPercent.Text = percentRight + "%";

            //labelFinalMark

            if (percentRight >= _marks.Excellent)
            {
                labelFinalMark.Text = "Отлично";
                labelFinalMark.ForeColor = Color.Green;
            }
            else
            if (percentRight >= _marks.Good)
            {
                labelFinalMark.Text = "Хорошо";
                labelFinalMark.ForeColor = Color.Blue;
            }
            else
            if (percentRight >= _marks.Satisfactory)
            {
                labelFinalMark.Text = "Удовлетворительно";
                labelFinalMark.ForeColor = Color.Orange;
            }
            else
            if (percentRight < _marks.Satisfactory)
            {
                labelFinalMark.Text = "Неудовлетворительно";
                labelFinalMark.ForeColor = Color.Red;
            }

            var json = JsonConvert.SerializeObject(new Result
            {
                Mark = labelFinalMark.Text,
                Platoon = labelVzvodName.Text,
                StudentName = labelFIOName.Text,
                TestName = labelTestName.Text,
                Timestamp = DateTime.Now,
                ResultType = "Экзамен",
                Course = labelCurrentCourse.Text
            });
            var connectToServer = SendMessageFromServer(json);

            if (connectToServer) return;
            const string path = "res.data";
            var results = new List<Result>();
            if (File.Exists(path))
            {
                try
                {
                    results = JsonConvert.DeserializeObject<List<Result>>(File.ReadAllText(path));
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            results.Add(new Result
            {
                Mark = labelFinalMark.Text,
                Platoon = labelVzvodName.Text,
                StudentName = labelFIOName.Text,
                TestName = labelTestName.Text,
                Timestamp = DateTime.Now,
                ResultType = "Экзамен",
                Course = labelCurrentCourse.Text
            });
            File.WriteAllText(path, JsonConvert.SerializeObject(results));
        }

        private bool SendMessageFromServer(string result)
        {
            try {
                return new ResultSender().Connect(result);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось отправить результаты на сервер. Пожалуйста, попробуйте перезапустить программу, для повторной попытки отправки, а так же проверьте состояние сервера.", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
    }
}
