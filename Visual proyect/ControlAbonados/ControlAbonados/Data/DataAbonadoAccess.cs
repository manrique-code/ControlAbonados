using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlAbonados.Models;

namespace ControlAbonados.Data
{
    public class DataAbonadoAccess
    {
        static DataContext ctx = new DataContext();

        /*
         * Funcion para imprimir toda la informacion de los abonados
         */
        public static void cargarTablaListados(DataGridView dgv, string tipoBusqueda = "", string buscar = "")
        {
            switch (tipoBusqueda)
            {
                case "":
                    // mandar todo lo de la consulta
                    var datos = (
                            from pegue in ctx.Pegue
                            join controlPago in ctx.ControlPago
                            on pegue.CodPegue equals controlPago.CodPegue
                            group pegue by new
                            {
                                pegue.Abonado.NumIdentidad,
                                pegue.Abonado.Nombres,
                                pegue.Abonado.Apellidos,
                                pegue.Bloque.NumeroBloque,
                                pegue.NumCasa,
                                pegue.CodPegue,
                                pegue.TipoPegue.NombreTipoPegue
                            } into pegues
                            select new
                            {
                                Identidad = pegues.Key.NumIdentidad,
                                Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                Bloque = pegues.Key.NumeroBloque,
                                Casa = pegues.Key.NumCasa,
                                Pegue = pegues.Key.NombreTipoPegue,
                                MesesPagados = pegues.Count()
                            }
                        ).ToList();

                    dgv.DataSource = datos;

                    break;
                case "Nombre":
                    var nombre = (
                            from pegue in ctx.Pegue
                            join controlPago in ctx.ControlPago
                            on pegue.CodPegue equals controlPago.CodPegue
                            where pegue.Abonado.Nombres.StartsWith(buscar)
                            group pegue by new
                            {
                                pegue.Abonado.NumIdentidad,
                                pegue.Abonado.Nombres,
                                pegue.Abonado.Apellidos,
                                pegue.Bloque.NumeroBloque,
                                pegue.NumCasa,
                                pegue.CodPegue,
                                pegue.TipoPegue.NombreTipoPegue
                            } into pegues
                            select new
                            {
                                Identidad = pegues.Key.NumIdentidad,
                                Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                Bloque = pegues.Key.NumeroBloque,
                                Casa = pegues.Key.NumCasa,
                                Pegue = pegues.Key.NombreTipoPegue,
                                MesesPagados = pegues.Count()
                            }
                        ).ToList();
                    dgv.DataSource = nombre;
                    break;
                case "Bloque":
                    var bloque = (
                            from pegue in ctx.Pegue
                            join controlPago in ctx.ControlPago
                            on pegue.CodPegue equals controlPago.CodPegue
                            where pegue.Bloque.NumeroBloque.StartsWith(buscar)
                            group pegue by new
                            {
                                pegue.Abonado.NumIdentidad,
                                pegue.Abonado.Nombres,
                                pegue.Abonado.Apellidos,
                                pegue.Bloque.NumeroBloque,
                                pegue.NumCasa,
                                pegue.CodPegue,
                                pegue.TipoPegue.NombreTipoPegue
                            } into pegues
                            select new
                            {
                                Identidad = pegues.Key.NumIdentidad,
                                Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                Bloque = pegues.Key.NumeroBloque,
                                Casa = pegues.Key.NumCasa,
                                Pegue = pegues.Key.NombreTipoPegue,
                                MesesPagados = pegues.Count()
                            }
                        ).ToList();
                    dgv.DataSource = bloque;
                    break;
                case "Casa":
                    var casa = (
                            from pegue in ctx.Pegue
                            join controlPago in ctx.ControlPago
                            on pegue.CodPegue equals controlPago.CodPegue
                            where pegue.NumCasa.StartsWith(buscar)
                            group pegue by new
                            {
                                pegue.Abonado.NumIdentidad,
                                pegue.Abonado.Nombres,
                                pegue.Abonado.Apellidos,
                                pegue.Bloque.NumeroBloque,
                                pegue.NumCasa,
                                pegue.CodPegue,
                                pegue.TipoPegue.NombreTipoPegue
                            } into pegues
                            select new
                            {
                                Identidad = pegues.Key.NumIdentidad,
                                Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                Bloque = pegues.Key.NumeroBloque,
                                Casa = pegues.Key.NumCasa,
                                Pegue = pegues.Key.NombreTipoPegue,
                                MesesPagados = pegues.Count()
                            }
                        ).ToList();
                    dgv.DataSource = casa;
                    break;
                case "Mes":
                    var mes = (
                            from pegue in ctx.Pegue
                            join controlPago in ctx.ControlPago
                            on pegue.CodPegue equals controlPago.CodPegue
                            where controlPago.Mes.NombreMes.StartsWith(buscar)
                            group pegue by new
                            {
                                pegue.Abonado.NumIdentidad,
                                pegue.Abonado.Nombres,
                                pegue.Abonado.Apellidos,
                                pegue.Bloque.NumeroBloque,
                                pegue.NumCasa,
                                pegue.CodPegue,
                                pegue.TipoPegue.NombreTipoPegue
                            } into pegues
                            select new
                            {
                                Identidad = pegues.Key.NumIdentidad,
                                Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                Bloque = pegues.Key.NumeroBloque,
                                Casa = pegues.Key.NumCasa,
                                Pegue = pegues.Key.NombreTipoPegue,
                                Estado = "Va al día"
                            }
                        ).ToList();
                    dgv.DataSource = mes;
                    break;
                case "Estado":
                    var estado = (
                            from pegue in ctx.Pegue
                            join controlPago in ctx.ControlPago
                            on pegue.CodPegue equals controlPago.CodPegue
                            where pegue.EstadoPegue.NombreEstadoPegue.StartsWith(buscar)
                            group pegue by new
                            {
                                pegue.Abonado.NumIdentidad,
                                pegue.Abonado.Nombres,
                                pegue.Abonado.Apellidos,
                                pegue.Bloque.NumeroBloque,
                                pegue.NumCasa,
                                pegue.CodPegue,
                                pegue.TipoPegue.NombreTipoPegue,
                                pegue.EstadoPegue.NombreEstadoPegue
                            } into pegues
                            select new
                            {
                                Identidad = pegues.Key.NumIdentidad,
                                Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                Bloque = pegues.Key.NumeroBloque,
                                Casa = pegues.Key.NumCasa,
                                Pegue = pegues.Key.NombreTipoPegue,
                                Estado = pegues.Key.NombreEstadoPegue,
                                MesesPagados = (pegues.Key.NombreEstadoPegue == "Activo") ? pegues.Count().ToString() : "No ha pagado debido a que está: " + pegues.Key.NombreEstadoPegue.ToLower()
                            }
                        ).ToList();
                    dgv.DataSource = estado;
                    break;
                default:
                    break;
            }

        }

        /*
         * funcion para cargar la tabla de los pegues
         */
        public static void cargarTablaPegues(DataGridView dgv, int idAbonado) {
            dgv.DataSource = (
                    from pegue in ctx.Pegue
                    where pegue.IdAbonado == idAbonado
                    select new
                    {
                        pegue.Bloque.NumeroBloque,
                        pegue.NumCasa
                    }
                ).ToList();
        }

        /*
         * funcion para guardar los controles de pago
         */
        public static void insertarControlPago(ControlPago controlPago)
        {
            ctx.ControlPago.Add(controlPago);
            ctx.SaveChanges();
        }

        /*
         * funcion para agregar
         */
        public static void insertarFechaEstadoPegue(FechaEstadoPegue fechaEstadoPegue)
        {
            ctx.FechaEstadoPegues.Add(fechaEstadoPegue);
            ctx.SaveChanges();
        }

        /*
         * Funcion para obtener el id de un bloque a través del nombre del bloque
         */
        public static bool existeBloque(int numBloque)
        {
            return numBloque <= ctx.Bloque.Count();
        }

        /*
         * Funcion para guardar un pegue
         */
        public static void insertarPegue(Pegue pegue)
        {
            ctx.Pegue.Add(pegue);
            ctx.SaveChanges();
        }

        /*
         * Funcion para obtener todos los estados posibles del pegue
         */
        public static void obtenerEstadoPegues(ComboBox cbo)
        {
            cbo.DataSource = (
                    from ep in ctx.EstadoPegue
                    orderby ep.IdEstadoPegue
                    select new { ep.IdEstadoPegue, ep.NombreEstadoPegue }
                ).ToList();
            cbo.DisplayMember = "NombreEstadoPegue";
            cbo.ValueMember = "IdEstadoPegue";
        }

        /*
         * Función para excluir un mes de la consulta
         */
        public static void excluirMes(ComboBox cbo, int cantMesesExcluidos)
        {
            cbo.DataSource = (
                    from mes in ctx.Mes
                    orderby mes.IdMes
                    select new { mes.IdMes, mes.NombreMes }
                )
                .Skip(cantMesesExcluidos)
                .ToList();
            cbo.DisplayMember = "NombreMes";
            cbo.ValueMember = "IdMes";
        }

        /*
         * Función para llenar el combobox de los meses
         */
        public static void obtenerMeses(ComboBox cbo)
        {
            cbo.DataSource = (
                    from mes in ctx.Mes
                    orderby mes.IdMes
                    select new { mes.IdMes, mes.NombreMes}
                ).ToList();
            cbo.DisplayMember = "NombreMes";
            cbo.ValueMember = "IdMes";
        }


        /*
            Función para llenar un combobox para mostrar valores
         */
        public static void obtenerTipoPegues(ComboBox cbo)
        {
            cbo.DataSource = (from tp in ctx.TipoPegue
                              orderby tp.IdTipoPegue
                              select new { tp.IdTipoPegue, tp.NombreTipoPegue}).ToList();
            cbo.DisplayMember = "NombreTipoPegue";
            cbo.ValueMember = "IdTipoPegue";
        }

        /*
            Función para insertar un abonado en la junta de agua.
         */
        public static int insertarAbonado(Abonado abonado)
        {
            ctx.Abonado.Add(abonado);
            ctx.SaveChanges();

            return abonado.IdAbonado;
        }
    }
}
