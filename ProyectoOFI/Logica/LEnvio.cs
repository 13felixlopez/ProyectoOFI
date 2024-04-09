using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOFI.Logica
{
    public class LEnvio
    {
        public int IDEnvio { get; set; }
        public string Ticket { get; set; }
        public DateTime FEnvio { get; set; }
        public string Agencia { get; set; }
        public string Acopio { get; set; }
        public string Cliente { get; set; }
        public string MTNT { get; set; }
        public string TCompra { get; set; }
        public string CertificacionE { get; set; }
        public string EsFisico { get; set; }
        public string CalidadE { get; set; }
        public string DanioE { get; set; }
        public int SacosE { get; set; }
        public double PesoE { get; set; }
        public string Tally { get; set; }

    }
}
