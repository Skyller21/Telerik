using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.EncodeEncrypt
{
    class EncodeEncrypt
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string cypher = Console.ReadLine();
            int lengthOfCypher = cypher.Length;

            double n = Math.Ceiling((double)message.Length / (cypher.Length));

            double m = Math.Ceiling((double)cypher.Length / (message.Length));

            
            StringBuilder longCypher = new StringBuilder();
            StringBuilder longMessage = new StringBuilder();
            
            if (n > 0)
            {
                
                for (int i = 0; i < n; i++)
                {
                    longCypher.Append(cypher);
                }
                StringBuilder encr = Encrypt(message, longCypher);
                encr.Append(cypher);
                StringBuilder encod = Encode(encr);
                encod.Append(lengthOfCypher);


                Console.WriteLine(encod);
            }
            else if (m > 0)
            {
                
                for (int i = 0; i < m; i++)
                {
                    longMessage.Append(message);
                }
                StringBuilder encr = EncryptWithLongerCypher(cypher, longMessage);
                encr.Append(longCypher);
                StringBuilder encod = Encode(encr);
                encod.Append(lengthOfCypher);


                Console.WriteLine(encod);
            }

            
            

            //Console.WriteLine(encr);

            

            
            //Console.WriteLine(Encode(Encrypt(message, longCypher).Append(cypher)).Append(lengthOfCypher));
            //Console.WriteLine(Encode(new StringBuilder("aaaabbbccccaa")));
        }

        static StringBuilder EncryptWithLongerCypher(string longMessage, StringBuilder cypher)
        {
            StringBuilder encrypted = new StringBuilder();
            int count = 1;
            for (int i = 0; i < cypher.Length; i++)
            {
                char currentSymbol = new char();
                char tempSymbol = new char();
                for (int j = 0; j < count; j++)
                {
                    currentSymbol = (char)(((longMessage[i] - 'A') ^ (cypher[i] - 'A')));
                }
                currentSymbol = (char)(currentSymbol + 65);
                encrypted.Append(currentSymbol);
                if (i % (cypher.Length - 1) == 0 && i != 0)
                {
                    count++;
                }
            }


            return encrypted;
        }

        static StringBuilder Encrypt(string message, StringBuilder longCypher)
        {
            StringBuilder encrypted = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                char currentSymbol = (char)(((message[i] - 'A') ^ (longCypher[i] - 'A')) + 65);
                encrypted.Append(currentSymbol);
            }

            return encrypted;
        }

        static StringBuilder Encode(StringBuilder encrypted)
        {
            StringBuilder encoded = new StringBuilder(encrypted.ToString());
            //TODO
            Regex regex = new Regex("(.)\\1{1,}");

            foreach (Match m in regex.Matches(encrypted.ToString()))
            {
                string replace = m.Length + m.Value.ToString().Substring(0, 1);

                if (replace.Length < m.Length)
                {
                    int add = encrypted.Length - encoded.Length;
                    string temp = new string('@', m.Length);
                    encoded = encoded.Replace(m.Value.ToString(), new string('@', m.Length), m.Index - add, m.Length);
                    encoded = encoded.Replace(temp, replace);

                }
                //else
                //{
                //    encoded.Append(m.Value);
                //}
            }



            //TODO
            return encoded;
        }
    }
}
