using Portafolio.Interfaces;
using Portafolio.Models;
using System.Net;
using System.Net.Mail;

namespace Portafolio.Servicios
{
    public class ServicioEmailGmail : IServicioEmail
    {
        private readonly IConfiguration _configuration;

        public ServicioEmailGmail(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task Enviar(ContactoDTO contacto)
        {
            string emailEmisor = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            string emailPassword = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            string host = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            int puerto = _configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PORT");

            var smtpClient = new SmtpClient(host, puerto)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailEmisor, emailPassword)
            };

            var mensaje = new MailMessage(emailEmisor, emailEmisor)
            {
                Subject = $"El cliente {contacto.Nombre} ha enviado un nuevo mensaje de contacto",
                Body = $"Nombre: {contacto.Nombre}\nEmail: {contacto.Email}\nMensaje: {contacto.Mensaje}",
                IsBodyHtml = false
            };

            await smtpClient.SendMailAsync(mensaje);
        }
    }
}
