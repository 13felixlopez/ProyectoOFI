using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoOFI.Logica
{
    public class LTendido
    {
        public int IdTendido { get; set; }
        public string Ticket { get; set; }
        public DateTime FechaT { get; set; }
        public int Folio { get; set; }
        public int IdPatio { get; set; }
        public int IdUbicacionP { get; set; }
        public string Digitador { get; set; }
    }
}
