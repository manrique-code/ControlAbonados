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
using ControlAbonados.Forms;
using ControlAbonados.Data;
using ControlAbonados.Models;
using ControlAbonados.Data;

namespace ControlAbonados
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void iniciarFormularioAbonados()
        {
            Thread c = new Thread(new ThreadStart( () => Application.Run(new Abonados())));
            c.Start();
            this.Close();
        }

        private void iniciarFormularioReportes()
        {
            Thread c = new Thread(new ThreadStart(() => Application.Run(new ReportesMenu())));
            c.Start();
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                //cantidad de abonados por estado
                int cantidadAbonadosActivos = DataMenuAccess.cantidadAbonadosPorEstado("Activo");
                int cantidadAbonadosInactivos = DataMenuAccess.cantidadAbonadosPorEstado("Inactivo");
                int cantidadAbonadosSuspendidos = DataMenuAccess.cantidadAbonadosPorEstado("Suspendido");
                int cantidadAbonadosCasaSola = DataMenuAccess.cantidadAbonadosPorEstado("Casa sola");
                int cantidadAbonadosCortado = DataMenuAccess.cantidadAbonadosPorEstado("Cortado");
                int cantidadAbonadosSolarB = DataMenuAccess.cantidadAbonadosPorEstado("Solar baldío");

                //cantidad de abonados por tipo
                int cantidadAbonadosTerceraEdad = DataMenuAccess.cantidadAbonadosPorTipo("Tercera Edad");
                int cantidadAbonadosCisterna = DataMenuAccess.cantidadAbonadosPorTipo("Cisterna");
                int cantidadAbonadosNormales = DataMenuAccess.cantidadAbonadosPorTipo("Normal");

                int totalAbonados = DataMenuAccess.cantidadTotalAbonados();

                int totalInactivos = cantidadAbonadosCasaSola + cantidadAbonadosCortado + cantidadAbonadosInactivos + cantidadAbonadosSolarB + cantidadAbonadosSuspendidos;
                decimal porcentajePago = (Convert.ToDecimal(cantidadAbonadosActivos)/Convert.ToDecimal(totalAbonados))*100;

                lblAbonadosActivos.Text = $"{cantidadAbonadosActivos} abonados.";
                lblAbonadosInactivos.Text = $"{totalInactivos} abonados.";
                lblTotalAbonados.Text = $"{totalAbonados} abonados";

                lblAbonadosCisterna.Text = $"{cantidadAbonadosCisterna} abonados.";
                lblAbonadosNormales.Text = $"{cantidadAbonadosNormales} abonados.";
                lblAbonadosTercerEdad.Text = $"{cantidadAbonadosTerceraEdad} abonados.";

                lblPorcentajeAbonadosPago.Text = $"{Math.Round(porcentajePago)}% de los abonados\nvan al día.";
                pgbPago.Value = Convert.ToInt32(porcentajePago);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. \n Intentelo de nuevo más tarde.");
            }
        }

        private void btnAbonado_Click(object sender, EventArgs e)
        {
            iniciarFormularioAbonados();
        }

        private void pnlAbonados_Click(object sender, EventArgs e)
        {
            iniciarFormularioAbonados();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            iniciarFormularioReportes();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            iniciarFormularioReportes();
        }
    }
}
