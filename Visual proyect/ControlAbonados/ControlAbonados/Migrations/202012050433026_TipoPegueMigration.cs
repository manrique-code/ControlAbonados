namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoPegueMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoPegue",
                c => new
                    {
                        IdTipoPegue = c.Int(nullable: false, identity: true),
                        NombreTipoPegue = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IdTipoPegue)
                .Index(t => t.NombreTipoPegue, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TipoPegues", new[] { "NombreTipoPegue" });
            DropTable("dbo.TipoPegues");
        }
    }
}
