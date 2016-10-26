using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using SalesForceWeb.Helper;

namespace SalesForceWeb.Workflow
{
    public class EmailUsuario
    {
        bool envio = false;
        public StringBuilder mainhead = new StringBuilder();
        public string htmlbody = string.Empty;

        public bool Email(string _email,string token_acesso) {


            try
            {
                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
                MailAddress remetente = new MailAddress("elirweb@gmail.com", "Sales Force Web");
                MailAddress destinatario = new MailAddress(_email, "Sales Force Web"); // colocar o email do cliente
                MailMessage message = new MailMessage(remetente, destinatario);

                message.Priority = MailPriority.Normal;
                message.IsBodyHtml = true;
                message.To.Add(new MailAddress(_email, "Sales Force Web"));
                message.From = new MailAddress("elir45@bol.com.br", "Sales Force Web");
                message.Subject = "Sales Force Web";
                mainhead.Append("<html>");
                mainhead.Append(" <meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />  ");
                mainhead.Append(" <meta name='description' content=' Sales Force Web' /> ");
                mainhead.Append(" <title>Sales Force Web</title> ");
                mainhead.Append(" <head></head> ");
                mainhead.Append(" <body > ");
                mainhead.Append(" <b>Assunto:</b> <br />");
                mainhead.Append("Seja bem vindo ao Sales Force Web<br />");
                mainhead.Append("Click <a href=\"http://localhost:61206/Admin/Login/RedefinirSenha?t="+token_acesso+"&email="+_email+ "\">aqui</a> para redefinir senha de acesso<br />");
                mainhead.Append(" </body> ");
                mainhead.Append(" </html> ");

                htmlbody = mainhead.ToString();
                AlternateView av1 = AlternateView.CreateAlternateViewFromString(htmlbody, null, MediaTypeNames.Text.Html);

                message.AlternateViews.Add(av1);


                try
                {
                    cliente.Credentials = new NetworkCredential("elirweb@gmail.com", "738529eli");
                    cliente.EnableSsl = true;
                    envio = true;
                    cliente.Send(message);
                }
                catch (ArgumentException h)
                {

                    throw new Exception(MensagemSistema.MSG_ERRO_ENVIO_EMAIL + h.Message);
                }
                catch (Exception y)
                {
                    throw new Exception(MensagemSistema.MSG_ERRO_PROXI_EMAIL + y.Message);
                }

                envio = true;
            }
            catch (Exception)
            {

                throw;
            }

            return envio;
        }


    }
}

