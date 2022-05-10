namespace StudyLJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieWithNewFields : DbMigration
    {
        public override void Up()
        {
            Sql(@"  UPDATE Movies
                    SET ReleaseDate = '01/01/2000',
                        DateAdded = '05/05/2022',
                        NumberInStock = 10
                    WHERE Id = 1");
            Sql(@"  UPDATE Movies
                    SET ReleaseDate = '01/01/2001',
                        DateAdded = '06/05/2022',
                        NumberInStock = 12
                    WHERE Id = 2");
            Sql(@"  UPDATE Movies
                    SET ReleaseDate = '01/01/2002',
                        DateAdded = '07/05/2003',
                        NumberInStock = 14
                    WHERE Id = 3");
            Sql(@"  UPDATE Movies
                    SET ReleaseDate = '01/01/2004',
                        DateAdded = '08/05/2022',
                        NumberInStock = 15
                    WHERE Id = 4");
            Sql(@"  UPDATE Movies
                    SET ReleaseDate = '01/01/2005',
                        DateAdded = '09/05/2022',
                        NumberInStock = 16
                    WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
