using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using EditoraMazzoni.WebMvc.Web.Utils;

namespace EditoraMazzoni.WebMvc.Web.Utils
{
    public class EnviarEmail
    {
        SmtpClient smtpClient;
        MailAddress from;
        MailAddress to;
        MailMessage mailMessage;

        /// <summary>
        /// Construtor da classe responsável por enviar e-mail
        /// </summary>
        /// <param name="mailFrom">E-mail de origem</param>
        /// <param name="nameFrom">Nome do destinatário</param>
        /// <param name="emailTo">Destinatário</param>
        /// <param name="message">Mensagem do email</param>
        /// <param name="subject">Assunto email</param>
        public EnviarEmail(string mailFrom, string nameFrom, string emailTo, string message, string subject)
        {
            
                // vamos instanciar os objetos no mmomento da executao do contrutor
                //objeto responsabel por enviar o email
                smtpClient = new SmtpClient();

                //objeto que contem o email de origem
                from = new MailAddress(mailFrom, nameFrom, System.Text.Encoding.UTF8);

                //objeto para conter email destino
                to = new MailAddress(emailTo);

                // a mensagem completo com From, To e message
                mailMessage = new MailMessage(from, to);

                // mensagem
                mailMessage.Body = message;

                // assunto
                mailMessage.Subject = subject;
        }

        public void Send()
        {
            smtpClient.Host = ("smtps.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = (587);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            // envia o email
            var credenciais = new System.Net.NetworkCredential("fernando.s.mazzoni@gmail.com", "fernitrous@19");
            smtpClient.Credentials = credenciais;
            smtpClient.Send(mailMessage);

        }

    }
}