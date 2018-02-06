using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using SerializablePicutre;
using VoenKaffStartClient;
using VoenKaffStartClient.Properties;
using VoenKaffStartClient.Senders;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient
{
    public partial class Form1 : Form
    {
        //List<String> listPanelsTasks;
        public string currentTest;
        public string currentVzvod;
        public string currentStudent;
        public string currentCource;

        Tests listOfFormDefaultTest;
        List<FormTest> listFormTests = new List<FormTest> { };
        List<FormStudy> listFormStudy = new List<FormStudy> { };

        FormTest _formTest;
        FormStudy _formStudy;
        private FormSettings _formSettings;

        FormPlatoon formPlaton;

        public Form1()
        {
            var runningProccess = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            if (runningProccess.Count(p => p.ProcessName.Contains("VoenKaffStartClient")) > 1)
            {
                MessageBox.Show("Программа уже запущена, невозможно запустить ещё один экземпляр",
                    "Программа уже запущена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            InitializeComponent();

            new OnTimerSender().Start();

            if (!Directory.Exists(Resources.PathForTest))
            {
                Directory.CreateDirectory(Resources.PathForTest);
            }

            new UpdateTests().Connect();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            formPlaton = new FormPlatoon(this);

            var testLoader = new TestLoader();

            var errorCounter = 0;
            while (errorCounter<10)
            {
                try
                {
                    listOfFormDefaultTest = testLoader.LoadTestsFromFolder(Resources.PathForTest);
                    break;
                }
                catch (Exception)
                {
                    errorCounter++;
                }
            }

            if (errorCounter == 9)
            {
                MessageBox.Show("Не удалось загрузить тесты, попробуйте перезапустить программу",
                    "Не удалось загрузить тесты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }


            Courses.Set(listOfFormDefaultTest.CourseList);

            foreach (String course in Courses.Get())
            {
                comboBoxChooseCourse.Items.Add(course);
            }



            //foreach (Test test in listOfFormDefaultTest.TestList)
            //{
            //    testName.Items.Add(test.Name);
            //}

            foreach (KeyValuePair<string, List<string>> keyValue in listOfFormDefaultTest.PlatoonList)
            {
                VzvodAndLs.Get().Add(keyValue.Key, keyValue.Value);
                ((ListBox)(formPlaton.Controls.Find("listBoxVzvoda", true)[0])).Items.Add(keyValue.Key);
                
            }
            
            foreach (KeyValuePair<string, List<string>> keyValue in VzvodAndLs.Get())
            {
                vzvodName.Items.Add(keyValue.Key);
            }

            //testName.Items.AddRange(new string[] { "Номенклатура карт", "Дальность до цели" });
            //vzvodName.Items.AddRange(new string[] { "121", "122", "123", "131", "132", "133", "141", "142", "143" });

            

            vzvodName.SelectedIndexChanged += nameVzvod_SelectedIndexChanged;


            testName.SelectedIndexChanged += startButtonEnabled;
            vzvodName.SelectedIndexChanged += startButtonEnabled;
            FIOName.SelectedIndexChanged += startButtonEnabled;

            radioButtonTestModeTest.Checked = true;
            //listPanelsTasks = new List<String>();
            //nameFIO.Items.AddRange(new string[] {""});
            
        }

        private void comboBoxChooseCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourse = (string)comboBoxChooseCourse.SelectedItem;
            if (selectedCourse != null)
            {
                testName.SelectedItem = null;
                testName.Items.Clear();
                List<Test> bufList = listOfFormDefaultTest.TestList.FindAll(x => (x.Course == selectedCourse));
                foreach (Test test in bufList)
                {
                    testName.Items.Add(test.Name);
                }
            }
            
            
        }

        private void nameVzvod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            string selectedVzvod = (string)vzvodName.SelectedItem;
            if (selectedVzvod != null)
            {
                FIOName.SelectedItem = null;
                FIOName.Items.Clear();

                FIOName.Items.AddRange(VzvodAndLs.Get()[selectedVzvod].ToArray());
            }
        
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


        private void startButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            currentTest = testName.SelectedItem.ToString();
            currentVzvod = vzvodName.SelectedItem.ToString();
            currentStudent = FIOName.SelectedItem.ToString();
            currentCource = comboBoxChooseCourse.SelectedItem.ToString();


            //Test currentTestInLists = new Test();
            int index = 0;
            for ( int i=0; i< listOfFormDefaultTest.TestList.Count; i++  )
            {
                if (listOfFormDefaultTest.TestList[i].Name.Equals(currentTest))
                {
                    index = i;
                }
            }
            
            
            
            
            if (radioButtonTestModeTest.Checked)
            {
                _formTest = new FormTest(currentTest, currentVzvod, currentStudent, currentCource);
                listFormTests.Add(_formTest);
                _formTest.initTest(listOfFormDefaultTest.TestList[index]);
                _formTest.Visible = true;

                _formTest.Text = "ТЕСТ. " + currentTest + ". " + currentVzvod + " взвод. " + "Студент " + currentStudent;
            }

            if (radioButtonTestModeStudy.Checked)
            {
                _formStudy = new FormStudy(currentTest, currentVzvod, currentStudent, currentCource);
                listFormStudy.Add(_formStudy);
                _formStudy.initTest(listOfFormDefaultTest.TestList[index]);
                _formStudy.Visible = true;

                _formStudy.Text = "ОБУЧЕНИЕ. " + currentTest + ". " + currentVzvod + " взвод. " + "Студент " + currentStudent;
            }
            
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

        private void закрытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var rz = MessageBox.Show("Завершить программу?", "Завершение", MessageBoxButtons.YesNo);

            if (rz == DialogResult.Yes)
            {
                Close();
            }
        }

        private void добавитьВзводаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            formPlaton.Visible = true;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (_formSettings == null || _formSettings.IsDisposed)
            {
                _formSettings=new FormSettings();
            }

            _formSettings.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        
    }
}
