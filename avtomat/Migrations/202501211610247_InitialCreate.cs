namespace avtomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TGROUPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TRELATIONs",
                c => new
                    {
                        IdParent = c.Int(nullable: false),
                        IdChild = c.Int(nullable: false),
                        TGROUP_Id = c.Int(),
                        TGROUP_Id1 = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdParent, t.IdChild })
                .ForeignKey("dbo.TGROUPs", t => t.IdChild)
                .ForeignKey("dbo.TGROUPs", t => t.IdParent)
                .ForeignKey("dbo.TGROUPs", t => t.TGROUP_Id)
                .ForeignKey("dbo.TGROUPs", t => t.TGROUP_Id1)
                .Index(t => t.IdParent)
                .Index(t => t.IdChild)
                .Index(t => t.TGROUP_Id)
                .Index(t => t.TGROUP_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TRELATIONs", "TGROUP_Id1", "dbo.TGROUPs");
            DropForeignKey("dbo.TRELATIONs", "TGROUP_Id", "dbo.TGROUPs");
            DropForeignKey("dbo.TRELATIONs", "IdParent", "dbo.TGROUPs");
            DropForeignKey("dbo.TRELATIONs", "IdChild", "dbo.TGROUPs");
            DropIndex("dbo.TRELATIONs", new[] { "TGROUP_Id1" });
            DropIndex("dbo.TRELATIONs", new[] { "TGROUP_Id" });
            DropIndex("dbo.TRELATIONs", new[] { "IdChild" });
            DropIndex("dbo.TRELATIONs", new[] { "IdParent" });
            DropTable("dbo.TRELATIONs");
            DropTable("dbo.TGROUPs");
        }
    }
}
