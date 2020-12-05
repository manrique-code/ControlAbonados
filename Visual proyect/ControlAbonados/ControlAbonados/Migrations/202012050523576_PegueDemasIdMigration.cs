namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PegueDemasIdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pegue", "IdTipoPegue", c => c.Int(nullable: false));
            AddColumn("dbo.Pegue", "IdEstadoPegue", c => c.Int(nullable: false));
            AddColumn("dbo.Pegue", "IdBloque", c => c.Int(nullable: false));
            CreateIndex("dbo.Pegue", "IdTipoPegue");
            CreateIndex("dbo.Pegue", "IdEstadoPegue");
            CreateIndex("dbo.Pegue", "IdBloque");
            AddForeignKey("dbo.Pegue", "IdBloque", "dbo.Bloque", "IdBloque", cascadeDelete: true);
            AddForeignKey("dbo.Pegue", "IdEstadoPegue", "dbo.EstadoPegue", "IdEstadoPegue", cascadeDelete: true);
            AddForeignKey("dbo.Pegue", "IdTipoPegue", "dbo.TipoPegue", "IdTipoPegue", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pegue", "IdTipoPegue", "dbo.TipoPegue");
            DropForeignKey("dbo.Pegue", "IdEstadoPegue", "dbo.EstadoPegue");
            DropForeignKey("dbo.Pegue", "IdBloque", "dbo.Bloque");
            DropIndex("dbo.Pegue", new[] { "IdBloque" });
            DropIndex("dbo.Pegue", new[] { "IdEstadoPegue" });
            DropIndex("dbo.Pegue", new[] { "IdTipoPegue" });
            DropColumn("dbo.Pegue", "IdBloque");
            DropColumn("dbo.Pegue", "IdEstadoPegue");
            DropColumn("dbo.Pegue", "IdTipoPegue");
        }
    }
}
