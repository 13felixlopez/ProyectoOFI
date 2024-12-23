using System;
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
        public static void DiseñoDtv(ref DataGridView Listado)
        {
            Listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Listado.BackgroundColor = Color.FromArgb(192, 192, 192);
            Listado.EnableHeadersVisualStyles = false;
            Listado.BorderStyle = BorderStyle.None;
            Listado.CellBorderStyle = DataGridViewCellBorderStyle.None;
            Listado.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Listado.RowHeadersVisible = false;
            DataGridViewCellStyle cabecera = new DataGridViewCellStyle();
            cabecera.BackColor = Color.FromArgb(29, 29, 29);
            cabecera.ForeColor = Color.White;
            cabecera.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Listado.ColumnHeadersDefaultCellStyle = cabecera;
        }
        public static void DiseñoEnvio(ref DataGridView Listado)
        {
            foreach (DataGridViewRow row in Listado.Rows)
            {
                string estado;
                estado = row.Cells["Proce"].Value.ToString();
                if (estado == "Analizado" || estado=="Envio" || estado == "Almacén")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(229, 48, 37);
                }
            }
        }
    }
}
