using MEXIGEO.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MEXIGEO.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailSendGrid : IServicioEmail
    {
        private readonly IConfiguration configuration;
        public ServicioEmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var apikey = configuration.GetValue<String>("SEND_GRID_API_KEY");
            var email = configuration.GetValue<String>("SEND_GRID_FROM");
            var nombre = configuration.GetValue<String>("SEND_GRID_NOMBRE");



            var cliente = new SendGridClient(apikey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contacto.Email} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensajeTextoPlano = contacto.Mensaje;
            var contenidoHtml = $@"DE: {contacto.Nombre} - 
                                Email: {contacto.Email}
                                Mensaje: {contacto.Mensaje}";

            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);

        }


    }
}
