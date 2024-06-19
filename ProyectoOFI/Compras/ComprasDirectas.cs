using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Compras
{
    public partial class ComprasDirectas : UserControl
    {
        public ComprasDirectas()
        {
            InitializeComponent();
        }

        private async void ComprasDirectas_Load(object sender, System.EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            PlCarga.Visible = false;
        }

        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventarioCompras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarComprasD();
            //ReiniciarPaginado();
            await Task.Delay(1000);
            btnAgregar.Visible = true;
        }

        private void MostrarComprasD()
        {
            DCompraD funcion = new DCompraD();
            DataTable dt = new DataTable();
            funcion.MostrarComprasD(ref dt);
            dtInventarioCompras.DataSource = dt;
        }
        private void InsertarCompraDirecta()
        {
            if (Validar())
            {
                DCompraD funcion = new DCompraD();
                LComprasD parametros = new LComprasD();
                parametros.Cosecha = TxtConsecha.Text;
                parametros.Fecha = DateTime.Parse(DTPFecha.Text);
                parametros.Remision = TxtRem.Text;
                parametros.Proveedor = CbProveedor.Text;
                parametros.KgsRem = double.Parse(TxtKgsRem.Text);
                parametros.Tally = TxtTally.Text;
                parametros.IdEmpaque = (int)CbTipoEmpaque.SelectedValue;
                parametros.Sacos = int.Parse(NudSacos.Text);
                parametros.Kilos = int.Parse(TxtPeso.Text);
                parametros.Diferencia = double.Parse(LblDiferencia.Text);
                parametros.IdBodega = (int)CbBodega.SelectedValue;
                parametros.IdUbicacion = (int)CbUbicacion.SelectedValue;
                parametros.IdCompra = (int)cbCompra.SelectedValue;
                parametros.IdCertificacion = (int)cbCertificacion.SelectedValue;
                parametros.Estado = "S/A";
                if (funcion.InsertarCompraDirecta(parametros) == true)
                {
                    MostrarComprasD();
                    Limpiar();
                    PLDatos.Visible = false;
                    dtInventarioCompras.Enabled = true;
                }
            }
        }

        private void Limpiar()
        {
            TxtConsecha.Clear();
            TxtRem.Clear();
            TxtKgsRem.Clear();
            TxtTally.Clear();
            NudSacos.Value = 0;
            TxtPeso.Clear();
            LblDiferencia.Text = "--";
        }
        private void Activar()
        {
            TxtConsecha.Enabled=true;
            TxtRem.Enabled=true;
            TxtKgsRem.Enabled=true;
            TxtTally.Enabled=true;
            NudSacos.Enabled = true;
            TxtPeso.Enabled=true;
            DTPFecha.Enabled = true;
            CbProveedor.Enabled = true;
            CbTipoEmpaque.Enabled = true;
            CbBodega.Enabled = true;
            CbUbicacion.Enabled = true;
            cbCompra.Enabled = true;
            cbCertificacion.Enabled = true;
        }
        private void Desactivar()
        {
            TxtConsecha.Enabled = false;
            TxtRem.Enabled = false;
            TxtKgsRem.Enabled = false;
            TxtTally.Enabled = false;
            NudSacos.Enabled = false;
            TxtPeso.Enabled = false;
            DTPFecha.Enabled = false;
            CbProveedor.Enabled = false;
            CbTipoEmpaque.Enabled = false;
            CbBodega.Enabled = false;
            CbUbicacion.Enabled = false;
            cbCompra.Enabled = false;
            cbCertificacion.Enabled = false;
        }
        private bool Validar()
        {
            double entero;
            if (!double.TryParse(TxtPeso.Text, out entero) || !double.TryParse(TxtKgsRem.Text, out entero) || !double.TryParse(TxtPeso.Text, out entero))
            {
                return false;
            }
            return !(TxtPeso.Text == "" || TxtConsecha.Text == "" || TxtKgsRem.Text == "" || TxtRem.Text == "" || TxtTally.Text == "");
        }
    }
}
