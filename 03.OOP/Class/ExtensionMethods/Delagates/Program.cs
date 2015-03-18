using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delagates
{
    class Program
    {
        public delegate int SimpleDelegate(string param);
        static void Main(string[] args)
        {

            //Delegates are reference types
             SimpleDelegate d = new SimpleDelegate(TestMethod);

             d = new Program().SomeMethod;

             //d += delegate(string param)

             Console.WriteLine(d("HAHAHAH")); //Instance


             Console.WriteLine(d("text"));


             
        }

        public static int TestMethod(string param)
        {
            return param.Length;
        }

        public int SomeMethod(string param)//Instance
        {
            return param.Length;
        }

        //Multicast += return only the last method result. Doing the work of all the methods.


    }
}

