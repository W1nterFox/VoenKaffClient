using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenKaffStartClient.Wrappers
{
    public class TaskElement
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Answer { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Point Point { get; set; }
        public string Media { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
    }
}
