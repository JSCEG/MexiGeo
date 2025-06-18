
using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using MEXIGEO.Models;

namespace MEXIGEO.Servicios
{

    public interface IServicioEmailSMTP
    {
        Task EnviarCorreo(string destinatario, string asunto, string cuerpo);
    }

    public class ServicioEmailSmtp : IServicioEmailSMTP
    {
        private readonly EmailSettings _settings;

        public ServicioEmailSmtp(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task EnviarCorreo(string destinatario, string asunto, string cuerpo)
        {
            try
            {
                string tipoCuenta = _settings.TipoCuenta;
                string username = _settings.Username;
                string password = _settings.Password;

                string host;
                int port;
                bool enableSsl;

                if (tipoCuenta == "Office365")            // Tenants empresariales
                {
                    host = _settings.SmtpOffice365.Host;
                    port = _settings.SmtpOffice365.Port;
                    enableSsl = _settings.SmtpOffice365.EnableSsl;
                }
                else if (tipoCuenta == "Exchange")        // Servidor on-prem interno
                {
                    host = _settings.SmtpExchange.Host;
                    port = _settings.SmtpExchange.Port;
                    enableSsl = _settings.SmtpExchange.EnableSsl;
                }
                else if (tipoCuenta == "OutlookBasic")    // NUEVO: cuentas @outlook.com / @hotmail
                {
                    host = _settings.SmtpOutlook.Host;
                    port = _settings.SmtpOutlook.Port;
                    enableSsl = _settings.SmtpOutlook.EnableSsl;
                }
                else
                {
                    throw new Exception($"Tipo de cuenta no soportado: {tipoCuenta}");
                }

                using var client = new SmtpClient(host, port)
                {
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = enableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
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
