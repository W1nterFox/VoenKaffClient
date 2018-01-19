using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient
{
    public class TestLoader
    {
        public List<Test> LoadTestsFromFile(string pathToTest)
        {
            var json = System.IO.File.ReadAllText(pathToTest);
            return JsonConvert.DeserializeObject<List<Test>>(json);
        }

        public List<Test> LoadTestsFromFolder(string pathToFolder)
        {

            var result = new List<Test>();

            foreach (var pathToTest in GetTestFilePaths(pathToFolder))
            {
                result.AddRange(LoadTestsFromFile(pathToTest));
            }

            return result;
        }

        private static IEnumerable<string> GetTestFilePaths(string pathToFolder)
        {
            var directoryInfo = new DirectoryInfo(pathToFolder);
            var testFiles = directoryInfo.GetFiles("*.test");
            return testFiles.Select(testFile => testFile.FullName);
        }
    }
}
