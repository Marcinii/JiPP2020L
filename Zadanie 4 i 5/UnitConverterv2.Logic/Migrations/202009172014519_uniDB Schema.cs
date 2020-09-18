namespace UnitConverterv2.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniDBSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ratings");
        }
    }
}
