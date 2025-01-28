using ScreenSound.API.Mail.ApiMailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.API.Mail.ApiMailFunction
{
    public class EmailSender
    {
        private readonly EmailService _emailService;

        public EmailSender()
        {
            // Configuração do servidor SMTP
            var emailConfig = new EmailConfig
            {
                SmtpServer = "smtp.gmail.com",
                SmtpPort = 587,
                SmtpUser = "screensound0@gmail.com",
                SmtpPassword = "qnoysdyfajzgbqud",
                UseSsl = true
            };

            // Inicializando o serviço de e-mail
            _emailService = new EmailService(emailConfig);
        }

        public void EnviarEmail(string toName, string toEmail)
        {
            // Dados do e-mail
            string fromName = "ScreenSound";
            string fromEmail = "screensound0@gmail.com";
            string subject = "Bem vindo(a)! " + toName;
            string body = "<h1>Olá!" + toName + "</h1><p>Sua conta no ScreenSound foi criada com sucesso.</p>";

            // Enviando o e-mail
            _emailService.SendEmail(fromName, fromEmail, toName, toEmail, subject, body, isHtml: true);
        }

        public void EnviarEmailRecuperacao()
        {             // Dados do e-mail
            string fromName = "ScreenSound";
            string fromEmail = "screensound0@gmail.com";
            string toName = Console.ReadLine();
            string toEmail = Console.ReadLine();
            string subject = "Recuperação de senha";
            string body = "<h1>Olá!" + toName + 
            "</h1><p>Para recuperar sua senha, clique no link a seguir: <a href='https://screensound.com/recuperar-senha'>Recuperar senha</a></p>";
        
            _emailService.SendEmail(fromName, fromEmail, toName, toEmail, subject, body, isHtml: true);
        }
    }
}
