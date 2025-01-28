using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace ScreenSound.API.Mail.ApiMailModel
{
    /// <summary>
    /// Classe de configuração para o envio de e-mails
    /// </summary>
    public class EmailConfig
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public bool UseSsl { get; set; } = true;

        // Validações simples (opcional)
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(SmtpServer)) throw new ArgumentException("O servidor SMTP não foi configurado.");
            if (string.IsNullOrWhiteSpace(SmtpUser)) throw new ArgumentException("O usuário SMTP não foi configurado.");
            if (string.IsNullOrWhiteSpace(SmtpPassword)) throw new ArgumentException("A senha SMTP não foi configurada.");
        }
    }

    /// <summary>
    /// Serviço principal para envio de e-mails
    /// </summary>
    public class EmailService
    {
        private readonly EmailConfig _config;

        public EmailService(EmailConfig config)
        {
            _config = config;
            _config.Validate();
        }

        /// <summary>
        /// Envia um e-mail utilizando as configurações fornecidas
        /// </summary>
        public void SendEmail(string fromName, string fromEmail, string toName, string toEmail, string subject, string body, bool isHtml = false)
        {
            try
            {
                // Criando a mensagem
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromName, fromEmail));
                message.To.Add(new MailboxAddress(toName, toEmail));
                message.Subject = subject;
                message.Body = new TextPart(isHtml ? TextFormat.Html : TextFormat.Plain)
                {
                    Text = body
                };

                // Enviando a mensagem
                using (var client = new SmtpClient())
                {
                    client.Connect(_config.SmtpServer, _config.SmtpPort, _config.UseSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto);
                    client.Authenticate(_config.SmtpUser, _config.SmtpPassword);

                    client.Send(message);
                    Console.WriteLine("E-mail enviado com sucesso!");

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                throw; // Relança a exceção para tratamento externo, se necessário
            }
        }
    }
}

