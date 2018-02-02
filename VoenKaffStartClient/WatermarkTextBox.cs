using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoenKaffStartClient
{
    class WatermarkTextBox 
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        
        //SendMessage(textBox1.Handle, EM_SETCUEBANNER, 0, "Username");
        //SendMessage(textBox2.Handle, EM_SETCUEBANNER, 0, "Password");
    }
}
