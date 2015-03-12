using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EncodeAndDecode
{
    static void Main()
    {
        string strTest = "Yesterday, all my trobles seems to far allay that`s to looked to heard to stay, o-o I beleve in yesterday. Some way I`m not the half man i must to be. Does the shadow hanging over me? O, yesterday came some other way. Why she have to go? I don`t know, she loudn`t say. I sad something low, now I love for yesterday. Yesterday, love was so need in game to play. Now I need a place to hide allay. O-o, I beleve in yesterday.";
        string key = "Beatles";
        Console.WriteLine("Encoded message is:\n\r");
        //Encrypt the text
        Console.WriteLine(Encode(strTest, key));
        //Decript the text
        Console.WriteLine("\n\rDecoded message is:\n\r");
        Console.WriteLine(Encode(Encode(strTest,key),key));
    }

    static string Encode(string str, string key)
    {
        char[] arr = str.ToCharArray();
        char[] keyArr = key.ToCharArray();

        StringBuilder tempStr = new StringBuilder();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = (char)(arr[i] ^ keyArr[i % keyArr.Length]);
            tempStr.Append(arr[i]);
        }
        string finStr = tempStr.ToString();
        return finStr;
    }
}

