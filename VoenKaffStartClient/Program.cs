﻿using System;
using System.Windows.Forms;

namespace VoenKaffStartClient
{
    public static class Program
    {

        [STAThread]
        public static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
