namespace WebApplication1.Models
{
    public class Game
    {
        //DML - Data Manipulation Language
        //  SELECT, INSERT, UPDATE, DELETE (CRUD)
        //DDL - Data Definition Language
        //  CREATE, ALTER, DROP, TRUNCATE
        //  DROP - Deletion of database objects (tables, views, indexes, database)
        //  TRUNCATE - Deletion of all records from a table, increment primary key
        // table 3 -> id: 1, 2, 3 -> DELETE FROM table; INSERT INTO table 4, 5, 6
        // CREATE TABLE games (
        public Game()
        {
            Artworks = [];
            Platforms = [];
            Genre = [];
        }

        public int Id { get; set; }
        public List<string> Artworks { get; set; }
        public required string GameType { get; set; }
        public required string Title { get; set; }
        public string? Slug { get; set; }
        public List<string> Platforms { get; set; }
        public List<string> Genre { get; set; }
        public string? Developer { get; set; }
        public int ReleaseYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
