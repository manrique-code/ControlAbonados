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
            //WindowState = FormWindowState.Maximized;
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
