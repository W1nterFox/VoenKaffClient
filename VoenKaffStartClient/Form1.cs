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
    public partial class Form1 : Form
    {
        List<String> listPanelsTasks;
        public string currentTest;
        public string currentVzvod;
        public string currentStudent;

        List<Test> listOfFormDefaultTest = new List<Test> { };

        public Form1()
        {
            InitializeComponent();
            testName.Items.AddRange(new string[] { "Номенклатура карт", "Дальность до цели" });
            vzvodName.Items.AddRange(new string[] { "121", "122", "123", "131", "132", "133", "141", "142", "143" });

            var testLoader = new TestLoader();
            listOfFormDefaultTest = testLoader.LoadTestsFromFolder("C:\\projects\\Sanya");

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


            if (radioButtonTestModeTest.Checked)
            {
                FormTest formTest = new FormTest(currentTest, currentVzvod, currentStudent);

                formTest.Text = "ТЕСТ." + currentTest + ". " + currentVzvod + " взвод. " + "Студент " + currentStudent;
                formTest.Visible = true;
            }

            if (radioButtonTestModeStudy.Checked)
            {
                FormStudy formStudy = new FormStudy(currentTest, currentVzvod, currentStudent);

                formStudy.Text = "ОБУЧЕНИЕ. " + currentTest + ". " + currentVzvod + " взвод. " + "Студент " + currentStudent;
                formStudy.Visible = true;
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
