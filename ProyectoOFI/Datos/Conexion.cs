using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoOFI.Datos
{
    public class Conexion
    {
        //public static string Cn = "Data Source='FELIXL'; Initial Catalog=OFI; Integrated Security=True";
        //public static string conexion = @"Data source=NIMAT-9L99WV3\MSSQLSERVER02; Initial Catalog=OFI; Integrated Security=true";
        public static string conexion = Convert.ToString(Logica.Desencryptacion.checkServer());
        public static SqlConnection conectar = new SqlConnection(conexion);
        public static void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
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
