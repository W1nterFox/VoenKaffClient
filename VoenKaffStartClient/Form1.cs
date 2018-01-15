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
    public partial class Form1 : Form
    {
        List<String> listPanelsTasks;
        public Form1()
        {
            InitializeComponent();
            testName.Items.AddRange(new string[] { "Номенклатура карт", "Дальность до цели" });
            vzvodName.Items.AddRange(new string[] { "121", "122", "123", "131", "132", "133", "141", "142", "143" });

            vzvodName.SelectedIndexChanged += new System.EventHandler(nameVzvod_SelectedIndexChanged);


            listPanelsTasks = new List<String>();
            //nameFIO.Items.AddRange(new string[] {""});
        }

        private void nameVzvod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string selectedVzvod = (string)vzvodName.SelectedItem;
            FIOName.Items.Clear();
            FIOName.Items.AddRange(getStudentsByVzvod(selectedVzvod));
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
            FormTest formTest = new FormTest();

            formTest.Text = testName.SelectedItem.ToString() + ". " + vzvodName.SelectedItem.ToString() + " взвод. " + "Студент " + FIOName.SelectedItem.ToString();
            formTest.Visible = true;


        }
    }
}
