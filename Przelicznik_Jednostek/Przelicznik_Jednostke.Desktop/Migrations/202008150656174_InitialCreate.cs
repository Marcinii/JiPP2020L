namespace Przelicznik_Jednostke.Desktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.daneBazaDBOes",
                c => new
                    {
                        id_konwersja = c.Int(nullable: false, identity: true),
                        typ_konwersji = c.String(),
                        jed_przed = c.Double(nullable: false),
                        jed_po = c.Double(nullable: false),
                        data_konwersji = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_konwersja);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.daneBazaDBOes");
        }
    }
}
