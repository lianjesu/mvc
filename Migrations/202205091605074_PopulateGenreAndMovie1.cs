namespace StudyLJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreAndMovie1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Action')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Comedy')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Family')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Romance')");

            Sql("INSERT INTO Movies ( Name, GenreId) VALUES ('Hangover', 2 )");
            Sql("INSERT INTO Movies ( Name, GenreId) VALUES ('Die Hard', 1 )");
            Sql("INSERT INTO Movies ( Name, GenreId) VALUES ('The Terminator', 1 )");
            Sql("INSERT INTO Movies ( Name, GenreId) VALUES ('Toy Story', 3 )");
            Sql("INSERT INTO Movies ( Name, GenreId) VALUES ('Titanic', 4 )");
        }
        
        public override void Down()
        {
        }
    }
}
