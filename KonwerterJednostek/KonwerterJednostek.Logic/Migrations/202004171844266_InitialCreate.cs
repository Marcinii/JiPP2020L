namespace KonwerterJednostek.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wpis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConverterName = c.String(),
                        UnitFrom = c.String(),
                        UnitTo = c.String(),
                        Data = c.DateTime(nullable: false),
                        ValueFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValueTo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wpis");
        }
    }
}
