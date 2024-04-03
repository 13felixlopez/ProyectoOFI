using ProyectoOFI.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmAcopios : Form
    {
        public FrmAcopios()
        {
            InitializeComponent();
            MostrarAcopios();
            DtAcopio.Columns[1].Visible = false;
            DtAcopio.Columns[2].Visible = false;
        }

        private void FrmAcopios_Load(object sender, EventArgs e)
        {
            DRecepcion funcion = new DRecepcion();
            funcion.MostrarAgencia(CbAgencia);
        }
        private void InsertarAcopio()
        {
            DCatalogo funcion = new DCatalogo();
            int idagencia = int.Parse(CbAgencia.SelectedValue.ToString());
            if (funcion.InsertarAcopio(TxtAcopio.Text, (int)CbAgencia.SelectedValue) == true)
            {
                TxtAcopio.Clear();
                MostrarAcopios();
            }
        }
        private void MostrarAcopios()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarAcopios(ref dt);
            DtAcopio.DataSource = dt;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarAcopio();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
