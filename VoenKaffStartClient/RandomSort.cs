using System;
using System.Collections.Generic;

namespace VoenKaffStartClient
{
    public static class RandomSort<T>
    {
        public static ICollection<T> Sort(ICollection<T> source)
        {
            var data = new List<T>();
            var random = new Random();
            foreach (var s in source)
            {
                int j = random.Next(data.Count + 1);
                if (j == data.Count)
                {
                    data.Add(s);
                }
                else
                {
                    data.Add(data[j]);
                    data[j] = s;
                }
            }
            return data;
        }
    }
}