using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1
{
    //Game Retrospective Site

    //Base Class
    public abstract class Content
    {
        public const string PlatformName = "GameHub";
        public int Id { get; private set; }
        public required string Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual string GetSummary()
        {
            return "";
        }

        protected Content(string title)
        {
            Title = title;
        }
    }
    public class Game : Content
    {
        //Properties
        //Members, Fields
        public string? Genre { get; set; }
        public string? Developer { get; set; }
        public int ReleaseYear { get; set; }

        private List<int> _ratings = new List<int>();   //Linked List

        //private int[] //stack delete index

        public Game() : base("")
        {

        }

        public Game(string title) : base(title)
        {
            
        }

        public override string GetSummary()
        {
            var summary = $"{Title} ({ReleaseYear}) - {Genre} by {Developer}.";
            return summary;
        }
        public string GetSummary(int id)
        {
            return "0";
        }
        public double AverageRating()
        {
            try
            {
                return _ratings.Average();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally //resource clearing
            {
                _ratings.Clear();
            }
        }
    }
    public class Review
    {
        public required string Author { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
        public required Game Game { get; set; }

        public Review(string author, Game game)
        {
            Author = author;
            Game = game;
        }
    }
    public class ReviewService
    {
        private readonly List<Review> _reviews = new List<Review>();
        private readonly List<Game> _games = new List<Game>();

        public void AddGame(Game game)
        {
            _games.Add(game);
        }

        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }

        public List<Game> GetTopRatedGames()
        {
            var topRatedGames = _games.Where(g => g.AverageRating() >= 8).ToList();
            return topRatedGames;
        }
    }
    public class Test
    {
        public void TestFunc()
        {
            var persona = new Game { Title = "Persona" };
            
        }
    }
    
}
