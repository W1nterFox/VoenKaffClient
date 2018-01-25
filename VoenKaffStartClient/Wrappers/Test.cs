using System.Collections.Generic;

namespace VoenKaffStartClient.Wrappers
{
    public class Test
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public Marks Marks { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}