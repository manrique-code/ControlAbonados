using ControlAbonados.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlAbonados.Forms
{
    public partial class Abonados : Form
    {
        bool _drawborderAbonado;
        bool _drawborderPegue;
        bool _drawborderListado;

        public Abonados()
        {
            InitializeComponent();
        }

        /* -------------------- Funcionalidades -------------------- */

        private void abrirMenu()
        {
            Thread c = new Thread(new ThreadStart(() => Application.Run(new Abonados())));
            c.Start();
            this.Close();
        }

        private void insetarAbonado()
        {
            Abonado abonado = new Abonado
            {
                NumIdentidad = mTxtNumIdentidad.Text,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                FechaNacimiento = Convert.ToDateTime(dtpFechaNac.Text)
            };
        }



        private void seleccionarPanelPegues()
        {
            tabAbonados.SelectedIndex = 1;
            pnlPegues.BackColor = Color.FromArgb(1, 42, 70);
            pnlMenu.BackColor = Color.FromArgb(7, 67, 106);
            pnlListados.BackColor = Color.FromArgb(7, 67, 106);
            pnlAbonados.BackColor = Color.FromArgb(7, 67, 106);
            _drawborderAbonado = false;
        }

        private void seleccionarPanelAbonado()
        {
            tabAbonados.SelectedIndex = 0;
            pnlAbonados.BackColor = Color.FromArgb(1, 42, 70);
            pnlMenu.BackColor = Color.FromArgb(7, 67, 106);
            pnlListados.BackColor = Color.FromArgb(7, 67, 106);
            pnlPegues.BackColor = Color.FromArgb(7, 67, 106);
        }

        private void seleccionarPanelListados()
        {
            tabAbonados.SelectedIndex = 2;
            pnlListados.BackColor = Color.FromArgb(1, 42, 70);
            pnlMenu.BackColor = Color.FromArgb(7, 67, 106);
            pnlPegues.BackColor = Color.FromArgb(7, 67, 106);
            pnlAbonados.BackColor = Color.FromArgb(7, 67, 106);
        }

        /* -------------------- UX -------------------- */
        private void pnlMenu_MouseHover(object sender, EventArgs e)
        {
            pnlMenu.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void pnlMenu_MouseLeave(object sender, EventArgs e)
        {
            pnlMenu.BackColor = Color.FromArgb(7, 67, 106);
        }

        private void pnlPegues_Click(object sender, EventArgs e)
        {
            seleccionarPanelPegues();
        }

        private void pnlAbonados_Click(object sender, EventArgs e)
        {
            seleccionarPanelAbonado();
        }

        private void pnlListados_Click(object sender, EventArgs e)
        {
            seleccionarPanelListados();
        }

        private void pnlAbonados_Paint(object sender, PaintEventArgs e)
        {

            if (_drawborderAbonado)
            {
                base.OnPaint(e);
                ControlPaint.DrawBorder(e.Graphics, this.pnlAbonados.ClientRectangle,
                                                Color.White, 3, ButtonBorderStyle.Solid,
                                                Color.White, 0, ButtonBorderStyle.Solid,
                                                Color.White, 0, ButtonBorderStyle.Solid,
                                                Color.White, 0, ButtonBorderStyle.Solid);
            }

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            abrirMenu();
        }

        private void lblAbonados_Click(object sender, EventArgs e)
        {
            abrirMenu();
        }

        private void Abonados_Load(object sender, EventArgs e)
        {
            _drawborderAbonado = true;
            lblNombreCant.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int cantidad = txtNombres.Text.Length;
            int cantidadRestante = 50 - cantidad;
            if(cantidadRestante < 10)
            {
                lblNombreCant.Visible = true;
                lblNombreCant.ForeColor = Color.FromArgb(231, 76, 60);
                lblNombreCant.Text = cantidadRestante.ToString();
            } else
            {
                lblNombreCant.Visible = false;
            }
            
        }
    }
}
