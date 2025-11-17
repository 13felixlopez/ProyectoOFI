using System;
using System.Data.SqlClient;

namespace ProyectoOFI.Datos
{
    public class Conexion
    {

        private static readonly string cadenaConexion = Convert.ToString(Logica.Desencryptacion.checkServer());

        // Devuelve SIEMPRE una conexión abierta lista para usarse

        public static SqlConnection abrir()
        {
            var conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }
        //public static void cerrar()
        //{
        //    if (conectar.State == ConnectionState.Open)
        //    {
        //        conectar.Close();
        //    }
        //}
    }
}
