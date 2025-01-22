namespace avtomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TGROUPs", newName: "TGROUP");
            DropForeignKey("dbo.TRELATIONs", "IdChild", "dbo.TGROUPs");
            DropForeignKey("dbo.TRELATIONs", "IdParent", "dbo.TGROUPs");
            DropForeignKey("dbo.TRELATIONs", "TGROUP_Id", "dbo.TGROUPs");
            DropForeignKey("dbo.TRELATIONs", "TGROUP_Id1", "dbo.TGROUPs");
            DropIndex("dbo.TRELATIONs", new[] { "IdParent" });
            DropIndex("dbo.TRELATIONs", new[] { "IdChild" });
            DropIndex("dbo.TRELATIONs", new[] { "TGROUP_Id" });
            DropIndex("dbo.TRELATIONs", new[] { "TGROUP_Id1" });
            DropPrimaryKey("dbo.TGROUP");
            AlterColumn("dbo.TGROUP", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.TGROUP", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.TGROUP", "Id");
            DropTable("dbo.TRELATIONs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TRELATIONs",
                c => new
                    {
                        IdParent = c.Int(nullable: false),
                        IdChild = c.Int(nullable: false),
                        TGROUP_Id = c.Int(),
                        TGROUP_Id1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdParent, t.IdChild });
            
            DropPrimaryKey("dbo.TGROUP");
            AlterColumn("dbo.TGROUP", "Name", c => c.String());
            AlterColumn("dbo.TGROUP", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TGROUP", "Id");
            CreateIndex("dbo.TRELATIONs", "TGROUP_Id1");
            CreateIndex("dbo.TRELATIONs", "TGROUP_Id");
            CreateIndex("dbo.TRELATIONs", "IdChild");
            CreateIndex("dbo.TRELATIONs", "IdParent");
            AddForeignKey("dbo.TRELATIONs", "TGROUP_Id1", "dbo.TGROUPs", "Id");
            AddForeignKey("dbo.TRELATIONs", "TGROUP_Id", "dbo.TGROUPs", "Id");
            AddForeignKey("dbo.TRELATIONs", "IdParent", "dbo.TGROUPs", "Id");
            AddForeignKey("dbo.TRELATIONs", "IdChild", "dbo.TGROUPs", "Id");
            RenameTable(name: "dbo.TGROUP", newName: "TGROUPs");
        }
    }
}
