using ProyectoOFI.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOFI.Logica
{
    public class LPS
    {
        public int PS { get; set; }
        public int IdOperador { get; set; }
        public int IdTurno { get; set; }
        public DateTime FechaPS { get; set; }
        public DateTime HoraIniPS { get; set; }
        public DateTime HoraFinPS { get; set; }
        public double HumedadPS { get; set; }
        public double ParosPS { get; set; }
        public string Observacion { get; set; }
        public string DigitadorPS { get; set; }
        public string TiempoSF { get; set; }
        public string TiempoTotal { get; set; }
        public int IdGuardiola { get; set; }
    }
}
