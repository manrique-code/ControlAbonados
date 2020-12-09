namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechaNacElimMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abonadoes", "FechaNacimiento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abonadoes", "FechaNacimiento", c => c.DateTime(nullable: false));
        }
    }
}
