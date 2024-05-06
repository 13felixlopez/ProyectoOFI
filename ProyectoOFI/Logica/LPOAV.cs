using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOFI.Logica
{
    public class LPOAV
    {
        public int ID { get; set; }
        public string Ticket { get; set; }
        public int POAV { get; set; }
        public string OperadorPV { get; set; }
        public int TurnoPV { get; set; }
        public DateTime FRecibidoPV { get; set; }
        public double HumedadPV { get; set; }
        public string DigitadorPOA { get; set; } 
    }
}
