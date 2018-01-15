﻿using System;
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
    public partial class FormResults : Form
    {
        string _currentTest;
        string _currentVzvod;
        string _currentStudent;
        public FormResults(string currentTest, string currentVzvod, string currentStudent)
        {
            InitializeComponent();
            _currentTest = currentTest;
            _currentVzvod = currentVzvod;
            _currentStudent = currentStudent;

            labelTestName.Text = _currentTest;
            labelVzvodName.Text = _currentVzvod;
            labelFIOName.Text = _currentStudent;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonCloseTest_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
