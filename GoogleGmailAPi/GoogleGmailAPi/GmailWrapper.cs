using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fwk.Exceptions;
using Fwk.HelperFunctions;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;

namespace GoogleGmailAPi
{


    public class GmailWrapper
    {
        static socios_viewBE socio;
        static  string facturaLink = "<a href=\"{0}\">{1}</a>";
        static  string tr = "<tr><td> {0} </td><th> {1}</th> <th> {2} </th>  </tr>";
        static string table = "<table class=\"blueTable\"><thead><tr><th> Nro. abonado  </th>    <th> Factura </th>  <th> Direccion </th>  </tr></thead><tbody>";
        static string txtBody = String.Empty;
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        //public static string[] Scopes = { GmailService.Scope.MailGoogleCom };
        static string[] Scopes = {GmailService.Scope.GmailSend, GmailService.Scope.GmailAddonsCurrentActionCompose, 
            GmailService.Scope.GmailAddonsCurrentMessageAction };

        public static string ApplicationName = "CELAMFacturacion";

        static GmailWrapper()
        {
            string mail_template_file = String.Empty;
            try
            {
                mail_template_file = "Email_aviso_facturacion_disponible.html";
                txtBody = FileFunctions.OpenTextFile(mail_template_file);
            }
            catch (Exception ex)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("Error al cargar la plantilla mail_aviso_facturacion_disponible.html ");
                str.AppendLine("mail_template_file = " + mail_template_file);

                throw new FunctionalException(9001, ex, str.ToString());

            }

            socio = new socios_viewBE();
            socio.Nombre = "TestNombre";
            socio.Apellido = "TestApell";
            socio.NroAbonado = 300;
            socio.NroSocio = 2300;
        }

        public static void SendHTMLmessage(string to)
        {
            //Create Message
            MailMessage mail = new MailMessage();
            mail.Subject = "Facturación disponible CELAM: Período 18";
            mail.Body = FillBody(socio,new StringBuilder (table)).ToString();
            mail.From = new MailAddress("celamltda@gmail.com", "CELAM Facturacion");
            mail.To.Add(new MailAddress(to));
            mail.IsBodyHtml = true;
            string attImg = "img_header_content_id.jpg";
            mail.Attachments.Add(new Attachment(attImg));
 
            MimeKit.MimeMessage mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mail);

            Message message = new Message();
            message.Raw = Base64UrlEncode(mimeMessage.ToString());
            //Gmail API credentials
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart2.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            //Send Email
            var result = service.Users.Messages.Send(message, "me").Execute();
        }

        public static IList<Label> getLabels_Me()
        {

            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);

                // Create Gmail API service.
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // Define parameters of request.
                UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

                // List labels.
                IList<Label> labels = request.Execute().Labels;


                return labels;
            }


        }
        public static void Send1(string to, string boddy)
        {
            ClientSecrets secrets = new ClientSecrets()
            {
                ClientId = "569056386146-efk90ejdrvad59k2fuo81ooae9iok4b9.apps.googleusercontent.com",
                ClientSecret = "xCffin46deucsQwcGdDNR_Zi"
            };
            UserCredential credential;

        
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
             //   string credPath = "token.json";
             //credentials = new UserCredential(new GoogleAuthorizationCodeFlow(
             //   new GoogleAuthorizationCodeFlow.Initializer
             //   {
             //       ClientSecrets = secrets
             //   }),
             //   "user",
             //   token);
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromFile("credentials.json").Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None).Result;


                // Create Gmail API service.
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                string plainText = "To:" + to + "\r\n" +
                        " Subject: Gmail Send API Test\r\n" +
                        "Content-Type: text/html; charset=us-ascii\r\n\r\n" +
                        "<h1>TestGmail API Testing for sending <h1>";
                // Define parameters of request.
                UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

                var gmailMessage = new Google.Apis.Gmail.v1.Data.Message();
                gmailMessage.Raw = Base64UrlEncode(plainText.ToString());
                service.Users.Messages.Send(gmailMessage, "me").Execute();
                // List labels.


            

        }


        public static void Send2(string to, string boddy)
        {

            UserCredential credential;
            
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
      
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                

                // Create Gmail API service.
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                string plainText =  "To:" + to + "\r\n" +
                        " Subject: Gmail Send API Test\r\n" +
                        "Content-Type: text/html; charset=us-ascii\r\n\r\n" +
                        "<h1>TestGmail API Testing for sending <h1>";
                // Define parameters of request.
                UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

                var gmailMessage = new Google.Apis.Gmail.v1.Data.Message();
                gmailMessage.Raw = Base64UrlEncode(plainText.ToString());
                service.Users.Messages.Send(gmailMessage, "me").Execute();
                // List labels.


            }

        }


        
        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }

        static StringBuilder FillBody(socios_viewBE socio, StringBuilder strLinks)
        {
            

            StringBuilder strBody = new StringBuilder(txtBody);
            strBody.Replace("{NRO_SOCIO}", socio.NroSocio.ToString());
            strBody.Replace("{NOMBRE_SOCIO}", socio.NOMBRES_ABONADOS);
            strBody.Replace("{pdf_LINKs}", strLinks.ToString());
            strBody.Replace("{PERIODO}", "MAYO 3022");

            return strBody;
        }
    }
}
