using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Recepcion.FormExtras
{
    public partial class AddEditTicket : Form
    {
        string Ticket, titulo, Consolidado, areaAc, Proceso;
        int ContadorEdit;
        List<string> permisosUsuario = new List<string>();

        private void btnSig_Click(object sender, EventArgs e)
        {
            PRecepcion.Dock = DockStyle.Fill;
            PRecepcion.Visible = true;
            PEnvio.Visible = false;
            if (Login.NombreA == "León Sequeira" || Login.NombreA == "Pedro Gonzalez" || Login.NombreA == "Lilliam Ocotal")
            {
                cbArea.Enabled = false;
                CbPatio.Enabled = false;
                if (Login.NombreA == "Lilliam Ocotal")
                {
                    CbPatio.Text = "Patio Peralta Coffee";
                    //CbPatio.Enabled = false;
                }
                else if (Login.NombreA == "León Sequeira" || Login.NombreA == "Pedro Gonzalez")
                {
                    CbPatio.Text = "Patio Acoyapa";
                    //CbPatio.Enabled = false;
                }
            }
            else
            {
                cbArea.Enabled = true;
                CbPatio.Enabled = true;
            }
        }

        private void btnAnt_Click(object sender, EventArgs e)
        {
            PRecepcion.Visible = false;
            PEnvio.Dock = DockStyle.Fill;
            PEnvio.Visible = true;
        }

        public AddEditTicket()
        {
            InitializeComponent();
            BtnVerCons.Visible = false;
            PnGuardar.Visible = true;
            BtnEditar.Visible = false;
            LblDigitador.Text = Login.NombreA;
        }
        public AddEditTicket(string Tk,string label,string consolidado,string Area,int contador,string proce)
        {
            InitializeComponent();
            Ticket = Tk;
            titulo = label;
            Consolidado = consolidado;
            areaAc = Area;
            ContadorEdit = contador;
            Proceso = proce;
            ObtenerDatos();
        }

        private void AddEditTicket_Load(object sender, EventArgs e)
        {
            ValidarPermisos();
            lblTransferencia.Text = titulo;
            PlRecepcion.Dock = DockStyle.Fill;
            PlRecepcion.Visible = true;
            PlRecepcion.BringToFront();
            PEnvio.Dock = DockStyle.Fill;
            DRecepcion funcion = new DRecepcion();
            funcion.Cosecha(LblCosecha);
            Comprobaciones();
            //ChUA.Checked = true;
        }
        private void ObtenerDatos()
        {
            DRecepcion funcion = new DRecepcion();
            DataTable dt = new DataTable();

            try
            {
                funcion.MostrarDetalle(ref dt, Ticket);

                if (dt.Rows.Count > 0)
                {
                    double kilos, kilose;
                    DataRow row = dt.Rows[0];
                    Consolidado = row["Consolidado"].ToString();
                    if (DateTime.Parse(row["FEnvio"].ToString()) != null)
                    {
                        dtFEnvio.Value = DateTime.Parse(row["FEnvio"].ToString());
                    }
                    else
                    {
                        dtFEnvio.Value = DateTime.Today.Date;
                    }
                    if (row["Agencia"].ToString() != null)
                    {
                        cbAgencia.Text = row["Agencia"].ToString();
                    }
                    else
                    {
                        cbAgencia.ForeColor = Color.White;
                    }
                    if (row["Acopio"].ToString() != null)
                    {
                        cbAcopio.Text = row["Acopio"].ToString();
                    }
                    else
                    {
                        cbAcopio.Text = "";
                    }
                    if (row["Cliente"].ToString() != null)
                    {
                        cbCliente.Text = row["Cliente"].ToString();
                    }
                    else
                    {
                        cbCliente.Text = "";
                    }
                    if (row["Compra"].ToString() != null)
                    {
                        cbCompra.Text = row["Compra"].ToString();
                    }
                    else
                    {
                        cbCompra.Text = "";
                    }
                    if (!string.IsNullOrEmpty(row["MTNT"].ToString()))
                    {
                        txtMTNT.Text = row["MTNT"].ToString();
                    }
                    else
                    {
                        txtMTNT.Text = "";
                    }
                    if (row["Certificacion"].ToString() != null)
                    {
                        cbCertificacion.Text = row["Certificacion"].ToString();
                    }
                    else
                    {
                        cbCertificacion.Text = "";
                    }
                    if (row["EstadoFísicoE"].ToString() != null)
                    {
                        cbEsFisico.Text = row["EstadoFísicoE"].ToString();
                    }
                    else
                    {
                        cbEsFisico.Text = "";
                    }
                    if (row["CalidadE"].ToString() != null)
                    {
                        cbCalidadE.Text = row["CalidadE"].ToString();
                    }
                    else
                    {
                        cbCalidadE.Text = "";
                    }
                    if (row["DañoE"].ToString() != null)
                    {
                        cbDanioE.Text = row["DañoE"].ToString();
                    }
                    else
                    {
                        cbDanioE.Text = "";
                    }
                    if (row["SacosE"].ToString() != null)
                    {
                        nudSacosE.Value = int.Parse(row["SacosE"].ToString());
                    }
                    else
                    {
                        nudSacos.Value = 0;
                    }
                    if (row["PesoE"].ToString() != null)
                    {
                        txtPesoE.Text = row["PesoE"].ToString();
                        kilose = double.Parse(txtPesoE.Text);
                        kilose = kilose / 46;
                        LblQQsEn.Text = Math.Round(kilose, 2).ToString();
                    }
                    else
                    {
                        txtPesoE.Text = "0";
                        LblQQsEn.Text = "0";
                    }
                    txtTK.Text = Ticket.ToString();
                    dtpRecibido.Value = DateTime.Parse(row["Fecha Recibido"].ToString());
                    cbArea.Text = row["AreaSecado"].ToString();
                    //CbPatio.Text = row["Patio"].ToString();
                    if (row["Patio"].ToString() != null)
                    {
                        CbPatio.Text = row["Patio"].ToString();
                    }
                    else
                    {
                        CbPatio.Text = "--";
                    }
                    areaAc = row["AreaSecado"].ToString();
                    if (row["MTNR"].ToString() != null)
                    {
                        txtMTNR.Text = row["MTNR"].ToString();
                    }
                    else
                    {
                        txtMTNR.Text = "";
                    }
                    cbEstadoFisico.Text = row["Estado Físico"].ToString();
                    cbCalidad.Text = row["Calidad"].ToString();
                    cbDaño.Text = row["Daño"].ToString();
                    nudSacos.Value = int.Parse(row["Sacos"].ToString());
                    txtKgs.Text = row["Peso"].ToString();
                    kilos = double.Parse(txtKgs.Text);
                    kilos = kilos / 46;
                    LblQQs.Text = Math.Round(kilos, 2).ToString();
                    if (row["Merma"].ToString() != null)
                    {
                        LblMerma.Text = row["Merma"].ToString();
                    }
                    else
                    {
                        LblMerma.Text = "";
                    }
                    if (row["Recibidor"].ToString() != null)
                    {
                        cbRecibidor.Text = row["Recibidor"].ToString();
                    }
                    else
                    {
                        cbRecibidor.Text = "";
                    }
                    LblDigitador.Text = row["Digitador"].ToString();
                    if (row["TallySheet"].ToString() != null)
                    {
                        TxtTally.Text = row["TallySheet"].ToString();
                    }
                    else
                    {
                        TxtTally.Text = "";
                    }
                    if (row["ContadorEdit"].ToString() != null)
                    {
                        ContadorEdit = int.Parse(row["ContadorEdit"].ToString());
                    }
                    else
                    {
                        ContadorEdit = 0;
                    }
                    Proceso = row["Proceso"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el ticket especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddEditTicket_FormClosed(object sender, FormClosedEventArgs e)
        {
            Limpiar();

        }

        private void Comprobaciones()
        {
            if (Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase) || permisosUsuario.Contains("EditarTK"))
            {
                txtTK.Enabled = true;
                //agregue la linea de BtnEditar
                BtnEditar.Visible = true;
            }
            else
            {
                if (txtTK.Text.Trim().StartsWith("Cons#", StringComparison.OrdinalIgnoreCase))
                {
                    // Si el texto inicia con "Cons#", habilitar el TextBox
                    txtTK.Enabled = true;
                }
                else
                {
                    // Si no inicia con "Cons#", deshabilitar el TextBox
                    txtTK.Enabled = false;
                }
            }
            if (Consolidado == "Si")
            {
                BtnVerCons.Visible = true;
                nudSacos.Enabled = false;
                nudSacosE.Enabled = false;
                txtPesoE.Enabled = false;
                txtKgs.Enabled = false;
            }
            else
            {
                BtnVerCons.Visible = false;
            }
            //Aca modifique, agregue esto Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase
            if (Proceso == "No Asignado" && permisosUsuario.Contains("EditarTransferencia") || Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
            {
                BtnEditar.Visible = true;
                PnGuardar.Visible = false;
            }
            else
            {
                BtnEditar.Visible = false;
            }
        }
        private void ValidarPermisos()
        {
            DataTable dt = new DataTable();
            DModulos funcion = new DModulos();
            LPermisos parametros = new LPermisos();
            parametros.IdUser = Login.Iduser;
            funcion.PermisosUser(ref dt, Login.Iduser);

            // Guardamos todos los permisos en la lista
            foreach (DataRow rowpermisos in dt.Rows)
            {
                permisosUsuario.Add(Convert.ToString(rowpermisos["Modulo"]));
            }

            // Ahora que tenemos todos los permisos, los validamos
            AsignarPermisos();
        }
        private void AsignarPermisos()
        {
            if (permisosUsuario.Contains("EditarTransferencia"))
            {
                BtnEditar.Visible = true;
                PlRecepcion.Enabled = true;
                PlEnvio.Enabled = true;
            }

            if (permisosUsuario.Contains("EditarTK"))
            {
                txtTK.Enabled = true;
            }
            if (Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
            {
                BtnEditar.Visible = true;
                PlRecepcion.Enabled = true;
                PlEnvio.Enabled = true;
                txtTK.Enabled = true;
                nudSacosE.Enabled = true;
                nudSacos.Enabled = true;
                txtPesoE.Enabled = true;
                txtKgs.Enabled = true;
            }
        }
        private void Limpiar()
        {
            //Enviado
            cbAgencia.Text = "";
            cbAcopio.Text = "";
            cbCliente.Text = "";
            cbCompra.Text = "";
            txtMTNT.Clear();
            cbCertificacion.Text = "";
            cbEsFisico.Text = "";
            cbCalidadE.Text = "";
            cbDanioE.Text = "";
            nudSacosE.Value = 0;
            txtPesoE.Clear();
            dtFEnvio.Value = DateTime.Today;
            LblQQsEn.Text = "--";
            //Recibido
            txtTK.Clear();
            cbArea.Text = "";
            txtMTNR.Clear();
            cbEstadoFisico.Text = "";
            cbCalidad.Text = "";
            cbDaño.Text = "";
            nudSacos.Value = nudSacosE.Value;
            txtKgs.Text = txtPesoE.Text;
            cbRecibidor.Text = "";
            LblDigitador.Text = "";
            dtpRecibido.Value = DateTime.Today;
            LblQQs.Text = "--";
            lblTransferencia.Text = "Agregar Transferencia";
            TxtTally.Clear();
            CHBConsSM.Checked = false;
        }
    }
}
