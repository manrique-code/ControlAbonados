namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AñoMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Año",
                c => new
                    {
                        IdAño = c.Int(nullable: false, identity: true),
                        NumAño = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.IdAño)
                .Index(t => t.NumAño, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Año", new[] { "NumAño" });
            DropTable("dbo.Año");
        }
    }
}
