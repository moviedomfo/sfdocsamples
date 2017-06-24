using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SecureWcf
{
    [ServiceContract]
    public interface ICoreSecurityAspnet
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        string Test_WebGet_Json(string value);


        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml)]
        string Test_POST_XML(string value);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string Test_POST_Json(string value);



        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        String Test_GET_REST_Json(String value);
    }
}