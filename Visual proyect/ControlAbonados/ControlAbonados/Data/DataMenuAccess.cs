using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ControlAbonados.Models;

namespace ControlAbonados.Data
{
    class DataMenuAccess
    {
        static DataContext ctx = new DataContext();

        public static int cantidadAbonadosPorEstado(string estado)
        {
            var cantidad = ctx.Pegue.Count(x => x.EstadoPegue.NombreEstadoPegue == estado);

            return cantidad;
        }

        public static int cantidadTotalAbonados()
        {
            var cantidad = ctx.Pegue.Count();
            return cantidad;
        }

        public static int cantidadAbonadosPorTipo(string tipo)
        {
            var cantidad = ctx.Pegue.Count(x => x.TipoPegue.NombreTipoPegue == tipo);
            return cantidad;
        }
    }
}
