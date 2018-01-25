using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenKaffStartClient
{
    class Courses
    {
        private static List<string> _instance;
        private Courses()
        {
        }

        public static List<string> Get()
        {
            if (_instance == null)
            {
                _instance = new List<string> { };
            }

            return _instance;
        }

        public static void Set(List<string> list)
        {
            _instance = list;
        }
    }
}
