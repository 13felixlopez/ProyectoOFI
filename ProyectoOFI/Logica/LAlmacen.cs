using System;

namespace ProyectoOFI.Logica
{
    public class LAlmacen
    {
        public int IdAlmacen { get; set; }
        public string Ticket { get; set; }
        public string Origen { get; set; }
        public DateTime FechaAlmacen { get; set; }
        public int IdBodega { get; set; }
        public int IdUbicacion { get; set; }
        public int IdEmpaque { get; set; }
        public int Sacos { get; set; }
        public decimal Peso { get; set; }
        public decimal Tara { get; set; }
        public decimal PesoNeto { get; set; }
        public double Rendimiento { get; set; }
        public int IdTurno { get; set; }
        public int IdDescargador { get; set; }
    }
}
