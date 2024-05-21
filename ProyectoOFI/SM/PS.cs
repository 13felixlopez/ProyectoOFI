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

namespace ProyectoOFI.SM
{
    public partial class PS : UserControl
    {
        public PS()
        {
            InitializeComponent();
        }

        private void PS_Load(object sender, EventArgs e)
        {
            MostrarTicketsEnLabels();
            Estilo();
        }
        protected void MostrarTicketsEnLabels()
        {
            DPS datos = new DPS();
            DataTable tablaTickets = datos.MostrarPS();
            foreach (DataRow fila in tablaTickets.Rows)
            {
                int ps = Convert.ToInt32(fila["PS"]);
                string ticket = fila["Ticket"].ToString();
                MostrarTicketEnLabel(ps, ticket);
            }
        }
        protected void MostrarTicketEnLabel(int ps, string ticket)
        {
            // Encuentra el Label correspondiente a la POAV
            string lblName = "LblPS" + ps;
            System.Windows.Forms.Control[] controls = Controls.Find(lblName, true);
            if (controls.Length > 0 && controls[0] is Label)
            {
                // Muestra el ticket en el Label
                Label lblTicket = (Label)controls[0];
                lblTicket.Text = ticket;
            }
        }
        public void Estilo()
        {
            //Rojo
            int r1 = 240, g1 = 110, b1 = 67;
            //Verde
            int r = 0; int p = 221;
            int f = 117;
            #region Guardiola1
            if (LblPS1.Text == "--")
            {
                BtnPS1.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS1.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS1.BackColor = Color.FromArgb(r, p, f);
                LblPS1.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola2
            if (LblPS2.Text == "--")
            {
                BtnPS2.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS2.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS2.BackColor = Color.FromArgb(r, p, f);
                LblPS2.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola3
            if (LblPS3.Text == "--")
            {
                BtnPS3.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS3.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS3.BackColor = Color.FromArgb(r, p, f);
                LblPS3.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola4
            if (LblPS4.Text == "--")
            {
                BtnPS4.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS4.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS4.BackColor = Color.FromArgb(r, p, f);
                LblPS4.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola5
            if (LblPS5.Text == "--")
            {
                BtnPS5.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS5.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS5.BackColor = Color.FromArgb(r, p, f);
                LblPS5.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola6
            if (LblPS6.Text == "--")
            {
                BtnPS6.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS6.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS6.BackColor = Color.FromArgb(r, p, f);
                LblPS6.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola7
            if (LblPS7.Text == "--")
            {
                BtnPS7.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS7.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS7.BackColor = Color.FromArgb(r, p, f);
                LblPS7.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola8
            if (LblPS8.Text == "--")
            {
                BtnPS8.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS8.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS8.BackColor = Color.FromArgb(r, p, f);
                LblPS8.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola9
            if (LblPS9.Text == "--")
            {
                BtnPS9.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS9.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS9.BackColor = Color.FromArgb(r, p, f);
                LblPS9.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola10
            if (LblPS10.Text == "--")
            {
                BtnPS10.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS10.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS10.BackColor = Color.FromArgb(r, p, f);
                LblPS10.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola11
            if (LblPS11.Text == "--")
            {
                BtnPS11.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS11.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS11.BackColor = Color.FromArgb(r, p, f);
                LblPS11.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola12
            if (LblPS12.Text == "--")
            {
                BtnPS12.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS12.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS12.BackColor = Color.FromArgb(r, p, f);
                LblPS12.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola13
            if (LblPS13.Text == "--")
            {
                BtnPS13.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS13.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS13.BackColor = Color.FromArgb(r, p, f);
                LblPS13.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola14
            if (LblPS14.Text == "--")
            {
                BtnPS14.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS14.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS14.BackColor = Color.FromArgb(r, p, f);
                LblPS14.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola15
            if (LblPS15.Text == "--")
            {
                BtnPS15.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS15.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS15.BackColor = Color.FromArgb(r, p, f);
                LblPS15.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola16
            if (LblPS16.Text == "--")
            {
                BtnPS16.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS16.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS16.BackColor = Color.FromArgb(r, p, f);
                LblPS16.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola17
            if (LblPS17.Text == "--")
            {
                BtnPS17.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS17.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS17.BackColor = Color.FromArgb(r, p, f);
                LblPS17.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola18
            if (LblPS18.Text == "--")
            {
                BtnPS18.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS18.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS18.BackColor = Color.FromArgb(r, p, f);
                LblPS18.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
        }
    }
}
