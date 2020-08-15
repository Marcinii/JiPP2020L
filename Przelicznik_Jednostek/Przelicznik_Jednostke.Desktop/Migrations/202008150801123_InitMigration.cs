namespace Przelicznik_Jednostke.Desktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.daneBazaDBOes", "jed_przed", c => c.String());
            AlterColumn("dbo.daneBazaDBOes", "jed_po", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.daneBazaDBOes", "jed_po", c => c.Double(nullable: false));
            AlterColumn("dbo.daneBazaDBOes", "jed_przed", c => c.Double(nullable: false));
        }
    }
}
