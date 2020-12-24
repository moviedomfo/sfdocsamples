using Fwk.Exceptions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace fwk.template.api.common
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(object result)
            : base(200)
        {
            Result = result;
        }
    }

    public class ApiErrorResponse : ApiResponse
    {
        public string ErrorId { get; set; }
        //string errorType = null;
        public ApiErrorResponse(HttpStatusCode statusCode, string message = null, string errorId = null) : base((int)statusCode, message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="ex"></param>
        public ApiErrorResponse(int? statusCode, Exception ex) : base(statusCode)
        {

            setMessageAndStatus(ex);

            if (!statusCode.HasValue && !string.IsNullOrEmpty(ErrorId))
            {
                int id;
                int.TryParse(ErrorId, out id);
                if (id >= 400 && id < 500)
                {
                    this.StatusEnum = HttpStatusCode.Unauthorized;
                    return;
                }


                this.StatusEnum = HttpStatusCode.InternalServerError;
            }

        }

        public IEnumerable<string> Errors { get; }



        void setMessageAndStatus(Exception ex)
        {

            //if (ex.GetType() == typeof(HttpResponseException))
            //        msg = ex.Message;
            //return msg = ex.Message;
            if (ex.GetType() == typeof(FunctionalException))
            {
                var te = ex as FunctionalException;

                this.Message = te.Message;
                this.ErrorId = te.ErrorId;
            }
            if (ex.GetType() == typeof(TechnicalException))
            {
                var te = ex as TechnicalException;

                this.Message = te.Message;
                this.ErrorId = te.ErrorId;
            }

            if (ex.InnerException != null)
            {

                this.Message = this.Message + ex.InnerException.Message;
                if (ex.InnerException.GetType() == typeof(System.Net.Sockets.SocketException))
                {
                    var e = ex.InnerException as System.Net.Sockets.SocketException;
                    if (e.ErrorCode == 10060)
                        this.Message = "La url no es accesible " + Environment.NewLine + this.Message;
                }
                //if (ex.InnerException.GetType() == typeof(WebExcepcion))
                //{
                //    var e = ex.InnerException as System.Net.Sockets.SocketException;
                //    if (e.ErrorCode == 10060)
                //        msg = "WAPI wapiAppSettings.apiConfig.apiDomain no es accesible " + Environment.NewLine + msg;
                //}
            }

            else
                this.Message = ex.Message;


        }





    }
    public class ApiResponse
    {
        //public int StatusCode { get; set; }
        public HttpStatusCode StatusEnum { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>

        public ApiResponse(int? statusCode, string message = null)
        {
            if (!statusCode.HasValue)
                statusCode = (int)HttpStatusCode.InternalServerError;

            //StatusCode = statusCode.Value;
            StatusEnum = (HttpStatusCode)statusCode.Value;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }




        private string GetDefaultMessageForStatusCode(int? statusCode)
        {
            if (statusCode.HasValue)
            {
                //var lista = (HttpStatusCode[])Enum.GetValues(typeof(HttpStatusCode));
                var status = Enum.GetValues(typeof(HttpStatusCode)).Cast<HttpStatusCode>();

                if (status.Any(i => i == (HttpStatusCode)statusCode))
                    return ReasonPhrases.GetReasonPhrase(statusCode.Value);
            }


            switch (statusCode)
            {

                case 450:
                    return "User not found";
                case 451:
                    return "User or password incorrect";
                default:
                    return null;
            }
        }



    }

}
