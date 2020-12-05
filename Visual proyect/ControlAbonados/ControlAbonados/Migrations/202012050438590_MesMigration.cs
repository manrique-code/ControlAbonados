namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MesMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mes",
                c => new
                    {
                        IdMes = c.Int(nullable: false, identity: true),
                        NombreMes = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.IdMes)
                .Index(t => t.NombreMes, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Mes", new[] { "NombreMes" });
            DropTable("dbo.Mes");
        }
    }
}
