namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarAñoFechaEstadoPegueMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FechaEstadoPegues", "IdAño", "dbo.Año");
            DropIndex("dbo.FechaEstadoPegues", new[] { "IdAño" });
            DropColumn("dbo.FechaEstadoPegues", "IdAño");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FechaEstadoPegues", "IdAño", c => c.Int(nullable: false));
            CreateIndex("dbo.FechaEstadoPegues", "IdAño");
            AddForeignKey("dbo.FechaEstadoPegues", "IdAño", "dbo.Año", "IdAño", cascadeDelete: true);
        }
    }
}
