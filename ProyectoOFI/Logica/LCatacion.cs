using System;

namespace ProyectoOFI.Logica
{
    public class LCatacion
    {
        public string Ticket { get; set; }
        public string Origen { get; set; }
        public DateTime FechaMuestra { get; set; }
        public DateTime FechaCatacion { get; set; }
        public int Dias { get; set; }
        public string RmtoObto { get; set; }
        public string Cascarilla { get; set; }
        public string TotalPS { get; set; }
        public int IdVariedad { get; set; }
        public string Humedad { get; set; }
        public double Exp { get; set; }
        public double DesmA { get; set; }
        public double DesmC { get; set; }
        public double DesmD { get; set; }
        public string DesmAP { get; set; }
        public string DesmCP { get; set; }
        public string DesmDP { get; set; }
        public string ExpP { get; set; }
        public int Score { get; set; }
        public string Tasa { get; set; }
        public string GradoCalidad { get; set; }
        public string Digitador { get; set; }
        public string Estado { get; set; }
        public string Analisis { get; set; }
        public double PesoRecibido { get; set; }
        public int Maquina { get; set; }
    }
}
