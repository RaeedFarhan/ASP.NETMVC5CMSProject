namespace Content_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Requierd = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryFields", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CategoryFields", new[] { "CategoryId" });
            DropTable("dbo.CategoryFields");
        }
    }
}
