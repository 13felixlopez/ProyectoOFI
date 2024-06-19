using System;

namespace ProyectoOFI.Logica
{
    public class LComprasD
    {
        public int IdCompraD { get; set; }
        public string Cosecha { get; set; }
        public DateTime Fecha { get; set; }
        public string Remision { get; set; }
        public string Proveedor { get; set; }
        public double KgsRem { get; set; }
        public string Tally { get; set; }
        public string Ticket { get; set; }
        public int IdEmpaque { get; set; }
        public int Sacos { get; set; }
        public double Kilos { get; set; }
        public double Diferencia { get; set; }
        public int IdBodega { get; set; }
        public int IdUbicacion { get; set; }
        public int IdCompra { get; set; }
        public int IdCertificacion { get; set; }
        public string Estado { get; set; }
    }
}
