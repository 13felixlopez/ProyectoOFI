using System;

namespace ProyectoOFI.Logica
{
    public class LRecepcion
    {
        public string Ticket { get; set; }
        public DateTime? FRecibido { get; set; }
        public string Area { get; set; }
        public int IdArea { get; set; }
        public string Patio { get; set; }
        public string UbicacionRec { get; set; }
        public string MTNR { get; set; }
        public string EstadoFisico { get; set; }
        public int IdEstFis { get; set; }
        public string Calidad { get; set; }
        public int IdCalidad { get; set; }
        public string Daño { get; set; }
        public int IdDaño { get; set; }
        public int Sacos { get; set; }
        public double Peso { get; set; }
        public double Merma { get; set; }
        public string Recibidor { get; set; }
        public int IdRecibidor { get; set; }
        public string Digitador { get; set; }
        public string Estado { get; set; }
        public int ContadorEdit { get; set; }
        public string Proceso { get; set; }
        public string Consolidado { get; set; }
        public string Cosecha { get; set; }
    }
}
