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
    public partial class FormDefaultTest : Form
    {

        public string _testName { get; set; }
        public List<int> _listMarks { get; set; }

        public FormDefaultTest(string testName, List<int> listMarks)
        {
            InitializeComponent();

            _testName = testName;
            _listMarks = listMarks;
        }

        public void setTestName(string testName)
        {
            _testName = testName;
            this.Text = testName;
        }

        public void setTesListMarks(List<int> listMarks)
        {
            _listMarks = listMarks;
        }
    }
}
