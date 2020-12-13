using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        static string cnnStr = Properties.Settings.Default.cnnString.ToString();

        public static void actualizarFEP(
                int idFEP,
                int idEstadoPegue,
                int idMes,
                string year
            )
        {
            FechaEstadoPegue fep = (
                    from feps in ctx.FechaEstadoPegues
                    where feps.IdFechaEstadoPegue == idFEP
                    select feps
                ).SingleOrDefault();

            fep.IdEstadoPegue = idEstadoPegue;
            fep.IdMes = idMes;
            fep.Año = year;

            ctx.SaveChanges();
        }
        /*
         * eliminamos un fechaEstadoPegue debido a que el estado cambio
         */
        public static void eliminarFechaEstadoPegue(string codPegue)
        {
            FechaEstadoPegue fep = (
                    from feps in ctx.FechaEstadoPegues
                    where feps.CodPegue == codPegue
                    select feps             
                ).SingleOrDefault();
            ctx.FechaEstadoPegues.Remove(fep);
            ctx.SaveChanges();
        }

        /*
         * obtenemos el ultimo mes pagado en un control del pago 
         */
        public static int obtenerUltimoMesPagado(string codPegue)
        {
            var ultimoMes = (
                    from pago in ctx.ControlPago
                    where pago.CodPegue == codPegue
                    select new
                    {
                        pago.IdMes
                    }
                ).LastOrDefault();

            return ultimoMes.IdMes;
        }


        /*
         * 
         */
        public static string[] obtenerMesDeFechaControlPegue(string codPegue)
        {
            var m = (
                    from pegues in ctx.Pegue
                    join fep in ctx.FechaEstadoPegues
                    on pegues.CodPegue equals fep.CodPegue
                    join mes in ctx.Mes
                    on fep.IdMes equals mes.IdMes
                    where pegues.CodPegue == codPegue
                    select new
                    {
                        mes.IdMes,
                        mes.NombreMes,
                        fep.Año,
                        fep.IdEstadoPegue,
                        fep.IdFechaEstadoPegue
                    }
                ).SingleOrDefault();

            return new string[5] { m.IdMes.ToString(), m.NombreMes, m.Año, m.IdEstadoPegue.ToString(), m.IdFechaEstadoPegue.ToString() };
        }

        /*
         * obtener el id del estado del pegue a traves del nombre del estado del pegue
         */
        public static int obtenerEstadoPegueIDPorNombre(string estadoPegue)
        {
            var ep = ctx.EstadoPegue.SingleOrDefault(x => x.NombreEstadoPegue == estadoPegue);
            return ep.IdEstadoPegue;
        }

        /*
         * obtener el id del tipo pegue a través del nombre del tipo de pegue
         */
        public static int obtenerTipoPegueIDPorNombre(string tipoPegue)
        {
            var tp = ctx.TipoPegue.SingleOrDefault(x => x.NombreTipoPegue == tipoPegue);
            return tp.IdTipoPegue; 
        }

        /*
         * funcion para saber si un abonado ha pagado algun mes
         */
        public static bool tieneMesesPagados(string codPegue)
        {
            var pago = ctx.ControlPago.Count(x => x.CodPegue == codPegue);
            return (pago > 0);
        }

        /*
         * funcion para saber si un pegue tiene fechaestadopegue
         */
        public static bool existeFechaEstadoPegue(string codPegue)
        {
            var pegue = ctx.FechaEstadoPegues.Count(x => x.CodPegue == codPegue);
            return (pegue > 0);
        }

        /*
         * funcion para obtener el numero de identidad segun el id del abonaod
         */
        public static string obtenerNumIdentidadByID(int idAbonado)
        {
            var numId = (
                    from abonado in ctx.Abonado
                    where abonado.IdAbonado == idAbonado
                    select new
                    {
                        abonado.NumIdentidad
                    }
                ).SingleOrDefault();
            string numeroIdentidad = numId.NumIdentidad.ToString();
            return numeroIdentidad;
        }


        /*
         * funcion para obtener el codigo de pegue segun el bloque y casa
         */
        public static string obtenerCodigoPegueByPegue(
                string numBloque,
                string numCasa
            )
        {
            var codigoPegue = (
                    from pegue in ctx.Pegue
                    where pegue.Bloque.NumeroBloque == numBloque && pegue.NumCasa == numCasa
                    select new
                    {
                        pegue.CodPegue
                    }
                ).SingleOrDefault();
            return codigoPegue.CodPegue;
        }

        /*
         * funcion para actualizar el abonado
         */
        public static void actualizarAbonado(
                int IdAbonado,
                string nombres,
                string apellidos,
                string numeroIdentidad = ""
            )
        {
            Abonado abonado = (
                    from a in ctx.Abonado
                    where a.IdAbonado == IdAbonado
                    select a
                ).SingleOrDefault();

            abonado.Nombres = nombres;
            abonado.Apellidos = apellidos;
            abonado.NumIdentidad = numeroIdentidad;

            ctx.SaveChanges();
        }


        /*
         * funcion que actualiza el pegue
         */
        public static void actualizarPegue(
                string codigoPegue,
                string numCasa,
                int TipoPegue,
                int TipoEstaodPegueID,
                int IdBloque,
                string Nota
            )
        {
            Pegue pegue = (
                    from p in ctx.Pegue
                    where p.CodPegue == codigoPegue
                    select p
                ).SingleOrDefault();

            pegue.NumCasa = numCasa;
            pegue.IdTipoPegue = TipoPegue;
            pegue.IdEstadoPegue = TipoEstaodPegueID;
            pegue.IdBloque = IdBloque;
            pegue.Nota = Nota;


            ctx.SaveChanges();
        }

        /*
         * Funcion para imprimir toda la informacion de los abonados
         */
        public static void cargarTablaListados(DataGridView dgv, string tipoBusqueda = "", string buscar = "")
        {
            switch (tipoBusqueda)
            {
                /*case "":
                    // mandar todo lo de la consulta
                    using(SqlConnection cnn = new SqlConnection(cnnStr))
                    {
                        using(SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = new SqlCommand(@"select a.IdAbonado '#',
                                    upper(a.Nombres) Nombre,
                                    upper(a.Apellidos) Apellido,
                                    tp.NombreTipoPegue Pegue,
                                    b.NumeroBloque B,
                                    p.NumCasa C,
                                    ep.NombreEstadoPegue Estado,
	                                count(m.NombreMes) 'Meses Pagados',
                                    p.Nota
	                                from pegues p inner join ControlPagoes cp
	                                on p.CodPegue = cp.CodPegue
	                                inner join mes m
	                                on cp.IdMes = m.IdMes
	                                inner join Abonadoes a
	                                on p.IdAbonado = a.IdAbonado
	                                inner join Bloques b
	                                on p.IdBloque = b.IdBloque
	                                inner join TipoPegues tp
	                                on p.IdTipoPegue = tp.IdTipoPegue
	                                full join FechaEstadoPegues fep
	                                on p.CodPegue = fep.CodPegue
	                                inner join EstadoPegues ep
	                                on p.IdEstadoPegue = ep.IdEstadoPegue
                                group by upper(a.Nombres),
                                upper(a.Apellidos),
                                tp.NombreTipoPegue,
                                b.NumeroBloque,
                                p.NumCasa,
                                ep.NombreEstadoPegue,
                                a.IdAbonado,
                                p.Nota
                                union
                                select a.IdAbonado '#',
                                    upper(a.Nombres) Nombre,
                                    upper(a.Apellidos) Apellido,
                                    tp.NombreTipoPegue Pegue,
                                    b.NumeroBloque B,
                                    p.NumCasa C,
                                    ep.NombreEstadoPegue Estado,
	                                count(cp.IdMes) 'Meses Pagados',
                                    p.Nota
	                                from pegues p full join ControlPagoes cp
	                                on p.CodPegue = cp.CodPegue
	                                inner join Abonadoes a
	                                on p.IdAbonado = a.IdAbonado
	                                inner join Bloques b
	                                on p.IdBloque = b.IdBloque
	                                inner join TipoPegues tp
	                                on p.IdTipoPegue = tp.IdTipoPegue
	                                inner join EstadoPegues ep
	                                on p.IdEstadoPegue = ep.IdEstadoPegue
                                group by upper(a.Nombres),
                                    upper(a.Apellidos),
                                    tp.NombreTipoPegue,
                                    b.NumeroBloque,
                                    p.NumCasa,
                                    ep.NombreEstadoPegue,
                                    a.IdAbonado,
                                    p.Nota", cnn);

                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                dgv.DataSource = dt;
                            }

                        }
                    }
                    /*var datos = (
                            from pegue in ctx.Pegue
                            orderby pegue.Abonado.IdAbonado
                            join controlPago in ctx.ControlPago
                            on pegue.CodPegue equals controlPago.CodPegue
                            group pegue by new
                            {
                                pegue.Abonado.IdAbonado,
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
                                N = pegues.Key.IdAbonado,
                                Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                Bloque = pegues.Key.NumeroBloque,
                                Casa = pegues.Key.NumCasa,
                                Pegue = pegues.Key.NombreTipoPegue,
                                Estado = pegues.Key.NombreEstadoPegue
                            } 
                        ).ToList();

                    dgv.DataSource = datos;*/

                //break;
                case "Nombre":

                    using (SqlConnection cnn = new SqlConnection(cnnStr))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = new SqlCommand(@"
                                select pegue.#,
	                            pegue.Nombre,
	                            pegue.Apellido,
	                            pegue.Pegue,
	                            pegue.B,
	                            pegue.C,
	                            pegue.Estado,
	                            pegue.[Meses Pagados],
	                            pegue.Nota
	                            from
	                                (select a.IdAbonado '#',
	                                upper(a.Nombres) Nombre,
	                                upper(a.Apellidos) Apellido,
	                                tp.NombreTipoPegue Pegue,
	                                b.NumeroBloque B,
	                                p.NumCasa C,
	                                ep.NombreEstadoPegue Estado,
	                                count(m.NombreMes) 'Meses Pagados',
	                                p.Nota
	                                from pegues p inner join ControlPagoes cp
	                                on p.CodPegue = cp.CodPegue
	                                inner join mes m
	                                on cp.IdMes = m.IdMes
	                                inner join Abonadoes a
	                                on p.IdAbonado = a.IdAbonado
	                                inner join Bloques b
	                                on p.IdBloque = b.IdBloque
	                                inner join TipoPegues tp
	                                on p.IdTipoPegue = tp.IdTipoPegue
	                                full join FechaEstadoPegues fep
	                                on p.CodPegue = fep.CodPegue
	                                inner join EstadoPegues ep
	                                on p.IdEstadoPegue = ep.IdEstadoPegue
	                                group by 
	                                a.IdAbonado,
	                                upper(a.Nombres),
	                                upper(a.Apellidos),
	                                tp.NombreTipoPegue,
	                                b.NumeroBloque,
	                                p.NumCasa,
	                                ep.NombreEstadoPegue,
	                                p.Nota
                                union
	                                select a.IdAbonado '#',
	                                upper(a.Nombres) Nombre,
	                                upper(a.Apellidos) Apellido,
	                                tp.NombreTipoPegue Pegue,
	                                b.NumeroBloque B,
	                                p.NumCasa C,
	                                ep.NombreEstadoPegue Estado,
	                                count(cp.IdMes) 'Meses Pagados',
	                                p.Nota
	                                from pegues p full join ControlPagoes cp
	                                on p.CodPegue = cp.CodPegue
	                                inner join Abonadoes a
	                                on p.IdAbonado = a.IdAbonado
	                                inner join Bloques b
	                                on p.IdBloque = b.IdBloque
	                                inner join TipoPegues tp
	                                on p.IdTipoPegue = tp.IdTipoPegue
	                                inner join EstadoPegues ep
	                                on p.IdEstadoPegue = ep.IdEstadoPegue
	                                group by
	                                a.IdAbonado,
	                                upper(a.Nombres),
	                                upper(a.Apellidos),
	                                tp.NombreTipoPegue,
	                                b.NumeroBloque,
	                                p.NumCasa,
	                                ep.NombreEstadoPegue,
	                                p.Nota) pegue
	                            where pegue.Nombre like @nombre + '%'", cnn);
                            da.SelectCommand.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = buscar;

                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                dgv.DataSource = dt;
                            }

                        }
                    }

                    /*var nombre = (
                            from pegue in ctx.Pegue
                            join controlPago in ctx.ControlPago
                            on pegue.CodPegue equals controlPago.CodPegue
                            where pegue.Abonado.Nombres.StartsWith(buscar)
                            orderby pegue.Abonado.IdAbonado
                            group pegue by new
                            {
                                pegue.Abonado.IdAbonado,
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
                                N = pegues.Key.IdAbonado,
                                Identidad = pegues.Key.NumIdentidad,
                                Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                Bloque = pegues.Key.NumeroBloque,
                                Casa = pegues.Key.NumCasa,
                                Pegue = pegues.Key.NombreTipoPegue,
                                MesesPagados = pegues.Count()
                            }
                        ).ToList();
                    dgv.DataSource = nombre;*/
                    break;
                case "Bloque":

                    using (SqlConnection cnn = new SqlConnection(cnnStr))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = new SqlCommand(@"
select pegue.#,
pegue.Nombre,
pegue.Apellido,
pegue.Pegue,
pegue.B,
pegue.C,
pegue.Estado,
pegue.[Meses Pagados],
pegue.Nota
from
(select a.IdAbonado '#',
upper(a.Nombres) Nombre,
upper(a.Apellidos) Apellido,
tp.NombreTipoPegue Pegue,
b.NumeroBloque B,
p.NumCasa C,
ep.NombreEstadoPegue Estado,
count(m.NombreMes) 'Meses Pagados',
p.Nota
from pegues p inner join ControlPagoes cp
on p.CodPegue = cp.CodPegue
inner join mes m
on cp.IdMes = m.IdMes
inner join Abonadoes a
on p.IdAbonado = a.IdAbonado
inner join Bloques b
on p.IdBloque = b.IdBloque
inner join TipoPegues tp
on p.IdTipoPegue = tp.IdTipoPegue
full join FechaEstadoPegues fep
on p.CodPegue = fep.CodPegue
inner join EstadoPegues ep
on p.IdEstadoPegue = ep.IdEstadoPegue
group by 
a.IdAbonado,
upper(a.Nombres),
upper(a.Apellidos),
tp.NombreTipoPegue,
b.NumeroBloque,
p.NumCasa,
ep.NombreEstadoPegue,
p.Nota
union
select a.IdAbonado '#',
upper(a.Nombres) Nombre,
upper(a.Apellidos) Apellido,
tp.NombreTipoPegue Pegue,
b.NumeroBloque B,
p.NumCasa C,
ep.NombreEstadoPegue Estado,
count(cp.IdMes) 'Meses Pagados',
p.Nota
from pegues p full join ControlPagoes cp
on p.CodPegue = cp.CodPegue
inner join Abonadoes a
on p.IdAbonado = a.IdAbonado
inner join Bloques b
on p.IdBloque = b.IdBloque
inner join TipoPegues tp
on p.IdTipoPegue = tp.IdTipoPegue
inner join EstadoPegues ep
on p.IdEstadoPegue = ep.IdEstadoPegue
group by
a.IdAbonado,
upper(a.Nombres),
upper(a.Apellidos),
tp.NombreTipoPegue,
b.NumeroBloque,
p.NumCasa,
ep.NombreEstadoPegue,
p.Nota) pegue
where pegue.B like @nombre + '%'", cnn);
                            da.SelectCommand.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = buscar;

                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                dgv.DataSource = dt;
                            }

                            /*var bloque = (
                                    from pegue in ctx.Pegue
                                    join controlPago in ctx.ControlPago
                                    on pegue.CodPegue equals controlPago.CodPegue
                                    where pegue.Bloque.NumeroBloque.StartsWith(buscar)
                                    group pegue by new
                                    {
                                        pegue.Abonado.IdAbonado,
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
                                        N = pegues.Key.IdAbonado,
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
                                        pegue.Abonado.IdAbonado,
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
                                        N = pegues.Key.IdAbonado,
                                        Identidad = pegues.Key.NumIdentidad,
                                        Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                        Bloque = pegues.Key.NumeroBloque,
                                        Casa = pegues.Key.NumCasa,
                                        Pegue = pegues.Key.NombreTipoPegue,
                                        MesesPagados = pegues.Count()
                                    }
                                ).ToList();
                            dgv.DataSource = casa;*/
                        }
                    }
                    break;
                case "Mes":


                    using (SqlConnection cnn = new SqlConnection(cnnStr))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = new SqlCommand(@"
select pegue.#,
pegue.Nombre,
pegue.Apellido,
pegue.Pegue,
pegue.B,
pegue.C,
pegue.Estado,
pegue.[Meses Pagados],
pegue.Nota
from
(select a.IdAbonado '#',
upper(a.Nombres) Nombre,
upper(a.Apellidos) Apellido,
tp.NombreTipoPegue Pegue,
b.NumeroBloque B,
p.NumCasa C,
ep.NombreEstadoPegue Estado,
count(m.NombreMes) 'Meses Pagados',
p.Nota
from pegues p inner join ControlPagoes cp
on p.CodPegue = cp.CodPegue
inner join mes m
on cp.IdMes = m.IdMes
inner join Abonadoes a
on p.IdAbonado = a.IdAbonado
inner join Bloques b
on p.IdBloque = b.IdBloque
inner join TipoPegues tp
on p.IdTipoPegue = tp.IdTipoPegue
full join FechaEstadoPegues fep
on p.CodPegue = fep.CodPegue
inner join EstadoPegues ep
on p.IdEstadoPegue = ep.IdEstadoPegue
group by 
a.IdAbonado,
upper(a.Nombres),
upper(a.Apellidos),
tp.NombreTipoPegue,
b.NumeroBloque,
p.NumCasa,
ep.NombreEstadoPegue,
p.Nota
union
select a.IdAbonado '#',
upper(a.Nombres) Nombre,
upper(a.Apellidos) Apellido,
tp.NombreTipoPegue Pegue,
b.NumeroBloque B,
p.NumCasa C,
ep.NombreEstadoPegue Estado,
count(cp.IdMes) 'Meses Pagados',
p.Nota
from pegues p full join ControlPagoes cp
on p.CodPegue = cp.CodPegue
inner join Abonadoes a
on p.IdAbonado = a.IdAbonado
inner join Bloques b
on p.IdBloque = b.IdBloque
inner join TipoPegues tp
on p.IdTipoPegue = tp.IdTipoPegue
inner join EstadoPegues ep
on p.IdEstadoPegue = ep.IdEstadoPegue
group by
a.IdAbonado,
upper(a.Nombres),
upper(a.Apellidos),
tp.NombreTipoPegue,
b.NumeroBloque,
p.NumCasa,
ep.NombreEstadoPegue,
p.Nota) pegue
where pegue.[Meses Pagados] like @nombre + '%'", cnn);
                            da.SelectCommand.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = buscar;

                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                dgv.DataSource = dt;
                            }
                        }
                    }

                            /*var mes = (
                                    from pegue in ctx.Pegue
                                    join controlPago in ctx.ControlPago
                                    on pegue.CodPegue equals controlPago.CodPegue
                                    where controlPago.Mes.NombreMes.StartsWith(buscar)
                                    group pegue by new
                                    {
                                        pegue.Abonado.IdAbonado,
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
                                        N = pegues.Key.IdAbonado,
                                        Identidad = pegues.Key.NumIdentidad,
                                        Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                        Bloque = pegues.Key.NumeroBloque,
                                        Casa = pegues.Key.NumCasa,
                                        Pegue = pegues.Key.NombreTipoPegue,
                                        Estado = "Va al día"
                                    }
                                ).ToList();
                            dgv.DataSource = mes;*/
                            break;
                        case "Estado":

                    using (SqlConnection cnn = new SqlConnection(cnnStr))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = new SqlCommand(@"
select pegue.#,
pegue.Nombre,
pegue.Apellido,
pegue.Pegue,
pegue.B,
pegue.C,
pegue.Estado,
pegue.[Meses Pagados],
pegue.Nota
from
(select a.IdAbonado '#',
upper(a.Nombres) Nombre,
upper(a.Apellidos) Apellido,
tp.NombreTipoPegue Pegue,
b.NumeroBloque B,
p.NumCasa C,
ep.NombreEstadoPegue Estado,
ep.IdEstadoPegue,
count(m.NombreMes) 'Meses Pagados',
p.Nota
from pegues p inner join ControlPagoes cp
on p.CodPegue = cp.CodPegue
inner join mes m
on cp.IdMes = m.IdMes
inner join Abonadoes a
on p.IdAbonado = a.IdAbonado
inner join Bloques b
on p.IdBloque = b.IdBloque
inner join TipoPegues tp
on p.IdTipoPegue = tp.IdTipoPegue
full join FechaEstadoPegues fep
on p.CodPegue = fep.CodPegue
inner join EstadoPegues ep
on p.IdEstadoPegue = ep.IdEstadoPegue
group by 
a.IdAbonado,
upper(a.Nombres),
upper(a.Apellidos),
tp.NombreTipoPegue,
b.NumeroBloque,
p.NumCasa,
ep.IdEstadoPegue,
ep.NombreEstadoPegue,
p.Nota
union
select a.IdAbonado '#',
upper(a.Nombres) Nombre,
upper(a.Apellidos) Apellido,
tp.NombreTipoPegue Pegue,
b.NumeroBloque B,
p.NumCasa C,
ep.NombreEstadoPegue Estado,
ep.IdEstadoPegue,
count(cp.IdMes) 'Meses Pagados',
p.Nota
from pegues p full join ControlPagoes cp
on p.CodPegue = cp.CodPegue
inner join Abonadoes a
on p.IdAbonado = a.IdAbonado
inner join Bloques b
on p.IdBloque = b.IdBloque
inner join TipoPegues tp
on p.IdTipoPegue = tp.IdTipoPegue
inner join EstadoPegues ep
on p.IdEstadoPegue = ep.IdEstadoPegue
group by
a.IdAbonado,
upper(a.Nombres),
upper(a.Apellidos),
tp.NombreTipoPegue,
b.NumeroBloque,
p.NumCasa,
ep.NombreEstadoPegue,
ep.IdEstadoPegue,
p.Nota) pegue
where pegue.IdEstadoPegue like @nombre + '%'", cnn);
                            da.SelectCommand.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = buscar;

                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                dgv.DataSource = dt;
                            }
                        }
                    }


                /*var estado = (
                         from pegue in ctx.Pegue
                         join controlPago in ctx.ControlPago
                         on pegue.CodPegue equals controlPago.CodPegue
                         where pegue.EstadoPegue.NombreEstadoPegue.StartsWith(buscar)
                         group pegue by new
                         {
                             pegue.Abonado.IdAbonado,
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
                             N = pegues.Key.IdAbonado,
                             Identidad = pegues.Key.NumIdentidad,
                             Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                             Bloque = pegues.Key.NumeroBloque,
                             Casa = pegues.Key.NumCasa,
                             Pegue = pegues.Key.NombreTipoPegue,
                             Estado = pegues.Key.NombreEstadoPegue,
                             MesesPagados = (pegues.Key.NombreEstadoPegue == "Activo") ? pegues.Count().ToString() : "No ha pagado debido a que está: " + pegues.Key.NombreEstadoPegue.ToLower()
                         }
                     ).ToList();
                 dgv.DataSource = estado;*/
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
        public static void obtenerEstadoPegues(ComboBox cbo, int saltarse = 0)
        {
            cbo.DataSource = (
                    from ep in ctx.EstadoPegue
                    orderby ep.IdEstadoPegue
                    select new { ep.IdEstadoPegue, ep.NombreEstadoPegue }
                )
                .Skip(saltarse)
                .ToList();
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
                ).Take(12).ToList();
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
