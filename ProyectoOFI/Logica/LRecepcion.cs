using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOFI.Logica
{
    public class LRecepcion
    {
        public string Ticket { get; set; }
        public DateTime FRecibido { get; set; }
        public string Area { get; set; }
        public string MTNR { get; set; }
        public string EstadoFisico { get; set; }
        public string Calidad { get; set; }
        public string Daño { get; set; }
        public int Sacos { get; set; }
        public double Peso { get; set; }
        public double Merma { get; set; }
        public string Recibidor { get; set; }
        public string Digitador { get; set; }
        public string Estado { get; set; }
        public int ContadorEdit { get; set; }
    }
}
