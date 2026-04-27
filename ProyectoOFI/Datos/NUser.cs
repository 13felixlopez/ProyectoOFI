using ProyectoOFI.Logica;
using System.Data;

namespace ProyectoOFI.Datos
{
    public class NUser
    {
        readonly DUsuarios objd = new DUsuarios();

        public DataTable Nusers(LUsuarios parametros)
        {
            return objd.D_Usuarios(parametros);
        }
    }
}
