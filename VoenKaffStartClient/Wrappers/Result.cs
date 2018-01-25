using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenKaffStartClient.Wrappers
{
    class Result
    {
        public string TestName { get; set; }
        public string Platoon { get; set; }
        public string StudentName { get; set; }
        public string Mark { get; set; }
        public DateTime Timestamp { get; set; }
        public string ResultType { get; set; }
        public string Course { get; set; }
    }
}
