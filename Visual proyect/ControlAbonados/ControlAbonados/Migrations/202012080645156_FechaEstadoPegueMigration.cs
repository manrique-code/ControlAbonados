namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechaEstadoPegueMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FechaEstadoPegues",
                c => new
                    {
                        IdFechaEstadoPegue = c.Int(nullable: false, identity: true),
                        IdEstadoPegue = c.Int(nullable: false),
                        IdAño = c.Int(nullable: false),
                        IdMes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFechaEstadoPegue)
                .ForeignKey("dbo.Año", t => t.IdAño, cascadeDelete: true)
                .ForeignKey("dbo.EstadoPegues", t => t.IdEstadoPegue, cascadeDelete: true)
                .ForeignKey("dbo.Mes", t => t.IdMes, cascadeDelete: true)
                .Index(t => t.IdEstadoPegue)
                .Index(t => t.IdAño)
                .Index(t => t.IdMes);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FechaEstadoPegues", "IdMes", "dbo.Mes");
            DropForeignKey("dbo.FechaEstadoPegues", "IdEstadoPegue", "dbo.EstadoPegues");
            DropForeignKey("dbo.FechaEstadoPegues", "IdAño", "dbo.Año");
            DropIndex("dbo.FechaEstadoPegues", new[] { "IdMes" });
            DropIndex("dbo.FechaEstadoPegues", new[] { "IdAño" });
            DropIndex("dbo.FechaEstadoPegues", new[] { "IdEstadoPegue" });
            DropTable("dbo.FechaEstadoPegues");
        }
    }
}
