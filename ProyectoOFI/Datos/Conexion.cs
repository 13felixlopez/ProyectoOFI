using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoOFI.Datos
{
    public class Conexion
    {

        public static string conexion = Convert.ToString(Logica.Desencryptacion.checkServer());
        public static SqlConnection conectar = new SqlConnection(conexion);
        public static SqlConnection abrir()
        {
            return new SqlConnection(conexion);
        }
        public static void cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
