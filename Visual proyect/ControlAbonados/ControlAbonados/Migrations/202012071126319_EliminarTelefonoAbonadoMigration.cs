namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarTelefonoAbonadoMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abonado", "Telefono");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abonado", "Telefono", c => c.String(nullable: false, maxLength: 9));
        }
    }
}
