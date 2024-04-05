using System.Drawing;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public class Base
    {
        public static void DiseñoDtvEliminar(ref DataGridView Listado)
        {
            foreach (DataGridViewRow row in Listado.Rows)
            {
                string estado;
                estado = row.Cells["Consolidado"].Value.ToString();
                if (estado == "Si")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(41, 128, 185);
                }
            }

        }
    }
}
