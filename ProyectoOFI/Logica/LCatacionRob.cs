using System;

namespace ProyectoOFI.Logica
{
    public class LCatacionRob
    {
        // Parámetros VARCHAR (string)
        public string Ticket { get; set; }
        public string Origen { get; set; }
        public string RmtoObto { get; set; }
        public string Cascarilla { get; set; }
        public string TotalPS { get; set; }
        public string Humedad { get; set; }
        public string NessP { get; set; }
        public string DesmDRobP { get; set; }
        public string Taza { get; set; }
        public string GradoCalidad { get; set; }
        public string Digitador { get; set; }
        public string Analisis { get; set; }
        public string Rob72P { get; set; }

        // Parámetros DATE (DateTime)
        public DateTime FechaMuestra { get; set; } // El SP lo puede buscar si es NULL
        public DateTime FechaCatacion { get; set; }

        // Parámetros INT (int)
        public int Dias { get; set; }
        public int IdVariedad { get; set; }
        public int Score { get; set; }

        // Parámetros BIT (bool)
        public string Estado { get; set; }

        // Parámetros DECIMAL (decimal)
        public decimal SCR12 { get; set; }
        public decimal SCR15 { get; set; }
        public decimal SCR14 { get; set; }
        public decimal DesmDRob { get; set; }
        public decimal PesoRecibido { get; set; }
        public decimal Fondo { get; set; }
        public decimal Ness { get; set; }
        public decimal Rob72 { get; set; }
    }
}
