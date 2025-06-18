using System;

namespace MEXIGEO.Models
{
    public class SmtpOptions
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }

    public class EmailSettings
    {
        public string TipoCuenta { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public SmtpOptions SmtpOffice365 { get; set; } = new();
        public SmtpOptions SmtpExchange { get; set; } = new();
        public SmtpOptions SmtpOutlook { get; set; } = new();
    }
}
