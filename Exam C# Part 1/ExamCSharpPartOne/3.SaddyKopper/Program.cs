using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class Program
{
    static void Main(string[] args)
    {
        string number = Console.ReadLine();
        BigInteger product = 1;
        List<int> list = new List<int>();
        int count = 0;
        int sum = 0;
        while (number.Length > 1)
        {
            sum = 0;
            for (int i = 0; i < number.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    sum = sum + int.Parse(number[i].ToString());
                }
                list.Add(sum);
                //Console.WriteLine(sum);
            }
            if (count == 10)
            {
                break;
            }
            for (int i = 0; i < list.Count; i++)
            {
                product = product * list[i];
            }
            if (product>9&&count!=9)
            {
                number = product.ToString();
                
                product = 1;
            }
            
            else
            {
                number = product.ToString();
            }
            list.Clear();
            count++;
            
        }

        if (count==10)
        {
            Console.WriteLine(product);
        }
        else
        {
            Console.WriteLine(count);
            Console.WriteLine(product);
        }
        
        
        
    }


    static BigInteger EvenPositionSum(string strNum,BigInteger product)
    {
        //string strNum = number.ToString();
        if (strNum.Length<=1)
        {
            return product;
        }
        ulong sum = 0;

        for (int i = 0; i < strNum.Length; i++)
        {
            if (i % 2 == 0)
            {
                sum += ulong.Parse(strNum[i].ToString());
            }
        }
        strNum = strNum.Remove(strNum.Length - 1, 1);
        product = product*sum;
        return EvenPositionSum(strNum,product);
    }
}



