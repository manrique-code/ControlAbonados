namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotasPegueMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pegues", "Nota", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pegues", "Nota");
        }
    }
}
