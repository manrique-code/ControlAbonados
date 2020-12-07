using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlAbonados.Models;

namespace ControlAbonados.Data
{
    class DataAbonadoAccess
    {
        static DataContext ctx = new DataContext();

        public static void insertarAbonado(Abonado abonado)
        {
            ctx.Abonado.Add(abonado);
            ctx.SaveChanges();
        }
    }
}
