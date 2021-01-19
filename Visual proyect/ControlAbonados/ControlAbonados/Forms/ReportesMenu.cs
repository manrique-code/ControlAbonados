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
            DataAbonadoAccess.obtenerEstadoPegues(cboEstado, 1);
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
            pgbTodoAbonados.Visible = true;

            string directorioReporte = $"{Directory.GetCurrentDirectory()}\\listadoTodoAbonados.rpt";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderEspecifico = $@"{desktopPath}\\Reportes\\ReporteTodoAbonado.pdf";


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
            pgbAbonadosActivos.Visible = true;

            string directorioReporte = $"{Directory.GetCurrentDirectory()}\\listadoTodoAbonados.rpt";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderEspecifico = $@"{desktopPath}\\Reportes\\ReporteAbonadosActivos.pdf";


            using (ReportDocument oRep = new ReportDocument())
            {
                using (frmListadoTodoAbonados form = new frmListadoTodoAbonados())
                {
                    pgbAbonadosActivos.Value = 25;
                    oRep.Load($@"{desktopPath}\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\Reportes\ListadoAbonadosActivos.rpt");
                    oRep.Refresh();
                    form.crystalReportViewer1.ReportSource = oRep;
                    form.Show();
                    oRep.ExportToDisk(ExportFormatType.PortableDocFormat, folderEspecifico);
                    form.Close();
                    pgbTodoAbonados.Value = 65;
                }
            }
            crearOAbrirFolderReportes();
            pgbAbonadosActivos.Value = 100;
            pgbAbonadosActivos.Visible = false;
        }

        private void generarReporteMes()
        {
            pgbMes.Visible = true;

            string mes = cboMes.Text;

            string directorioReporte = $"{Directory.GetCurrentDirectory()}\\listadoTodoAbonados.rpt";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderEspecifico = $@"{desktopPath}\\Reportes\\ReporteMes{mes}.pdf";


            using (ReportDocument oRep = new ReportDocument())
            {
                using (frmListadoTodoAbonados form = new frmListadoTodoAbonados())
                {
                    pgbMes.Value = 25;
                    oRep.Load($@"{desktopPath}\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\Reportes\ListadoMes.rpt");
                    oRep.SetDataSource(ControlAbonados.Properties.Settings.Default.cnnString);
                    oRep.Refresh();
                    oRep.SetParameterValue("@mes", mes);
                    form.crystalReportViewer1.ReportSource = oRep;
                    form.Show();
                    oRep.ExportToDisk(ExportFormatType.PortableDocFormat, folderEspecifico);
                    form.Close();
                    pgbMes.Value = 65;
                }
            }
            crearOAbrirFolderReportes();
            pgbMes.Value = 100;
            pgbMes.Visible = false;
        }

        private void generarReportesEstado()
        {
            pgbEstado.Visible = true;

            string estado = cboEstado.Text;

            string directorioReporte = $"{Directory.GetCurrentDirectory()}\\listadoTodoAbonados.rpt";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderEspecifico = $@"{desktopPath}\\Reportes\\Reporte{estado}.pdf";


            using (ReportDocument oRep = new ReportDocument())
            {
                using (frmListadoTodoAbonados form = new frmListadoTodoAbonados())
                {
                    pgbEstado.Value = 25;
                    oRep.Load($@"{desktopPath}\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\Reportes\ListadoEstado.rpt");
                    oRep.Refresh();
                    oRep.SetParameterValue("@estado", estado);
                    form.crystalReportViewer1.ReportSource = oRep;
                    form.Show();
                    oRep.ExportToDisk(ExportFormatType.PortableDocFormat, folderEspecifico);
                    form.Close();
                    pgbEstado.Value = 65;
                }
            }
            crearOAbrirFolderReportes();
            pgbEstado.Value = 100;
            pgbEstado.Visible = false;
        }

        private void btnAbonado_Click(object sender, EventArgs e)
        {

            try
            {
                generarReporteTodoAbonados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. \n Intentelo más tarde.", "Error", MessageBoxButtons.OK);
            }
            
            //string directorioReporte = $"@{Directory.GetCurrentDirectory()}\\listadoTodoAbonados.rpt";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            irMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                generarReportesAbonado();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}.\n Intentelo más tarde.", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            try
            {
                generarReporteMes();

            }catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}.\nIntentelo de nuevo más tarde.", "Error", MessageBoxButtons.OK);
            }

        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {

            } catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}.\nIntentelo de nuevo más tarde.", "Error", MessageBoxButtons.OK);
            }
            generarReportesEstado();
        }
    }
}
