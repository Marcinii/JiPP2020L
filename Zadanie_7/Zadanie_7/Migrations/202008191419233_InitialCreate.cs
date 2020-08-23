namespace Zadanie_7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyBases",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Rodzaj_figury = c.String(),
                        Co_oblicza = c.String(),
                        A = c.Double(nullable: false),
                        B = c.Double(nullable: false),
                        C = c.Double(nullable: false),
                        H = c.Double(nullable: false),
                        wynik = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyBases");
        }
    }
}
