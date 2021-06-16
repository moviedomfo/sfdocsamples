using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace GoogleGmailAPi
{


    public class GmailWrapper
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
         //public static string[] Scopes = { GmailService.Scope.MailGoogleCom };
        static string[] Scopes = {GmailService.Scope.GmailSend, GmailService.Scope.GmailAddonsCurrentActionCompose, 
            GmailService.Scope.GmailAddonsCurrentMessageAction };

        public static string ApplicationName = "CELAMFacturacion";

        static GmailWrapper()
        {
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


        void Reautorize()
        {
            ClientSecrets secrets = new ClientSecrets()
            {
                ClientId = "569056386146-efk90ejdrvad59k2fuo81ooae9iok4b9.apps.googleusercontent.com",
                ClientSecret = "xCffin46deucsQwcGdDNR_Zi"
            };

            var token = new TokenResponse { RefreshToken = "" };
            var credentials = new UserCredential(new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = secrets
                }),
                "user",
                token);

            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = ApplicationName
            });
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

    }
}
