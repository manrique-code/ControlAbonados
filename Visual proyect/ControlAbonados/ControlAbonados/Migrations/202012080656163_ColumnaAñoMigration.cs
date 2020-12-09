namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnaAñoMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FechaEstadoPegues", "Año", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FechaEstadoPegues", "Año");
        }
    }
}
