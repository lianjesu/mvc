namespace StudyLJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesAndGenreTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Action')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Comedy')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Family')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Romance')");
            
            Sql("INSERT INTO Movies ( Name, Genre_Id) VALUES ('Hangover', 2 )");
            Sql("INSERT INTO Movies ( Name, Genre_Id) VALUES ('Die Hard', 1 )");
            Sql("INSERT INTO Movies ( Name, Genre_Id) VALUES ('The Terminator', 1 )");
            Sql("INSERT INTO Movies ( Name, Genre_Id) VALUES ('Toy Story', 3 )");
            Sql("INSERT INTO Movies ( Name, Genre_Id) VALUES ('Titanic', 4 )");


        }
        
        public override void Down()
        {
        }
    }
}
