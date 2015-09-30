using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.IO;

namespace Aggregate
{
    [Serializable]
    [SqlUserDefinedAggregate(
       Format.UserDefined,
       IsInvariantToDuplicates = false, // receiving the same value again changes the result
       IsInvariantToNulls = false,      // receiving a NULL value changes the result
       IsInvariantToOrder = true,       // the order of the values doesn't affect the result
       IsNullIfEmpty = true,            // if no values are given the result is null
       MaxByteSize = -1,
       Name = "StrConcat"              // name of the aggregate
    )]


    public struct StringConcat:IBinarySerialize
        
    {
        private List<string> list;
        public void Init()
        {
            this.list = new List<string>();
        }
        public void Accumulate(SqlString value)
        {
            if (!string.IsNullOrEmpty(value.Value))
            {
              this.list.Add(value.Value);
            }
        }
        public void Merge(StringConcat group) 
        {
            this.list.AddRange(group.list);
        }

        public SqlString Terminate()
        {
             if (this.list.Count > 0)
             {
                 string returnString = string.Join(", ",this.list);
                 return new SqlString(returnString);
             }
             return null;
        }

         public void Read(BinaryReader reader)
         {
             if (reader == null)
             {
                 throw new ArgumentException("Reader is null");
             }
             this.list = new List<string>() { reader.ReadString() };
         }

         public void Write(BinaryWriter writer)
         {
             if (writer == null)
             {
                 throw new ArgumentException("Writer is null");
             }
             writer.Write(string.Join(", ",this.list));
         }
    }
}
