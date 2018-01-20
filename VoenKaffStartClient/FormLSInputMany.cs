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
    public partial class FormLSInputMany : Form
    {
        FormPlatoon _formChooseVzvod;
        List<string> _linesRTB = new List<string> { };
        public FormLSInputMany(FormPlatoon formChooseVzvod)
        {
            InitializeComponent();
            _formChooseVzvod = formChooseVzvod;

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }


        private void buttonRichTextBoxClear_Click(object sender, EventArgs e)
        {
            richTextBoxLS.Clear();
        }

        private void buttonRichTextBoxAddLS_Click(object sender, EventArgs e)
        {
            if (richTextBoxLS.Lines != null)
            {
                foreach (string line in richTextBoxLS.Lines)
                {
                    if (!line.Equals("") && line != null)
                    {
                        _linesRTB.Add(line);
                        ((ListBox)(_formChooseVzvod.Controls.Find("listBoxLS", true)[0])).Items.Add(line);
                        VzvodAndLs.Get()[((ListBox)(_formChooseVzvod.Controls.Find("listBoxVzvoda", true)[0])).SelectedItem.ToString()].Add(line);
                    }
                }

                this.Visible = false;
                _formChooseVzvod.Visible = true;
                richTextBoxLS.Lines = null;
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _formChooseVzvod.Visible = true;
            richTextBoxLS.Lines = null;
        }

        private void richTextBoxLS_TextChanged(object sender, EventArgs e)
        {
            if (richTextBoxLS.Text == "" || richTextBoxLS.Text == null)
            {
                buttonRichTextBoxAddLS.Enabled = false;
            }
            else
            {
                buttonRichTextBoxAddLS.Enabled = true;
            }
        }
    }
}
