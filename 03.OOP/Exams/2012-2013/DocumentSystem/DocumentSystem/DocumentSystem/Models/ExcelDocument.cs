using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Interfaces;

namespace DocumentSystem.Models
{
    class ExcelDocument : OfficeDocument
    {
        public ExcelDocument(string name, string content = null, int size = 0,string version = null, int numberOfRows = 0, int numberOfCols = 0)
            : base(name, content,size,version)
        {
            this.NumberOfRows = numberOfRows;
            this.NumberOfCols = numberOfCols;
        }

        public int NumberOfRows { get; private set; }
        public int NumberOfCols { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "rows")
            {
                this.NumberOfRows =  int.Parse(value);
            }
            else if (key.ToLower() == "cols")
            {
                this.NumberOfCols = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }

        }

    }
}
