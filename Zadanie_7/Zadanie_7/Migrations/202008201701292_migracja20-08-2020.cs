namespace Zadanie_7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja20082020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyRates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rate_value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyRates");
        }
    }
}
