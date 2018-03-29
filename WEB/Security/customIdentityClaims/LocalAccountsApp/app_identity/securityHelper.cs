using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace LocalAccountsApp.app_identity
{
    public class securityHelper
    {
        public static Task SendMailAsynk(string subjet, string body, string from, string to)
        {
            //if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            //    return null;

            String smtp = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "smtp");
            Int32 port = Convert.ToInt32(Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "port"));
            Boolean enableSsl = Convert.ToBoolean(Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "enableSsl"));

            String email = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "email");
            String username = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "username");
            String pwd = Fwk.Configuration.ConfigurationManager.GetProperty("MailSettings", "password");

            if (String.IsNullOrEmpty(from))
            {
                from = email;
            }
            //Crea el nuevo correo electronico con el cuerpo del mensaje y el asutno.
            MailMessage wMailMessage = new MailMessage() { Body = body, Subject = subjet };
            wMailMessage.IsBodyHtml = true;

            //Asigna el remitente del mensaje de acuerdo a direccion obtenida en el archivo de configuracion.
            wMailMessage.From = new MailAddress(from);
            //Asigna los destinatarios del mensaje de acuerdo a las direcciones obtenidas en el archivo de configuracion.
            //foreach (string recipient in MailRecipients)
            //{
            wMailMessage.To.Add(new MailAddress(to));
            //}

            SmtpClient smtpClient = new SmtpClient(smtp, port);
            smtpClient.EnableSsl = enableSsl;
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            NetworkCredential cred = new NetworkCredential(username, pwd);
            smtpClient.Credentials = cred;


            //Envia el correo electronico.
            //try
            //{

            return smtpClient.SendMailAsync(wMailMessage);
            //}
            //catch (Exception) { }
        }
    }
}