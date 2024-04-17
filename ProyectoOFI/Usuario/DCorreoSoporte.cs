namespace ProyectoOFI.Usuario
{
    public class DCorreoSoporte : Recuperacion
    {
        public DCorreoSoporte()
        {
            remitenteCorreo = "makeitrealofi@gmail.com";
            password = "oavfeclcrqebidcw";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initialzeSmtpClient();
        }
    }
}
