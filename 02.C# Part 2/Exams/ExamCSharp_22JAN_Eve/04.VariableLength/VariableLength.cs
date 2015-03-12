using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.VariableLength
{
    class VariableLength
    {
        static void Main(string[] args)
        {
            string[] list = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string numbers = "";

            for (int i = 0; i < list.Length; i++)
            {
                numbers += Convert.ToString(int.Parse(list[i]), 2).PadLeft(8,'0');
            }

            int n = int.Parse(Console.ReadLine());
            Dictionary<int, string> dict = new Dictionary<int, string>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                dict.Add(int.Parse(line.Substring(1)), line[0].ToString());
            }

            Regex regex = new Regex("1{1,}");

            Match m = regex.Match(numbers);
            List<int> nums = new List<int>();

            while (m.Success)
            {
                nums.Add(m.Length);
                m = m.NextMatch();
            }

            foreach (int item in nums)
            {
                if (dict.ContainsKey(item))
                {
                    Console.Write(dict[item]);
                }
            }
            Console.WriteLine();
        }
    }
}
