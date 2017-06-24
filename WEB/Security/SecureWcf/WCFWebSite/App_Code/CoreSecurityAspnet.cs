using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace SecureWcf
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CoreSecurityAspnet:ICoreSecurityAspnet
    {
        #region ICoreSecurityAspnet Members

        public string Test_WebGet_Json(string value)
        {
            return string.Format("Testing Test_Get at {0}, your input is {1}", System.DateTime.Now.ToString(), value);
        }

        public string Test_POST_XML(string value)
        {
            return string.Format("Testing Test_POST_XML at {0}, your input is {1}", System.DateTime.Now.ToString(), value);
        }

        public string Test_POST_Json(string value)
        {
            return string.Format("Testing Test_POST_Json at {0}, your input is {1}", System.DateTime.Now.ToString(), value);
        }

        public string Test_GET_REST_Json(string value)
        {
            return string.Format("Testing Test_POST_XML at {0}, your input is {1}", System.DateTime.Now.ToString(), value);
        }
          
        #endregion
    }
}