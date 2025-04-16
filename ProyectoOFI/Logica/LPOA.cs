using System;

namespace ProyectoOFI.Logica
{
    public class LPOA
    {
        public int IdPOA { get; set; }
        public int Guardiola { get; set; }
        public int IdOperador { get; set; }
        public int IdTurno { get; set; }
        public DateTime FechaG { get; set; }
        public DateTime HoraIniG { get; set; }
        public DateTime HoraFinG { get; set; }
        public double Humedad { get; set; }
        public DateTime Duracion { get; set; }
        public string Ticket { get; set; }
        public string DigitadorG { get; set; }
    }
}
