namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StuNumber", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StuNumber");
        }
    }
}
