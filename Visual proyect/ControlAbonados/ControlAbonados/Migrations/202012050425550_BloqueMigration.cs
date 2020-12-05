namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloqueMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bloque",
                c => new
                    {
                        IdBloque = c.String(nullable: false, maxLength: 128),
                        NumeroBloque = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.IdBloque)
                .Index(t => t.NumeroBloque, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Bloques", new[] { "NumeroBloque" });
            DropTable("dbo.Bloques");
        }
    }
}
