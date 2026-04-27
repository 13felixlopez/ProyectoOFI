using System;
using System.Configuration;
using System.IO;

namespace ProyectoOFI
{
    public static class Log
    {
        public static void Writeerror(string ms)
        {
            string logerror = ConfigurationManager.AppSettings["logerror"];
            using (StreamWriter writer = new StreamWriter(logerror, true))
            {
                writer.WriteLine($"{DateTime.Now}:{ms}");
                writer.WriteLine("---------------------------------------------------------");
            }
        }
    }
}
