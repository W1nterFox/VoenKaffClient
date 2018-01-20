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
    public partial class Form1 : Form
    {
        List<String> listPanelsTasks;
        public string currentTest;
        public string currentVzvod;
        public string currentStudent;

        List<Test> listOfFormDefaultTest = new List<Test> { };
        List<FormTest> listFormTests = new List<FormTest> { };
        List<FormStudy> listFormStudy = new List<FormStudy> { };

        FormTest _formTest;
        FormStudy _formStudy;

        

        public Form1()
        {
            InitializeComponent();

            var testLoader = new TestLoader();
            listOfFormDefaultTest = testLoader.LoadTestsFromFolder("D:\\");

            foreach (Test test in listOfFormDefaultTest)
            {
                testName.Items.Add(test.Name);
                //listFormTests.Add(new FormTest(null, null, null));
            }




            //testName.Items.AddRange(new string[] { "Номенклатура карт", "Дальность до цели" });
            vzvodName.Items.AddRange(new string[] { "121", "122", "123", "131", "132", "133", "141", "142", "143" });

            

            vzvodName.SelectedIndexChanged += new System.EventHandler(nameVzvod_SelectedIndexChanged);


            testName.SelectedIndexChanged += new System.EventHandler(startButtonEnabled);
            vzvodName.SelectedIndexChanged += new System.EventHandler(startButtonEnabled);
            FIOName.SelectedIndexChanged += new System.EventHandler(startButtonEnabled);

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
            for ( int i=0; i< listOfFormDefaultTest.Count; i++  )
            {
                if (listOfFormDefaultTest[i].Name.Equals(currentTest))
                {
                    index = i;
                }
            }
            
            
            
            if (radioButtonTestModeTest.Checked)
            {
                _formTest = new FormTest(currentTest, currentVzvod, currentStudent);
                listFormTests.Add(_formTest);
                _formTest.initTest(listOfFormDefaultTest[index]);
                _formTest.Visible = true;
                //_formTest._listPanelTasks[0].Visible = true;

                _formTest.Text = "ТЕСТ." + currentTest + ". " + currentVzvod + " взвод. " + "Студент " + currentStudent;
            }

            if (radioButtonTestModeStudy.Checked)
            {
                _formStudy = new FormStudy(currentTest, currentVzvod, currentStudent);
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
    }
}
