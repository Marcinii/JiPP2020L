namespace KonwerterJednostek.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Star : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        valueOfStar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stars");
        }
    }
}
