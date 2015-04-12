using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Interfaces;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        protected IList<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>(); 
        public string Name { get; private set; }

        public string Content { get; protected set; }

        public Document(string name,string content=null)
        {
            this.Name = name;
            this.Content = content;
        }

        
       

        public virtual void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "name")
            {
                this.Name = value;
            }
            else if(key.ToLower()=="content")
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            //output.Add(new KeyValuePair<string, object>(this.Name,));
        }

        //public string ToString()
        //{
        //    var list = new List<KeyValuePair<string, object>>();
        //    this.SaveAllProperties(list);
        //    return 4;
        //}

        
    }
}
