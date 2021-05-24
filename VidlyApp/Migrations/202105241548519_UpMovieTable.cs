namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.DateTime(nullable: false));
        }
    }
}
