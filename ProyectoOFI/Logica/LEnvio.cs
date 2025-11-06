using System;

namespace ProyectoOFI.Logica
{
    public class LEnvio
    {
        public int IDEnvio { get; set; }
        public string Ticket { get; set; }
        public DateTime FEnvio { get; set; }
        public int IdAgencia { get; set; }
        public string Agencia { get; set; }
        public int IdAcopio { get; set; }
        public int IdCliente { get; set; }
        public string MTNT { get; set; }
        public string TCompra { get; set; }
        public int IdTCompra { get; set; }
        public int IdCertificacionE { get; set; }
        public string CertificacionE { get; set; }
        public string EsFisico { get; set; }
        public int IdEsFisico { get; set; }
        public string CalidadE { get; set; }
        public int IdCalidadE { get; set; }
        public string DanioE { get; set; }
        public int IdDanioE { get; set; }
        public int SacosE { get; set; }
        public double PesoE { get; set; }
        public string Tally { get; set; }
        public string Placa { get; set; }

    }
}
