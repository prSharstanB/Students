namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rowr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registerings", "RegType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registerings", "RegType");
        }
    }
}
