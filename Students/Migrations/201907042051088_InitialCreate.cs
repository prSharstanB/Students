namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Introductives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntDate = c.DateTime(nullable: false),
                        Avg = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.Int(nullable: false),
                        StuNumber = c.Int(),
                        Gender = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registerings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isDeleted = c.Boolean(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        RegType = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        StudyYear = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Introductives", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Registerings", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Introductives", "StudentId", "dbo.Students");
            DropIndex("dbo.Registerings", new[] { "StudentId" });
            DropIndex("dbo.Introductives", new[] { "SubjectId" });
            DropIndex("dbo.Introductives", new[] { "StudentId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Registerings");
            DropTable("dbo.Students");
            DropTable("dbo.Introductives");
        }
    }
}
