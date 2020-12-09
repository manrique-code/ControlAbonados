namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarAñoFromDBMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Año", new[] { "NumAño" });
            DropTable("dbo.Año");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Año",
                c => new
                    {
                        IdAño = c.Int(nullable: false, identity: true),
                        NumAño = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.IdAño);
            
            CreateIndex("dbo.Año", "NumAño", unique: true);
        }
    }
}
