using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StringSearchingService
{
    [ServiceContract]
    public interface IStringSearchingService
    {

        [OperationContract]
        [WebGet]
        int FindStringInString(string text, string searched, bool isCaseSensitive);
    }


    
}
