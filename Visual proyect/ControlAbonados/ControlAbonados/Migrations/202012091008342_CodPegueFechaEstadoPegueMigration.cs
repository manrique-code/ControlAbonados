namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodPegueFechaEstadoPegueMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FechaEstadoPegues", "CodPegue", c => c.String(maxLength: 8));
            CreateIndex("dbo.FechaEstadoPegues", "CodPegue");
            AddForeignKey("dbo.FechaEstadoPegues", "CodPegue", "dbo.Pegues", "CodPegue");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FechaEstadoPegues", "CodPegue", "dbo.Pegues");
            DropIndex("dbo.FechaEstadoPegues", new[] { "CodPegue" });
            DropColumn("dbo.FechaEstadoPegues", "CodPegue");
        }
    }
}
