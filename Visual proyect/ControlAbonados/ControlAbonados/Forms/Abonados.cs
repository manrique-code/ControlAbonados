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
using ControlAbonados.Data;

namespace ControlAbonados.Forms
{
    public partial class Abonados : Form
    {
        bool _drawborderAbonado;
        bool _drawborderPegue;
        bool _drawborderListado;
        bool _drawborderNombres;
        Color nombresColor;

        int cantPegues = 0;
        int numeroPegueActual = 0;

        public Abonados()
        {
            InitializeComponent();
        }

        /* -------------------- Funcionalidades -------------------- */

        private void abrirMenu()
        {
            Thread c = new Thread(new ThreadStart(() => Application.Run(new Menu())));
            c.Start();
            this.Close();
        }

        // validaciones del formulario
        public bool validarAbonados()
        {
            if (txtNombres.Text.Trim() == "")
            {
                nombresColor = Color.Red;
                errorAbonado.SetIconPadding(pnlNombres, 3);
                errorAbonado.SetError(pnlNombres, "Por favor, ingrese un nombre");
                return false;
            }

            if (txtApellidos.Text.Trim() == "")
            {
                errorAbonado.SetError(pnlApellidos, "Ingrese sus nombres");
                return false;
            }

            return true;
        }

        private bool validarPegue()
        {
            if (Convert.ToInt32(numCantPegues.Value) < 1)
            {
                errorAbonado.SetError(numCantPegues, "Ingrese un pegue");
                return false;
            }

            // validando bloque
            if (Convert.ToInt32(numBloque.Value) == 0 || !DataAbonadoAccess.existeBloque(Convert.ToInt32(numBloque.Value)))
            {
                errorAbonado.SetIconPadding(lblBloque, 3);
                errorAbonado.SetError(lblBloque, "Ingrese un bloque correcto");
                return false;
            }

            if (Convert.ToInt32(numCasa.Value) == 0)
            {
                errorAbonado.SetIconPadding(lblCasa, 3);
                errorAbonado.SetError(lblCasa, "Ingrese una casa correcta");
                return false;
            }

            /*if (lsbMeses.Items.Count == 0)
            {
                errorAbonado.SetIconPadding(lblMesesPagados, 3);
                errorAbonado.SetError(lblMesesPagados, "Ingrese un bloque correcto");
                return false;
            }*/
            return true;
        }

        /*private void contarResultados()
        {
            lblCantResultados.Text = $"Mostrandose: {dgvListados.Rows.Count} abonados.";
        }*/

        private void guardaPegueEditado()
        {
            string[] fechaEstadoPegue;

            string nombres = txtNombreTab2.Text;
            string apellidos = txtApellidosTab2.Text;
            string numIdentidad = txtNumeroIdentidadTab2.Text;
            string bloque = numBloque.Value.ToString();
            string casa = numCasa.Value.ToString();
            string tipoPegueNombre = cboTipoPegue.Text;
            int tipoPegueID = cboTipoPegue.SelectedIndex + 1;
            string estadoPegueNombre = cboEstado.Text;
            int estadoPegueID = cboEstado.SelectedIndex + 1;
            int cantidadMesesPagados = Convert.ToInt32(lblCantMesesPagados.Text);
            string codPegue = lblCodPegue.Text;
            int abonadoId = Convert.ToInt32(lblIdAbonado.Text);
            string nota = txtNota.Text;

            string mesEstado;
            string yearEstado;
            int mesEstadoID;


            pgbPorcentajeAlmacenado.Enabled = true;
            pgbPorcentajeAlmacenado.Visible = true;
            pgbPorcentajeAlmacenado.Value = 25;


            string numeroIdentidad = DataAbonadoAccess.obtenerNumIdentidadByID(abonadoId);
            int idTipoPegue = DataAbonadoAccess.obtenerTipoPegueIDPorNombre(tipoPegueNombre);
            int idEstadoPegue = DataAbonadoAccess.obtenerEstadoPegueIDPorNombre(estadoPegueNombre);
            bool tieneFechaEstadoPegue = DataAbonadoAccess.existeFechaEstadoPegue(codPegue);

            if (tieneFechaEstadoPegue)
            {
                fechaEstadoPegue = DataAbonadoAccess.obtenerMesDeFechaControlPegue(codPegue);
                mesEstado = cboMesEstado.Text;
                yearEstado = numYearEstado.Value.ToString();
                mesEstadoID = cboMesEstado.SelectedIndex + 1;

                pgbPorcentajeAlmacenado.Value = 50;

                if (Convert.ToInt32(fechaEstadoPegue[4]) != estadoPegueID)
                {
                    if (estadoPegueID == 0)
                    {
                        DataAbonadoAccess.eliminarFechaEstadoPegue(codPegue);
                    } else
                    {
                        DataAbonadoAccess.eliminarFechaEstadoPegue(codPegue);
                        guardarFechaEstadoPegue(estadoPegueID, mesEstadoID, codPegue, yearEstado);
                    }
                }
            } else
            {
                mesEstado = cboMesEstado.Text;
                yearEstado = numYearEstado.Value.ToString();
                mesEstadoID = cboMesEstado.SelectedIndex + 1;
                guardarFechaEstadoPegue(estadoPegueID, mesEstadoID, codPegue, yearEstado);
            }



            if (cantidadMesesPagados < lsbMeses.Items.Count)
            {
                cantidadMesesPagados = (cantidadMesesPagados == 0) ? 1 : cantidadMesesPagados;
                for (int i = cantidadMesesPagados; i <= lsbMeses.Items.Count; i++)
                {
                    guardarControlPago(codPegue, i);
                }
                pgbPorcentajeAlmacenado.Value = 75;
            }

            DataAbonadoAccess.actualizarPegue(codPegue, casa, tipoPegueID, estadoPegueID, Convert.ToInt32(bloque), nota);
            pgbPorcentajeAlmacenado.Value = 100;

            pgbPorcentajeAlmacenado.Visible = false;
            pgbPorcentajeAlmacenado.Value = 0;
            resetearPegue();
            resetearAbonadoEnPegue();

            MessageBox.Show($"Pegue de {nombres} {apellidos} actualizado correctamente", "Pegue", MessageBoxButtons.OK);

            seleccionarPanelListados();

        }

        private void eliminarFEP(string codPegue)
        {
            bool existeFEP = DataAbonadoAccess.existeFechaEstadoPegue(codPegue);
            if (existeFEP)
            {
                DataAbonadoAccess.eliminarFechaEstadoPegue(codPegue);
            }
        }

        /*
         * funcion que añade meses de pago a un pegue
         */
        private void addMesPago(string codPegue)
        {
            int ultimoMesPago = DataAbonadoAccess.obtenerUltimoMesPagado(codPegue);

            for (int i = ultimoMesPago; i <= lsbMeses.Items.Count; i++)
            {
                guardarControlPago(codPegue, i);
            }
        }

        /*
         * mueve los datos de la tabla de listado al tab de pegues
         */
        private void moverPegueAEdicion() {
            string[] meses = {
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            };
            string[] fechaEstadoPegue;

            string tipoPegue = dgvListados.CurrentRow.Cells[3].Value.ToString();
            string bloque = dgvListados.CurrentRow.Cells[4].Value.ToString();
            string casa = dgvListados.CurrentRow.Cells[5].Value.ToString();
            string estadoPegue = dgvListados.CurrentRow.Cells[6].Value.ToString();
            int cantidadMesesPagados = Convert.ToInt32(dgvListados.CurrentRow.Cells[7].Value);
            int idAbonado = Convert.ToInt32(dgvListados.CurrentRow.Cells[0].Value);
            string nombre = dgvListados.CurrentRow.Cells[1].Value.ToString();
            string apellido = dgvListados.CurrentRow.Cells[2].Value.ToString();

            string numeroIdentidad = DataAbonadoAccess.obtenerNumIdentidadByID(idAbonado);
            int idTipoPegue = DataAbonadoAccess.obtenerTipoPegueIDPorNombre(tipoPegue);
            int idEstadoPegue = DataAbonadoAccess.obtenerEstadoPegueIDPorNombre(estadoPegue);
            string codiPegue = DataAbonadoAccess.obtenerCodigoPegueByPegue(bloque, casa);
            bool tieneFechaEstadoPegue = DataAbonadoAccess.existeFechaEstadoPegue(codiPegue);

            string notas = dgvListados.CurrentRow.Cells[8].Value.ToString();


            if (tieneFechaEstadoPegue)
            {
                fechaEstadoPegue = DataAbonadoAccess.obtenerMesDeFechaControlPegue(codiPegue);
                //if()
                cboMesEstado.SelectedIndex = Convert.ToInt32(fechaEstadoPegue[0]) - 1;
                numYearEstado.Value = Convert.ToInt32(fechaEstadoPegue[2]);
            }

            lblCantMesesPagados.Text = cantidadMesesPagados.ToString();
            numBloque.Value = Convert.ToInt32(bloque);
            numCasa.Value = Convert.ToInt32(casa);
            cboTipoPegue.SelectedIndex = idTipoPegue - 1;
            cboEstado.SelectedIndex = idEstadoPegue - 1;
            DataAbonadoAccess.excluirMes(cboMes, cantidadMesesPagados);
            lblCodPegue.Text = codiPegue;
            txtNombreTab2.Text = nombre;
            txtApellidosTab2.Text = apellido;
            txtNumeroIdentidadTab2.Text = numeroIdentidad;
            lblIdAbonado.Text = idAbonado.ToString();
            txtNota.Text = notas;
            lblCantPegues.Text = $"Modificando pegue";
            lblTitulo.Text = "Modificando el pegue de:";

            for (int i = 0; i < cantidadMesesPagados; i++)
            {
                lsbMeses.Items.Add(meses[i]);
            }

            btnSiguientePegue.Enabled = false;
            btnSiguientePegue.Visible = false;
            btnGuardarPegue.Enabled = true;
            btnGuardarPegue.Visible = true;

            seleccionarPanelPegues();
        }

        /*
         * funcion para mover los datos desde la datagridview hasta el tab de abonados
         */
        private bool moverAbonadosAEdicion()
        {
            int idAbonado = Convert.ToInt32(dgvListados.CurrentRow.Cells[0].Value);
            string nombre = dgvListados.CurrentRow.Cells[1].Value.ToString();
            string apellido = dgvListados.CurrentRow.Cells[2].Value.ToString();
            string numeroIdentidad = DataAbonadoAccess.obtenerNumIdentidadByID(idAbonado);

            numCantPegues.Enabled = false;

            lblIdAbonadoEdicion.Text = idAbonado.ToString();
            txtNombres.Text = nombre;
            txtApellidos.Text = apellido;
            mTxtNumIdentidad.Text = numeroIdentidad;
            btnGuardarAbonado.Enabled = false;
            btnGuardarAbonado.Visible = false;
            btnGuardarAbonadoEditado.Visible = true;

            seleccionarPanelAbonado();
            return true;
        }


        /*
         * funcion para obtener editar un abonado
         */
        private void guardarAbonadoEditado()
        {
            string nombre = txtNombres.Text;
            int idAbonado = Convert.ToInt32(lblIdAbonadoEdicion.Text);
            string apellido = txtApellidos.Text;
            string numeroIdentidad = (mTxtNumIdentidad.Text == "    -    -") ? "" : mTxtNumIdentidad.Text;

            DataAbonadoAccess.actualizarAbonado(idAbonado, nombre, apellido, numeroIdentidad);
        }

        private void habilitarCboBusqueda(bool habilitar, string tipoBusqueda = "")
        {
            if (habilitar)
            {
                cboBusquedas.Enabled = habilitar;
                cboBusquedas.Visible = habilitar;
                pnlBusqueda.Enabled = habilitar;
                pnlBusqueda.Visible = habilitar;
                btnBusqueda.Enabled = habilitar;
                btnBusqueda.Visible = habilitar;
                switch (tipoBusqueda)
                {
                    case "Mes":
                        DataAbonadoAccess.obtenerMeses(cboBusquedas);
                        break;
                    case "Estado":
                        DataAbonadoAccess.obtenerEstadoPegues(cboBusquedas);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                cboBusquedas.Enabled = habilitar;
                cboBusquedas.Visible = habilitar;
            }
        }

        /*
         * funicion para habilitar controles de busqueda
         */
        private void habilitarControlesBusqueda(bool habilitar)
        {
            pnlBusqueda.Enabled = habilitar;
            txtBusqueda.Enabled = habilitar;
            btnBusqueda.Enabled = habilitar;
            pnlBusqueda.Visible = habilitar;
            txtBusqueda.Visible = habilitar;
            btnBusqueda.Visible = habilitar;

            cboBusquedas.Enabled = !habilitar;
            cboBusquedas.Visible = !habilitar;
        }

        /*
         * Funcion para resetear los controles de abonado
         */
        private void resetearAbonado()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            mTxtNumIdentidad.Clear();
            numCantPegues.Value = 1;
        }

        /*
         * Funcion para volver a solicitar un abonado
         */
        private void regresarASolicitarAbonado()
        {
            resetearPegue();
            txtNombres.Focus();
            seleccionarPanelAbonado();
        }


        /*funcion para guardar el pegue en la base de datos*/
        private void insertarPegueEnDB()
        {
            int cantidadPegues = Convert.ToInt32(lblCantidadPegues.Text);
            if (numeroPegueActual <= cantidadPegues)
            {
                int bloque = Convert.ToInt32(numBloque.Value);
                string casa = numCasa.Value.ToString();
                int tipoPegue = cboTipoPegue.SelectedIndex + 1;
                int estado = cboEstado.SelectedIndex + 1;

                int mesEstado = cboTipoPegue.SelectedIndex + 1;
                string año = numYearEstado.Value.ToString();

                int cantMesesPagados = lsbMeses.Items.Count;
                int idAbonado = Convert.ToInt32(lblIdAbonado.Text);
                string nombreAbonado = txtNombreTab2.Text;
                string apellidoAbonado = txtApellidosTab2.Text;

                string nota = txtNota.Text;

                int indiceCboEstadoPegue = cboEstado.SelectedIndex;

                pgbPorcentajeAlmacenado.Visible = true;


                // obteniendo el codigo de pegue 
                string codPegue = generarCodigoPegue(nombreAbonado, apellidoAbonado, bloque, Convert.ToInt32(casa));


                if (indiceCboEstadoPegue == 0)
                {
                    pgbPorcentajeAlmacenado.Value = 25;
                    guardarPegue(
                        codPegue,
                        idAbonado,
                        tipoPegue,
                        estado,
                        bloque,
                        casa,
                        nota);
                    pgbPorcentajeAlmacenado.Value = 50;

                    if (cantMesesPagados != 0)
                    {
                        for (int i = 0; i < cantMesesPagados; i++)
                        {
                            guardarControlPago(codPegue, i + 1);
                        }
                    }

                    //guardarFechaEstadoPegue(estado, 13, codPegue, "2000");
                    pgbPorcentajeAlmacenado.Value = 75;
                }
                else
                {
                    guardarPegue(
                        codPegue,
                        idAbonado,
                        tipoPegue,
                        estado,
                        bloque,
                        casa,
                        nota);
                    pgbPorcentajeAlmacenado.Value = 25;


                    //guardarControlPago(codPegue, 13);

                    pgbPorcentajeAlmacenado.Value = 50;

                    guardarFechaEstadoPegue(estado, mesEstado, codPegue, año);
                    pgbPorcentajeAlmacenado.Value = 75;
                }



                //DataAbonadoAccess.cargarTablaPegues(dgvBloqueCasa, idAbonado);
                agregarDatosTablaPegue(dgvBloqueCasa, bloque.ToString(), casa);
                pgbPorcentajeAlmacenado.Value = 100;
                resetearPegue();
                lblCantPegues.Text = $"Registrando pegue {numeroPegueActual} de {cantidadPegues}";
                numeroPegueActual++;
                numBloque.Focus();
                pgbPorcentajeAlmacenado.Visible = false;
                pgbPorcentajeAlmacenado.Value = 0;

                if (numeroPegueActual == cantidadPegues)
                {
                    resetearPegue();
                    resetearAbonadoEnPegue();
                    DataAbonadoAccess.cargarTablaListados(dgvListados);
                    MessageBox.Show($"Pegues de {nombreAbonado} {apellidoAbonado} guardados correctamente.", "Pegues", MessageBoxButtons.OK);
                    numeroPegueActual = 0;
                    regresarASolicitarAbonado();
                    txtNombres.Focus();

                }

            }

        }

        private void agregarDatosTablaPegue(DataGridView dgv, string bloque, string casa)
        {
            dgv.Rows.Add(bloque, casa);
        }

        /*
         * 
         */

        /*
         * funcion para guardar los controles de pago
         */
        private void guardarControlPago(
                string codigoPegue,
                int mesId
            )
        {
            ControlPago controlPago = new ControlPago
            {
                CodPegue = codigoPegue,
                IdMes = mesId,
                EstaPagado = true
            };

            DataAbonadoAccess.insertarControlPago(controlPago);
        }

        /*
         * funcion que guarda la fecha de lo estados del pegue
         */
        private void guardarFechaEstadoPegue(
                int estadoPegueId,
                int mesId,
                string codigoPegue,
                string year
            )
        {
            FechaEstadoPegue fechaEstadoPegue = new FechaEstadoPegue
            {
                IdEstadoPegue = estadoPegueId,
                IdMes = mesId,
                CodPegue = codigoPegue,
                Año = year
            };

            DataAbonadoAccess.insertarFechaEstadoPegue(fechaEstadoPegue);            
        }

        /*
         * Funcion que registra los abonados
         */
        private int guardarAbonado(
                string numeroIdentidad,
                string nombres,
                string apellidos
            )
        {

            Abonado a = new Abonado
            {
                NumIdentidad = numeroIdentidad,
                Nombres = nombres,
                Apellidos = apellidos
            };

            int idAbonado = DataAbonadoAccess.insertarAbonado(a);
            lblTituloAbonados.Text = "Abonado ingresado";
            return idAbonado;
        }

        /*
         * Funcion para genera un código de pegue
         */
        private string generarCodigoPegue(string nombreAbonado, string apellidoAbonado,int bloque, int casa)
        {
            string codigoPegue = "";

            nombreAbonado = nombreAbonado.ToLower();
            apellidoAbonado = apellidoAbonado.ToLower();

            if(casa < 10)
            {
                if (bloque < 10)
                {
                    // bloque solo tiene un digito
                    codigoPegue = $"{nombreAbonado[0]}{nombreAbonado[1]}{apellidoAbonado[0]}{apellidoAbonado[1]}#{bloque}0{casa}";
                } else if(bloque >= 10 && bloque < 100)
                {
                    codigoPegue = $"{nombreAbonado[0]}{apellidoAbonado[0]}#{bloque}--{casa}";
                } else if(bloque >= 100)
                {
                    codigoPegue = $"{nombreAbonado[0]}{apellidoAbonado[0]}#{bloque}-{casa}";
                }

            } else if(casa >= 10 && casa < 100)
            {
                // casa tiene dos digitos
                if (bloque < 10)
                {
                    // bloque solo tiene un digito
                    codigoPegue = $"{nombreAbonado[0]}{nombreAbonado[1]}{apellidoAbonado[0]}#{bloque}-{casa}";
                }
                else if (bloque >= 10 && bloque < 100)
                {
                    // bloque tienen dos digitos
                    codigoPegue = $"{nombreAbonado[0]}{apellidoAbonado[0]}#{bloque}-{casa}";
                }
                else if (bloque >= 100)
                {
                    // bloque tiene tres digitos
                    codigoPegue = $"{nombreAbonado[0]}{apellidoAbonado[0]}#{bloque}{casa}";
                }
            } else if(casa >= 100)
            {
                // casa tiene 3 digitos
                if (bloque < 10)
                {
                    // bloque solo tiene un digito
                    codigoPegue = $"{nombreAbonado[0]}{apellidoAbonado[0]}#{bloque}-{casa}";
                }
                else if (bloque >= 10 && bloque < 100)
                {
                    // bloque tiene dos digitos
                    codigoPegue = $"{nombreAbonado[0]}{apellidoAbonado[0]}#{bloque}{casa}";
                }
                else if (bloque >= 100)
                {
                    // bloque tiene tres digitos
                    codigoPegue = $"{nombreAbonado[0]}#{bloque}{casa}";
                }
            }

            return codigoPegue; 
        }

        /*
         * Funcion que registra los pegues de un abonado en especifico.
         */
        private void guardarPegue(
            string codigoPegue,
            // idAbonado
            int abonadoId,
            // idTipoPegue
            int tipoPegueId,
            // IdTipoEstado
            int estadoPegueId,
            // IdBloque
            int bloqueId,
            string casa,
            string nota = ""
            )
        {
            Pegue pegue = new Pegue
            {
                CodPegue = codigoPegue,
                IdAbonado = abonadoId,
                IdTipoPegue = tipoPegueId,
                IdEstadoPegue = estadoPegueId,
                IdBloque = bloqueId,
                NumCasa = casa,
                Nota = nota
            };
            DataAbonadoAccess.insertarPegue(pegue);
        }


        /*
         * Esta función se encarga de agregar un mes a pagar.
         */
        private string agregarMes() {
            string nameMes = "";
            int identMes = 0;     
            identMes = Convert.ToInt32(cboMes.SelectedValue);

            while (identMes != 0) {
                lblMesesPagados.Text = (lsbMeses.Items.Count + 1 > 0) ? $"Meses pagados: {lsbMeses.Items.Count + 1}" : "Meses pagados";
                nameMes = cboMes.Text;
                DataAbonadoAccess.excluirMes(cboMes, identMes);
                return nameMes;
            }
            return "";
        }

        /*
         * Función que se encarga de seleccionar siempre el primer mes
         */
        private void seleccionarPrimerMes()
        {
            const int ITEM_SELECCION = 0;
            cboMes.SelectedIndex = ITEM_SELECCION;
        }

        private void quitarMes()
        {
            int cantidadItems = 0;

            cantidadItems = lsbMeses.Items.Count;

            if(cantidadItems > 0)
            {
                lblMesesPagados.Text = (cantidadItems - 1 > 0) ? $"Meses pagados: {cantidadItems - 1}" : "Meses pagados";
                lsbMeses.Items.RemoveAt(cantidadItems - 1);
                DataAbonadoAccess.excluirMes(cboMes, cantidadItems - 1);
            } 
        }


        /* -------------------- Interfaz --------------------*/

        /*
         * funcion para resetear la info de abonado en el tab de pegues
         */
        public void resetearAbonadoEnPegue()
        {
            lblIdAbonado.Text = "";
            lblCantidadPegues.Text = "";
            txtNombreTab2.Text = "";
            txtApellidosTab2.Text = "";
            txtNumeroIdentidadTab2.Text = "";
        }

        /*
         * Funcion para resetear los controles del pegue
         */
        public void resetearPegue()
        {
            numBloque.Value = 0;
            numCasa.Value = 0;
            DataAbonadoAccess.obtenerTipoPegues(cboTipoPegue);
            DataAbonadoAccess.obtenerEstadoPegues(cboEstado);
            DataAbonadoAccess.obtenerMeses(cboMes);
            txtNota.Text = "";
            lsbMeses.Items.Clear();
        }

        /*
         * Función que muestra los componentes de:
         * meses estado
         * año estado
         */
        public void habilitarMesYearEstado(bool habilitar)
        {
            lblMesEstado.Enabled = habilitar;
            pnlMesEstado.Enabled = habilitar;
            cboMesEstado.Enabled = habilitar;

            lblYearEstado.Enabled = habilitar;
            pnlYearEstado.Enabled = habilitar;
            numYearEstado.Enabled = habilitar;
        }

        /*
         * Función que oculta o muestras lo controles:
         * dataGridView de bloque casa
         * título de ese dataGridView
         */
        public void mostrarTablaBloqueCasa(bool mostrar) {
            dgvBloqueCasa.Visible = mostrar;
            lblTablaBloqueCasa.Visible = mostrar;
        }


        /*
         Función que se encarga de pasar:
            -Nombre
            -Apellido
            -Numero de identidad
        desde la tab1 al tab2
         */
        private void pasarAbonadoAPegue(
                string numeroIdentidad,
                string nombres,
                string apellidos
            )
        {
            // Escribiendo el nombre del abonado en la tab 2
            txtNombreTab2.Text = nombres;
            txtApellidosTab2.Text = apellidos;
            txtNumeroIdentidadTab2.Text = numeroIdentidad;
        }


        /*
            Función que se encarga de:
            mostrar el pegue que es está anotando.
         */
        private void peguesActuales(
                int pegueActual,
                int cantidadPegues
            )
        {
            // Los pegues actuales que se estan escribiendo
            lblCantPegues.Text = $"Registrando pegue {pegueActual} de {cantidadPegues}";
        }

        /*
            Función que se encarga de mostrar seleccionado el panel de pagues.
         */
        private void seleccionarPanelPegues()
        {
            try
            {
                tabAbonados.SelectedIndex = 1;
                pnlPegues.BackColor = Color.FromArgb(1, 42, 70);
                pnlMenu.BackColor = Color.FromArgb(7, 67, 106);
                pnlListados.BackColor = Color.FromArgb(7, 67, 106);
                pnlAbonados.BackColor = Color.FromArgb(7, 67, 106);
                _drawborderAbonado = false;
                dgvBloqueCasa.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}. \n Intentelos mas tarde");
            }

        }

        /*
            Función que se encarga de mostrar seleccionado el panel de abonados.
         */
        private void seleccionarPanelAbonado()
        {
            tabAbonados.SelectedIndex = 0;
            pnlAbonados.BackColor = Color.FromArgb(1, 42, 70);
            pnlMenu.BackColor = Color.FromArgb(7, 67, 106);
            pnlListados.BackColor = Color.FromArgb(7, 67, 106);
            pnlPegues.BackColor = Color.FromArgb(7, 67, 106);
        }

        /*
            Función que se encarga de mostrar seleccionado el panel de listados.
         */
        private void seleccionarPanelListados()
        {
            //contarResultados();
            tabAbonados.SelectedIndex = 2;
            pnlListados.BackColor = Color.FromArgb(1, 42, 70);
            pnlMenu.BackColor = Color.FromArgb(7, 67, 106);
            pnlPegues.BackColor = Color.FromArgb(7, 67, 106);
            pnlAbonados.BackColor = Color.FromArgb(7, 67, 106);
            DataAbonadoAccess.cargarTablaListados(dgvListados, "Nombre");
            txtBusqueda.Focus();
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
            lblCancelarFiltro.Visible = false;
            habilitarControlesBusqueda(false);
            DataAbonadoAccess.cargarTablaListados(dgvListados);
            cboTipoBusqueda.SelectedIndex = 0;
            pgbPorcentajeAlmacenado.Visible = false;
            txtNombres.Focus();
            _drawborderAbonado = true;
            lblNombreCant.Visible = false;
            DataAbonadoAccess.obtenerTipoPegues(cboTipoPegue);
            DataAbonadoAccess.obtenerMeses(cboMes);
            DataAbonadoAccess.obtenerEstadoPegues(cboEstado);
            DataAbonadoAccess.obtenerMeses(cboMesEstado);
            txtNombres.Focus();
            btnGuardarPegue.Enabled = false;
            btnGuardarPegue.Visible = false;
            //contarResultados();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorAbonado.Clear();

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

        private void btnGuardarAbonado_Click(object sender, EventArgs e)
        {
            if (validarAbonados())
            {
                string numIdentidad = (mTxtNumIdentidad.Text == "    -    -")? "" : mTxtNumIdentidad.Text;
                string nombres = txtNombres.Text;
                string apellidos = txtApellidos.Text;
                numBloque.Focus();

                pasarAbonadoAPegue(numIdentidad, nombres, apellidos);
                peguesActuales(numeroPegueActual, cantPegues);

                numBloque.Focus();
                seleccionarPanelPegues();
                int idAbonado = guardarAbonado(numIdentidad, nombres, apellidos);
                lblCantidadPegues.Text = numCantPegues.Value.ToString();
                lblCantPegues.Text = $"Registrando pegue {numeroPegueActual + 1} de {numCantPegues.Value.ToString()}";
                lblIdAbonado.Text = idAbonado.ToString();
                resetearAbonado();
            }
        }

        private void btnSiguientePegue_Click(object sender, EventArgs e)
        {
            if (validarPegue())
            {
                insertarPegueEnDB();
               // string pegue = guardarPegue("36", "299", "Normal", 1, 5);
                Console.WriteLine("Hola mundo");
            }
        }

        private void btnAddMes_Click(object sender, EventArgs e)
        {
            string mes;
            mes = agregarMes();
            if(mes != "")
                lsbMeses.Items.Add(mes);
        }

        private void btnQuitarMes_Click(object sender, EventArgs e)
        {
            quitarMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionarPrimerMes();
        }

        private void pnlNombres_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, this.pnlNombres.ClientRectangle,
                                            nombresColor, 1, ButtonBorderStyle.Solid,
                                            nombresColor, 1, ButtonBorderStyle.Solid,
                                            nombresColor, 1, ButtonBorderStyle.Solid,
                                            nombresColor, 1, ButtonBorderStyle.Solid);

        }

        private void txtNombreTab2_TextChanged(object sender, EventArgs e)
        {
            errorAbonado.Clear();
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceCboEstado = cboEstado.SelectedIndex;
            int cantidadMesesPagados = (lblCantMesesPagados.Text == "Nombres") ? 0 : Convert.ToInt32(lblCantMesesPagados.Text);
            string[] meses = {
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            };

            if (indiceCboEstado > 0)
            {
                lblEstado.Visible = true;
                habilitarMesYearEstado(true);
                lblEstado.Text = $"{cboEstado.Text} desde: ";
                lsbMeses.Items.Clear();
                cboMes.Enabled = false;
                //lsbMeses.Items.Add("");
                lsbMeses.Enabled = false;
                btnAddMes.Visible = false;
                btnQuitarMes.Visible = false;
                DataAbonadoAccess.obtenerMeses(cboMesEstado);
            } else
            {
                if(Convert.ToInt32(cantidadMesesPagados) > 0)
                {
                    DataAbonadoAccess.obtenerMeses(cboMes);
                    lblEstado.Text = "";
                    lblEstado.Visible = false;
                    habilitarMesYearEstado(false);
                    cboMes.Enabled = true;
                    cboMes.SelectedIndex = 0;
                    lsbMeses.Items.Clear();
                    lsbMeses.Enabled = true;
                    btnAddMes.Visible = true;
                    btnQuitarMes.Visible = true;
                    lblMesesPagados.Text = "Meses pagados";
                    DataAbonadoAccess.excluirMes(cboMes, cantidadMesesPagados);
                    for (int i = 0; i < cantidadMesesPagados; i++)
                    {
                        lsbMeses.Items.Add(meses[i]);
                    }
                } else
                {
                    DataAbonadoAccess.obtenerMeses(cboMes);
                    lblEstado.Text = "";
                    lblEstado.Visible = false;
                    habilitarMesYearEstado(false);
                    cboMes.Enabled = true;
                    cboMes.SelectedIndex = 0;
                    lsbMeses.Items.Clear();
                    lsbMeses.Enabled = true;
                    btnAddMes.Visible = true;
                    btnQuitarMes.Visible = true;
                    lblMesesPagados.Text = "Meses pagados";
                }

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            resetearPegue();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            //contarResultados();
            DataAbonadoAccess.cargarTablaListados(dgvListados, cboTipoBusqueda.Text, txtBusqueda.Text);
        }

        private void cboTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTipoBusqueda.SelectedIndex == 3)
            {
                lblCancelarFiltro.Visible = true;
                habilitarCboBusqueda(true, cboTipoBusqueda.Text);
                txtBusqueda.Text = "";
                txtBusqueda.Focus();
            } else if (cboTipoBusqueda.SelectedIndex == 4)
            {
                lblCancelarFiltro.Visible = true;
                habilitarCboBusqueda(true, cboTipoBusqueda.Text);
                txtBusqueda.Text = "";
                txtBusqueda.Focus();
            } else
            {
                lblCancelarFiltro.Visible = true;
                habilitarControlesBusqueda(true);
                txtBusqueda.Text = "";
                txtBusqueda.Focus();
            }
        }

        private void cboBusquedas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAbonadoAccess.cargarTablaListados(dgvListados, cboTipoBusqueda.Text, (cboBusquedas.SelectedIndex + 1).ToString());
        }

        private void lblCancelarFiltro_Click(object sender, EventArgs e)
        {
            cboTipoBusqueda.SelectedIndex = 0;
            DataAbonadoAccess.cargarTablaListados(dgvListados, "Nombre");
            lblCancelarFiltro.Visible = false;
        }

        private void btnEditarAbonado_Click(object sender, EventArgs e)
        {

            
            moverAbonadosAEdicion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validarAbonados())
            {
                DialogResult r = MessageBox.Show("¿Desea cancelar la edición? \nLa información no será guardada", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    resetearAbonado();
                    if (btnGuardarAbonadoEditado.Visible)
                    {
                        btnGuardarAbonadoEditado.Visible = false;
                        btnGuardarAbonado.Enabled = true;
                        btnGuardarAbonado.Visible = true;
                    }
                    abrirMenu();
                }
            } else
            {
                abrirMenu();
            }        
                        
        }


        private void btnGuardarAbonadoEditado_Click(object sender, EventArgs e)
        {
            try
            {
                guardarAbonadoEditado();
                resetearAbonado();

                btnGuardarAbonadoEditado.Enabled = false;
                btnGuardarAbonadoEditado.Visible = false;

                btnGuardarAbonado.Enabled = true;
                btnGuardarAbonado.Visible = true;

                numCantPegues.Enabled = true;
            } catch(Exception ex)
            {
                MessageBox.Show($"Al parecer ocurrio un error, intentelo más tarde.\n {ex.Message}");
            }
        }

        private void btnEditarPegue_Click(object sender, EventArgs e)
        {
            moverPegueAEdicion();
        }

        private void btnGuardarPegue_Click(object sender, EventArgs e)
        {
            
                if (validarPegue())
                {
                    guardaPegueEditado();
                    resetearPegue();

                    btnGuardarPegue.Enabled = false;
                    btnGuardarPegue.Visible = false;

                    btnSiguientePegue.Enabled = true;
                    btnSiguientePegue.Visible = true;

                    lblCantPegues.Text = "Registrando pegue 0 de 0";
                    lblTitulo.Text = "Registrando pegue a:";
                }
            

        }

        private void numBloque_Enter(object sender, EventArgs e)
        {
            if(numBloque.Value == 0)
            {
                numBloque.ResetText();
            }
        }

        private void numCasa_Enter(object sender, EventArgs e)
        {
            if(numCasa.Value == 0)
            {
                numCasa.ResetText();
            }
        }
    }
}
