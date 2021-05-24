namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MoviesTypes (Id, name) VALUES (1, 'Action')");
            Sql("INSERT INTO MoviesTypes (Id, name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO MoviesTypes (Id, name) VALUES (3, 'Family')");
            Sql("INSERT INTO MoviesTypes (Id, name) VALUES (4, 'Romance')");
            Sql("INSERT INTO MoviesTypes (Id, name) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
