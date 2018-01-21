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
    public partial class FormResultsStudy : Form
    {
        string _currentTest;
        string _currentVzvod;
        string _currentStudent;
        public FormResultsStudy(FormStudy formStudy)
        {
            InitializeComponent();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            _currentTest = formStudy._currentTest;
            _currentVzvod = formStudy._currentVzvod;
            _currentStudent = formStudy._currentStudent;

            labelTestName.Text = _currentTest;
            labelVzvodName.Text = _currentVzvod;
            labelFIOName.Text = _currentStudent;
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
