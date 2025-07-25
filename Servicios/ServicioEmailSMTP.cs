
using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace MEXIGEO.Servicios
{

    public interface IServicioEmailSMTP
    {
        Task EnviarCorreo(string destinatario, string asunto, string cuerpo);
    }

    // public class ServicioEmailSmtp : IServicioEmailSMTP
    // {
    //     private readonly IConfiguration _configuration;

    //     public ServicioEmailSmtp(IConfiguration configuration)
    //     {
    //         _configuration = configuration;
    //     }

    //     public async Task EnviarCorreo(string destinatario, string asunto, string cuerpo)
    //     {
    //         var client = new SmtpClient("smtp.office365.com", 587)
    //         {
    //             Credentials = new NetworkCredential(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]),
    //             EnableSsl = true
    //         };

    //         var mailMessage = new MailMessage
    //         {
    //             From = new MailAddress(_configuration["EmailSettings:Username"]),
    //             Subject = asunto,
    //             Body = cuerpo,
    //             IsBodyHtml = true,
    //         };
    //         mailMessage.To.Add(destinatario);

    //         await client.SendMailAsync(mailMessage);
    //     }
    // }
    public class ServicioEmailSmtp : IServicioEmailSMTP
    {
        private readonly IConfiguration _configuration;

        public ServicioEmailSmtp(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnviarCorreo(string destinatario, string asunto, string cuerpo)
        {
            try
            {
                string tipoCuenta = _configuration["EmailSettings:TipoCuenta"];
                string username = _configuration["EmailSettings:Username"];
                string password = _configuration["EmailSettings:Password"];

                string host;
                int port;
                bool enableSsl;

                if (tipoCuenta == "Office365")            // Tenants empresariales
                {
                    host = _configuration["EmailSettings:SmtpOffice365:Host"];
                    port = int.Parse(_configuration["EmailSettings:SmtpOffice365:Port"]);
                    enableSsl = bool.Parse(_configuration["EmailSettings:SmtpOffice365:EnableSsl"]);
                }
                else if (tipoCuenta == "Exchange")        // Servidor on-prem interno
                {
                    host = _configuration["EmailSettings:SmtpExchange:Host"];
                    port = int.Parse(_configuration["EmailSettings:SmtpExchange:Port"]);
                    enableSsl = bool.Parse(_configuration["EmailSettings:SmtpExchange:EnableSsl"]);
                }
                else if (tipoCuenta == "OutlookBasic")    // NUEVO: cuentas @outlook.com / @hotmail
                {
                    host = _configuration["EmailSettings:SmtpOutlook:Host"];
                    port = int.Parse(_configuration["EmailSettings:SmtpOutlook:Port"]);
                    enableSsl = bool.Parse(_configuration["EmailSettings:SmtpOutlook:EnableSsl"]);
                }
                else
                {
                    throw new Exception($"Tipo de cuenta no soportado: {tipoCuenta}");
                }

                using var client = new SmtpClient(host, port)
                {
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = enableSsl
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(username),
                    Subject = asunto,
                    Body = cuerpo,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(destinatario);

                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR AL ENVIAR CORREO: {ex.Message}");
                throw;
            }
        }


    }

}
