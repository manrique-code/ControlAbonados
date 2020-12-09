namespace ControlAbonados.Models 
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ControlAbonados.Models;
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=ControlAbonados.Properties.Settings.cnnString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        public DbSet<Abonado> Abonado { get; set; }

        public DbSet<Bloque> Bloque { get; set; }

        public DbSet<TipoPegue> TipoPegue { get; set; }

        public DbSet<Mes> Mes { get; set; }

        public DbSet<EstadoPegue> EstadoPegue { get; set; }

       public DbSet<Pegue> Pegue { get; set; }

       public DbSet<ControlPago> ControlPago { get; set; }

       public DbSet<FechaEstadoPegue> FechaEstadoPegues { get; set; }

    }
}
