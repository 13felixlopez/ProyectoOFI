using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
