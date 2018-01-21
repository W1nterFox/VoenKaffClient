using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenKaffStartClient.Wrappers
{
    public class Task
    {
        public string Name { get; set; }
        public List<TaskElement> TaskElements { get; set; } = new List<TaskElement>();

    }
}
