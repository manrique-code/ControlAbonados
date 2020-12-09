namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuitarForeignKeysEstadoPegueMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EstadoPegues", "IdAño", "dbo.Año");
            DropForeignKey("dbo.EstadoPegues", "IdMes", "dbo.Mes");
            DropIndex("dbo.EstadoPegues", new[] { "IdAño" });
            DropIndex("dbo.EstadoPegues", new[] { "IdMes" });
            DropColumn("dbo.EstadoPegues", "IdAño");
            DropColumn("dbo.EstadoPegues", "IdMes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EstadoPegues", "IdMes", c => c.Int(nullable: false));
            AddColumn("dbo.EstadoPegues", "IdAño", c => c.Int(nullable: false));
            CreateIndex("dbo.EstadoPegues", "IdMes");
            CreateIndex("dbo.EstadoPegues", "IdAño");
            AddForeignKey("dbo.EstadoPegues", "IdMes", "dbo.Mes", "IdMes", cascadeDelete: true);
            AddForeignKey("dbo.EstadoPegues", "IdAño", "dbo.Año", "IdAño", cascadeDelete: true);
        }
    }
}
