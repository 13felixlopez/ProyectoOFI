using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOFI.Logica
{
    public class LVertical
    {
        public int IDV { get; set; }
        public string Ticket { get; set; }
        public int Ver { get; set; }
        public int OperadorV { get; set; }
        public int TurnoV { get; set; }
        public DateTime FRecibidoV { get; set; }
        public DateTime HrInicoV { get; set; }
        public DateTime HrFin { get; set; }
        public DateTime Duracion { get; set; }
        public string DigitadorV { get; set; }
        public DateTime FechaDes { get; set; }
        public DateTime HoradesIn { get; set; }
        public DateTime HoraFin { get; set; }
        public double Humedad { get; set; }
        public double Paros { get; set; }
        public string Observacion { get; set; }
        public DateTime Total { get; set; }
        public string ProcesoSF { get; set; }
        public int POA1 { get; set; }
        public int POA2 { get; set; }
    }
}
