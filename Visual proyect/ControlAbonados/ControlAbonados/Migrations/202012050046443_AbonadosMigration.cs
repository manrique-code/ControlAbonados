namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbonadosMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonado",
                c => new
                    {
                        IdAbonado = c.Int(nullable: false, identity: true),
                        NumIdentidad = c.String(maxLength: 15),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.IdAbonado)
                .Index(t => t.NumIdentidad, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Abonadoes", new[] { "NumIdentidad" });
            DropTable("dbo.Abonadoes");
        }
    }
}
