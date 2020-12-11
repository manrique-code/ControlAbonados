using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlAbonados.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using ControlAbonados.Reportes;
using System.Threading;

namespace ControlAbonados.Forms
{
    public partial class ReportesMenu : Form
    {
        public ReportesMenu()
        {
            InitializeComponent();
        }

        private void irMenu()
        {
            Thread c = new Thread(new ThreadStart(() => Application.Run(new Menu())));
            c.Start();
            this.Close();
        }

        private void ReportesMenu_Load(object sender, EventArgs e)
        {
            DataAbonadoAccess.obtenerMeses(cboMes);
            DataAbonadoAccess.obtenerEstadoPegues(cboEstado);
        }

        public void crearOAbrirFolderReportes()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderEspecifico = $"{desktopPath}\\Reportes";
            Process.Start("explorer.exe", folderEspecifico);
            /*try
            {
                if (Directory.Exists(folderEspecifico))
                {
                    Process.Start("explorer.exe", $"@{folderEspecifico}");
                }
                else
                {
                    Directory.CreateDirectory(folderEspecifico);
                    Process.Start("explorer.exe", folderEspecifico);
                }
            }
            catch (Exception e)
            {
                Process.Start("explorer.exe", desktopPath);
                Console.Write(e.Message);
            }*/

        }

        public void generarReporteTodoAbonados()
        {
            string directorioReporte = $"{Directory.GetCurrentDirectory()}\\listadoTodoAbonados.rpt";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderEspecifico = $@"{desktopPath}\\Reportes\\ReporteTodoAbonado.pdf";

            pgbTodoAbonados.Visible = true;

            using (ReportDocument oRep = new ReportDocument())
            {
                using (frmListadoTodoAbonados form = new frmListadoTodoAbonados())
                {
                    pgbTodoAbonados.Value = 25;
                    oRep.Load($@"{desktopPath}\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\Reportes\ListadoTodoAbonados.rpt");
                    oRep.Refresh();
                    form.crystalReportViewer1.ReportSource = oRep;
                    form.Show();
                    oRep.ExportToDisk(ExportFormatType.PortableDocFormat, folderEspecifico);
                    form.Close();
                    pgbTodoAbonados.Value = 65;
                }
            }
            crearOAbrirFolderReportes();
            pgbTodoAbonados.Value = 100;
            pgbTodoAbonados.Visible = false;
        }

        private void generarReportesAbonado()
        {

        }

        private void btnAbonado_Click(object sender, EventArgs e)
        {
            generarReporteTodoAbonados();
            //string directorioReporte = $"@{Directory.GetCurrentDirectory()}\\listadoTodoAbonados.rpt";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            irMenu();
        }
    }
}
