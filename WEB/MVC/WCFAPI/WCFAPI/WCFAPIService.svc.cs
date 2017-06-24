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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WCFAPIService : IWCFAPIService
    {
        public PMOFileList RetrivePMOList()
        {

            PMOFileList list = PmoDAC.Get();
            return list;
        }

        public PMOContract RetrivePMOListParamas(string filterName)
        {
            if (filterName == null)
            {
                throw new ArgumentNullException("filterName");
            }
            

            PMOFileList list = PmoDAC.Get();
            var slist= list.Where(p=>p.Description.Contains(filterName));
            PMOContract res = new PMOContract();
            res.PMOFileList = new PMOFileList();

            res.PMOFileList.AddRange(slist.ToList());
            return res;
        }


     
    }

    
}
