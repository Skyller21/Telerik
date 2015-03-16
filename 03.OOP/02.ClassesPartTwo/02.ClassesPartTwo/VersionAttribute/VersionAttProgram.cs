namespace VersionAttribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    [VersionAttribute("1","05b")]
    class VersionAttProgram
    {
        static void Main(string[] args)
        {
            Type type = typeof(VersionAttProgram);
            object[] allAttributes = type.GetCustomAttributes(false);

            foreach (object att in allAttributes)
            {
                VersionAttribute v = (VersionAttribute)att;
                Console.WriteLine("Current Version: {0}.{1}", v.Major,v.Minor);
            }
        }
    }
}
