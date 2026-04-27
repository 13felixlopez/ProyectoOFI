using System.Configuration;

namespace ProyectoOFI.Usuario
{
    public class DCorreoSoporte : Recuperacion
    {
        public DCorreoSoporte()
        {
            remitenteCorreo = ConfigurationManager.AppSettings["CorreoSoporte.Remitente"];
            password = ConfigurationManager.AppSettings["CorreoSoporte.Password"];
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initialzeSmtpClient();
        }
    }
}
