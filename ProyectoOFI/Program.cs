using System;
using System.Windows.Forms;

namespace ProyectoOFI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //SMecánico frm = new SMecánico();
            Login frm = new Login();
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
            Application.Run();
        }
        private static void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
