namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            DropColumn("dbo.Customers", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MyProperty", c => c.DateTime());
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
