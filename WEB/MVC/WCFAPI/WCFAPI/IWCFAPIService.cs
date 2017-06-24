using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using API.Common.BE;

namespace WCFAPI
{
    
    [ServiceContract]
    public interface IWCFAPIService
    {

        [OperationContract]
        PMOFileList RetrivePMOList();

        [OperationContract]
        PMOContract RetrivePMOListParamas(String filterName);

  
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class PMOContract
    {
        PMOFileList list = null;
      

        [DataMember]
        public API.Common.BE.PMOFileList PMOFileList
        {
            get { return list; }
            set { list = value; }
        }

       
    }
}
