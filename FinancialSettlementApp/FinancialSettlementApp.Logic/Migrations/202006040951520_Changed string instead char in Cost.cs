namespace FinancialSettlementApp.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedstringinsteadcharinCost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Costs", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Costs", "Status");
        }
    }
}
