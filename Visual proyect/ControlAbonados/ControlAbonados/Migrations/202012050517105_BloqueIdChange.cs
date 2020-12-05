namespace ControlAbonados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloqueIdChange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Bloque");
            AlterColumn("dbo.Bloque", "IdBloque", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Bloque", "IdBloque");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Bloque");
            AlterColumn("dbo.Bloque", "IdBloque", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Bloque", "IdBloque");
        }
    }
}
