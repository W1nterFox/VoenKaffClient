using System.Collections.Generic;

namespace VoenKaffStartClient.Wrappers
{
    public class Tests
    {
        public List<Test> TestList { get; set; } = new List<Test>();
        public Dictionary<string, List<string>> PlatoonList { get; set; } = new Dictionary<string, List<string>>();
        public List<string> CourseList { get; set; } = new List<string>();
    }
}
