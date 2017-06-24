using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Common.BE;

namespace WCFAPI
{
    public class PmoDAC
    {
        public static String xml;
        static PmoDAC()
        {
             xml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"pmo.xml");
        }
        internal static PMOFileList Get()
        {
            PMOFileList list = Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(PMOFileList), xml) as PMOFileList;
            return list;
        }
    }
}