namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PegueIdAbonado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pegue",
                c => new
                    {
                        CodPegue = c.String(nullable: false, maxLength: 8),
                        IdAbonado = c.Int(nullable: false),
                        NumCasa = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.CodPegue)
                .Index(t => t.IdAbonado);

            AddForeignKey("dbo.Pegue", "IdAbonado", "dbo.Abonado", "IdAbonado");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pegue", "IdAbonado", "dbo.Abonado");
            DropIndex("dbo.Pegue", new[] { "IdAbonado" });
            DropTable("dbo.Pegue");
        }
    }
}
