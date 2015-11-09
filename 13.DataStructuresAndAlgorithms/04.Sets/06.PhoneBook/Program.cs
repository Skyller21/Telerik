using System;

namespace _06.PhoneBook
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("../../phones.txt");

            var dict = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            using (reader)
            {
                var line = reader.ReadLine();

                while (line != null)
                {

                    var arr = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToList();

                    var phone = Regex.Replace(arr[2], "\\s+", "").Replace("^+359", "0");

                    var name = arr[0];
                    var town = new CultureInfo("en-US").TextInfo.ToTitleCase(arr[1]);


                    if (dict.ContainsKey(town))
                    {

                        if (dict[town].ContainsKey(name))
                        {
                            dict[town][name].Add(phone);
                        }
                        else
                        {
                            dict[town].Add(name, new HashSet<string>() { phone });
                        }
                    }
                    else
                    {
                        var namePhones = new Dictionary<string, HashSet<string>>();
                        namePhones.Add(name, new HashSet<string>() { phone });
                        dict.Add(town, namePhones);
                    }

                    line = reader.ReadLine();
                }

                foreach (var townPeople in dict)
                {
                    foreach (var peoplePhone in townPeople.Value)
                    {
                        Console.WriteLine(townPeople.Key);
                        Console.WriteLine(peoplePhone.Key);
                        Console.WriteLine(string.Join(",", peoplePhone.Value));
                    }
                }
            }
        }
    }
}
