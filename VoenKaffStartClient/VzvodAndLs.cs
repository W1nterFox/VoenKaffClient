using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoenKaffStartClient
{
    class VzvodAndLs
    {
        private static Dictionary<string, List<string>> _instance;
        private VzvodAndLs()
        {
        }

        public static Dictionary<string, List<string>> Get()
        {
            if (_instance == null)
            {
                _instance = new Dictionary<string, List<string>> { };
            }

            return _instance;
        }

        public static void Set(Dictionary<string, List<string>> list)
        {
            _instance = list;
        }
    }
}
