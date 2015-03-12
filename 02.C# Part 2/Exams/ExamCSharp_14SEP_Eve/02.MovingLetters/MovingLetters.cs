using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MovingLetters
{
    class MovingLetters
    {
        static void Main(string[] args)
        {

            string[] list = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);


            StringBuilder word = CreateString(list);
            //Console.WriteLine(word);

            int count = word.Length;
            StringBuilder temp = new StringBuilder();
            
                 temp = MoveLetter(word);
                
            

            Console.WriteLine(word);
        }

        static StringBuilder CreateString(string[] list)
        {
            int max = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Length > max)
                {
                    max = list[i].Length;
                }
            }

            //for (int i = 0; i < list.Length; i++)
            //{
            //    list[i] = list[i].PadLeft(max, ' ');
            //}
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < list.Length; j++)
                {


                    {
                        if (i < list[j].Length)
                        {
                            int lastLetter = list[j].Length - 1 - i;
                            text.Append(list[j][lastLetter]);
                        }



                    }
                }
            }

                return text;
            
        }
            

        static StringBuilder MoveLetter(StringBuilder word)
        {
            StringBuilder rem = new StringBuilder(word.ToString());
            for (int index = 0; index < word.Length; index++)
            {
                int move = 0;
                if (word[index] < 91)
                {
                    move = word[index] - 'A' + 1;
                }
                else
                {
                    move = word[index] - 'a' + 1;
                }

                move = (move%word.Length  + index) % word.Length;
                char curSymbol = word[index];

                
                word.Remove(index, 1);

                word.Insert(move, curSymbol);

                
                    
            }
            return rem;
            
        }
    }
}
