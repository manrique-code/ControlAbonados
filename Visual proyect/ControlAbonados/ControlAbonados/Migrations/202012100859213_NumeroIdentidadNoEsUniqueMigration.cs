namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumeroIdentidadNoEsUniqueMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Abonadoes", new[] { "NumIdentidad" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Abonadoes", "NumIdentidad", unique: true);
        }
    }
}
