namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControlPagoIdAddMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ControlPago", "CodPegue", c => c.String(maxLength: 8));
            AddColumn("dbo.ControlPago", "IdMes", c => c.Int(nullable: false));
            CreateIndex("dbo.ControlPago", "CodPegue");
            CreateIndex("dbo.ControlPago", "IdMes");
            AddForeignKey("dbo.ControlPago", "IdMes", "dbo.Mes", "IdMes", cascadeDelete: true);
            AddForeignKey("dbo.ControlPago", "CodPegue", "dbo.Pegue", "CodPegue");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ControlPago", "CodPegue", "dbo.Pegue");
            DropForeignKey("dbo.ControlPago", "IdMes", "dbo.Mes");
            DropIndex("dbo.ControlPago", new[] { "IdMes" });
            DropIndex("dbo.ControlPago", new[] { "CodPegue" });
            DropColumn("dbo.ControlPago", "IdMes");
            DropColumn("dbo.ControlPago", "CodPegue");
        }
    }
}
