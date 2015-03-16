namespace VersionAttribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
                    AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    public class VersionAttribute:Attribute
    {
        public string Major { get; private set; }
        public string Minor { get; private set; }

        public VersionAttribute(string major, string minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }
}
