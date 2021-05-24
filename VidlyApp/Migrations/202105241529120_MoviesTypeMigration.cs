namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesTypeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MoviesTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "MoviesTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Movies", "MoviesTypeId");
            AddForeignKey("dbo.Movies", "MoviesTypeId", "dbo.MoviesTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MoviesTypeId", "dbo.MoviesTypes");
            DropIndex("dbo.Movies", new[] { "MoviesTypeId" });
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleasedDate");
            DropColumn("dbo.Movies", "MoviesTypeId");
            DropTable("dbo.MoviesTypes");
        }
    }
}
