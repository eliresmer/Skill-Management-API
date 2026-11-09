namespace SkillManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        DescriptionID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        SkillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DescriptionID)
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: true)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        KeywordText = c.String(nullable: false, maxLength: 100),
                        SkillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeywordText)
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: true)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.UserSkills",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        SkillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.SkillID })
                .ForeignKey("dbo.Skills", t => t.SkillID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.SkillID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        passwordHash = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSkills", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserSkills", "SkillID", "dbo.Skills");
            DropForeignKey("dbo.Keywords", "SkillID", "dbo.Skills");
            DropForeignKey("dbo.Descriptions", "SkillID", "dbo.Skills");
            DropIndex("dbo.UserSkills", new[] { "SkillID" });
            DropIndex("dbo.UserSkills", new[] { "UserID" });
            DropIndex("dbo.Keywords", new[] { "SkillID" });
            DropIndex("dbo.Descriptions", new[] { "SkillID" });
            DropTable("dbo.Users");
            DropTable("dbo.UserSkills");
            DropTable("dbo.Keywords");
            DropTable("dbo.Skills");
            DropTable("dbo.Descriptions");
        }
    }
}
