namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControlPagoMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ControlPago",
                c => new
                    {
                        IdControlPago = c.Int(nullable: false, identity: true),
                        EstaPagado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdControlPago);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ControlPagoes");
        }
    }
}
