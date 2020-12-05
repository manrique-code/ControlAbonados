namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadoPegueMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstadoPegue",
                c => new
                    {
                        IdEstadoPegue = c.Int(nullable: false, identity: true),
                        IdAño = c.Int(nullable: false),
                        IdMes = c.Int(nullable: false),
                        NombreEstadoPegue = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.IdEstadoPegue)
                .ForeignKey("dbo.Año", t => t.IdAño, cascadeDelete: true)
                .ForeignKey("dbo.Mes", t => t.IdMes, cascadeDelete: true)
                .Index(t => t.IdAño)
                .Index(t => t.IdMes)
                .Index(t => t.NombreEstadoPegue, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstadoPegues", "IdMes", "dbo.Mes");
            DropForeignKey("dbo.EstadoPegues", "IdAño", "dbo.Año");
            DropIndex("dbo.EstadoPegues", new[] { "NombreEstadoPegue" });
            DropIndex("dbo.EstadoPegues", new[] { "IdMes" });
            DropIndex("dbo.EstadoPegues", new[] { "IdAño" });
            DropTable("dbo.EstadoPegues");
        }
    }
}
