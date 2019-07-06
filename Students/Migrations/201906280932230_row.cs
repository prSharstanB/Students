namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class row : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registerings", "RegTypeId", "dbo.RegTypes");
            DropIndex("dbo.Registerings", new[] { "RegTypeId" });
            DropColumn("dbo.Registerings", "RegTypeId");
            DropTable("dbo.RegTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Registerings", "RegTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Registerings", "RegTypeId");
            AddForeignKey("dbo.Registerings", "RegTypeId", "dbo.RegTypes", "Id", cascadeDelete: true);
        }
    }
}
