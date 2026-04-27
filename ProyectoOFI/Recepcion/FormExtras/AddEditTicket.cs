using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        public AddEditTicket(string Tk, string label, string consolidado, string Area, int contador, string proce)
        {
            InitializeComponent();
            Ticket = Tk;
            titulo = label;
            Consolidado = consolidado;
            areaAc = Area;
            ContadorEdit = contador;
            Proceso = proce;
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
            CargarCombos();
            ObtenerDatos();
            //ChUA.Checked = true;
        }
        private void CargarCombos()
        {
            DRecepcion funcion = new DRecepcion();
            funcion.MostrarAgencia(cbAgencia);
            funcion.MostrarRecibidor(cbRecibidor);
            funcion.MostrarCliente(cbCliente);
            funcion.MostrarCompra(cbCompra);
            funcion.MostrarCert(cbCertificacion);
            //funcion.MostrarCert(CbCertCons);
            funcion.MostrarEstFis(cbEsFisico);
            funcion.MostrarEstFis(cbEstadoFisico);
            funcion.MostrarCalidad(cbCalidadE);
            funcion.MostrarCalidad(cbCalidad);
            funcion.MostrarDaño(cbDanioE);
            funcion.MostrarDaño(cbDaño);
            funcion.MostrarAreaSecado2(cbArea);
            //funcion.MostrarAreaSecado2(CbAreaCons);
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
                    if (row["UbicacionRec"].ToString() != null)
                    {
                        CbUbicacionRec.Text = row["UbicacionRec"].ToString();
                    }
                    else
                    {
                        CbUbicacionRec.Text = "--";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudSacos.Value > 0)
                {
                    if (nudSacosE.Value > 0)
                    {
                        if (dtFEnvio.Value.Date <= dtpRecibido.Value.Date)
                        {
                            carga();
                        }
                        else
                        {
                            MessageBox.Show("La fecha de envio no puede ser mayor que la fecha de recibido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de sacos enviada no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La cantidad de sacos recibidos no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
        private async void carga()
        {
            timerAct.Enabled = true;
            PlCargaTran.Dock = DockStyle.Fill;
            PlCargaTran.Visible = true;
            PlCargaTran.BringToFront();
            await Task.Delay(1500);
            InsertarLote();
            await Task.Delay(1000);
            PlCargaTran.Visible = false;
            timerAct.Enabled = false;
            PEnvio.Dock = DockStyle.Fill;
            PEnvio.Visible = true;
        }
        private void InsertarLote()
        {
            if (validar() && ValidarE())
            {
                if (CHBConsSM.Checked == true)
                {
                    Consolidado = "Si";
                }
                else
                {
                    Consolidado = "";
                }
                LRecepcion parametros = new LRecepcion();
                DRecepcion funcion = new DRecepcion();
                parametros.Ticket = txtTK.Text.Replace(" ", "");
                parametros.FRecibido = Convert.ToDateTime(dtpRecibido.Text);
                parametros.Patio = CbPatio.Text;
                parametros.UbicacionRec = CbUbicacionRec.Text;
                parametros.IdArea = int.Parse(cbArea.SelectedValue.ToString());
                parametros.MTNR = txtMTNR.Text;
                parametros.IdEstFis = int.Parse(cbEstadoFisico.SelectedValue.ToString());
                parametros.IdCalidad = int.Parse(cbCalidad.SelectedValue.ToString());
                parametros.IdDaño = int.Parse(cbDaño.SelectedValue.ToString());
                parametros.Sacos = Convert.ToInt32(nudSacos.Value);
                parametros.Peso = Convert.ToDouble(txtKgs.Text);
                parametros.Merma = Convert.ToDouble(LblMerma.Text);
                parametros.IdRecibidor = int.Parse(cbRecibidor.SelectedValue.ToString());
                parametros.Digitador = Login.NombreA;
                parametros.Consolidado = Consolidado;
                parametros.Cosecha = LblCosecha.Text;


                LEnvio par = new LEnvio();
                par.Ticket = txtTK.Text.Replace(" ", "");
                par.FEnvio = dtFEnvio.Value;
                par.IdAgencia = int.Parse(cbAgencia.SelectedValue.ToString());
                par.IdAcopio = int.Parse(cbAcopio.SelectedValue.ToString());
                par.IdCliente = int.Parse(cbCliente.SelectedValue.ToString());
                par.MTNT = txtMTNT.Text;
                par.IdTCompra = int.Parse(cbCompra.SelectedValue.ToString());
                par.IdCertificacionE = int.Parse(cbCertificacion.SelectedValue.ToString());
                par.IdEsFisico = int.Parse(cbEsFisico.SelectedValue.ToString());
                par.IdCalidadE = int.Parse(cbCalidadE.SelectedValue.ToString());
                par.IdDanioE = int.Parse(cbDanioE.SelectedValue.ToString());
                par.SacosE = Convert.ToInt32(nudSacosE.Value);
                par.PesoE = Convert.ToDouble(txtPesoE.Text);
                par.Tally = TxtTally.Text;

                if (funcion.InsertarLote2(parametros, par) == true)
                {
                    //frmInicio fr = new frmInicio();
                    DataTable dt = new DataTable();
                    Task.Delay(3000);
                    //funcion.MostrarLote(ref dt, desde, hasta);
                    //dtInventario.DataSource = dt;
                    //PlRecepcion.Visible = false;
                    //PRecepcion.Visible = false;
                    Alerta();
                    Limpiar();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void Alerta()
        {
            timerAct.Enabled = true;
            PlAlerta.BringToFront();
            PlAlerta.Visible = true;
            await Task.Delay(2000);
            PlAlerta.Visible = false;
            timerAct.Enabled = false;
        }
        private bool ValidarE()
        {
            double entero;
            if (!double.TryParse(txtPesoE.Text, out entero))
            {
                return false;
            }
            return !(txtPesoE.Text == "" ||
                cbCompra.Text == "" || cbDanioE.Text == ""
            || cbCertificacion.Text == "" || cbEsFisico.Text == "" || cbCalidadE.Text == "");
        }
        private bool validar()
        {
            double entero;
            if (!double.TryParse(txtKgs.Text, out entero))
            {
                return false;
            }
            return !(txtKgs.Text == "" || txtTK.Text == "" || cbArea.Text == "" || cbCalidad.Text == "" || cbDaño.Text == ""
            || cbEstadoFisico.Text == "" || cbRecibidor.Text == "");
        }
        private bool validarEditar()
        {
            double entero;
            if (!double.TryParse(txtPesoE.Text, out entero))
            {
                return false;
            }
            return !(cbCertificacion.Text == "" || cbEstadoFisico.Text == "" || cbCalidadE.Text == "" || cbDaño.Text == "" || txtPesoE.Text == "" || cbArea.Text == "" || cbEsFisico.Text == ""
               || cbCalidad.Text == "" || cbDanioE.Text == "" || txtKgs.Text == "");
        }

        private void cbAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DRecepcion funcion = new DRecepcion();
            if (cbAgencia.SelectedValue != null)
            {
                funcion.MostrarAcopioAgencia(cbAcopio, (int)cbAgencia.SelectedValue);
            }
            else
            {
                cbAcopio.Text = null;
            }
        }

        private void txtPesoE_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LblMerma.Text = txtPesoE.Text;
                double Kilos = double.Parse(txtPesoE.Text);
                Kilos = Kilos / 46;
                LblQQsEn.Text = Math.Round(Kilos, 2).ToString();

            }
            catch (Exception)
            {
                txtPesoE.Text = Convert.ToString(0);
            }
        }

        private void ChUA_CheckedChanged(object sender, EventArgs e)
        {
            DRecepcion funcion = new DRecepcion();
            if (ChUA.Checked == true)
            {
                funcion.MostrarCalidadUA(cbCalidadE);
                funcion.MostrarCalidadUA(cbCalidad);
            }
            else
            {
                funcion.MostrarCalidad(cbCalidadE);
                funcion.MostrarCalidad(cbCalidad);
            }
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbArea.Text == "Control Patio")
            {
                CbPatio.Enabled = true;
                CbUbicacionRec.Enabled = true;
                DControlPatio fun = new DControlPatio();
                fun.MostrarPatio(CbPatio);
            }
            else
            {
                CbPatio.Text = "SM";
                CbUbicacionRec.Text = "SM";
                CbPatio.Enabled = false;
                CbUbicacionRec.Enabled = false;
            }
        }

        private void CbPatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbPatio.Text == "SM")
            {
                CbUbicacionRec.Text = "SM";
            }
            else
            {
                DControlPatio funcion = new DControlPatio();
                if (CbPatio.SelectedValue != null)
                {
                    funcion.MostrarPatioUbicacion(CbUbicacionRec, (int)CbPatio.SelectedValue);
                }
                else
                {
                    CbUbicacionRec.Text = null;
                }
            }
        }

        private void CHBConsSM_CheckedChanged(object sender, EventArgs e)
        {
            if (CHBConsSM.Checked == true)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que este lote es consolidado de secado mecánico?", "Consolidar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cbArea.Text = "Secado Mecánico";
                }
                else
                {
                    CHBConsSM.Checked = false;
                }
            }
        }

        private void txtKgs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double Kilos = double.Parse(txtKgs.Text);
                Kilos = Kilos / 46;
                LblQQs.Text = Math.Round(Kilos, 2).ToString();
                decimal PesoE, kgs, merma;
                PesoE = Convert.ToDecimal(txtPesoE.Text);
                kgs = Convert.ToDecimal(txtKgs.Text);
                merma = kgs - PesoE;
                //txtMerma.Text = Convert.ToString(fin);
                LblMerma.Text = Math.Round(merma, 2).ToString();
            }
            catch (Exception)
            {
                //txtKgs.Text = Convert.ToString(0);
            }
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
            CbPatio.SelectedItem = null;
            CbUbicacionRec.SelectedItem = null;
        }
    }
}
