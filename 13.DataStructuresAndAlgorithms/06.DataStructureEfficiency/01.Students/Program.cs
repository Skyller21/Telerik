using System.Collections.Generic;

namespace _01.Students
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var dict = new SortedDictionary<string, List<Student>>();
            ProcessFile(dict);

            foreach (var entry in dict)
            {
                Console.WriteLine("{0}: {1}", entry.Key, string.Join(", ", entry.Value.OrderBy(s => s.LastName).ThenBy(s => s.FirstName)));
            }

        }

        private static void ProcessFile(SortedDictionary<string, List<Student>> dict)
        {
            using (var reader = new StreamReader("../../students.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var arr = line.Split('|');
                        if (arr.Count() == 3)
                        {
                            var studentToAdd = new Student()
                            {
                                FirstName = arr[0].Trim(),
                                LastName = arr[1].Trim()
                            };

                            var course = arr[2].Trim();
                            if (!dict.ContainsKey(course))
                            {
                                dict.Add(course, new List<Student>());
                            }

                            dict[course].Add(studentToAdd);
                        }
                    }
                }
            }
        }
    }
}
