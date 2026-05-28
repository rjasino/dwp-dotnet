using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //route.php - GET, POST, PUT/PATCH, DELETE
    [ApiController]
    [Route("api/[controller]")] //Attribute //Data Annotation   /api/game
    //route.get("/api/games", [GamesController::class, "index"]);
    //app.get("/api/games", (req, res) => { ... });
    public class GamesController : ControllerBase
    {
        //Controller - Laravel
        //Model - Eloquent
        //View - Blade
        //Controller - ASP.NET Core MVC
        //Model - Entity Framework Core
        //View - Razor | Blazor
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context; //init
        }

        //CRUD Game Table
        //C-create POST
        //R-Read/Retrieve GET -all GET -byid
        //U-Update PATCH/PUT
        //D-Delete DELETE

        //public async Task<ActionResult<string>> name()
        //{
        //    var message = Task.FromResult("my name");
        //    return await message;
        //}

        public async Task<ActionResult<List<GameDTO>>> GetAllGames()
        {
            try
            {
                //Select * from games
                //Select artworks, game_type, title, slug, platforms from games where release_year > 2020
                //Data Transfer Object (DTO)
                //Mapping - AutoMapper
                //
                //IEnumerable -> List, Array, HashSet, Dictionary
                //IQueryable -> IQueryable, DbSet
                //IEnumerable - LINQ to Objects - In Memory
                //IQueryable - LINQ to SQL - Database
                var games = await _context.Games
                    .Select(g => new GameDTO
                    {
                        Artworks = g.Artworks,
                        GameType = g.GameType,
                        Title = g.Title,
                        Slug = g.Slug,
                        Platforms = g.Platforms,
                        Genre=g.Genre,
                        Developer=g.Developer,
                        ReleaseYear=g.ReleaseYear
                    })
                    .Where(g => g.ReleaseYear > 2020)
                    .ToListAsync();
                var response = new
                {
                    Success = true,
                    Data = games,
                    Message = "Games retrieved successfully."
                };
                // Express
                // res.status(200).json(response);
                // Laravel
                // return response()->json($response, 200);
                return Ok(response);    //200
            }
            catch(Exception ex)
            {
                var response = new
                {
                    Success = false,
                    Message = "An error occurred while retrieving data.",
                    Errors = new List<string> { ex.Message }
                };
                // Native JSON response
                // const response = {
                //    "success": false, //key value pair
                //    "message": "An error occurred while retrieving data.",
                //    "errors": ["error1", "error2"]"
                // };
                // Laravel JSON response
                // var response = [
                //    "success" => false,
                //    "message" => "An error occurred while retrieving data.",
                //    "errors" => ["error1", "error2"]
                // ];
                return StatusCode(500, response);
            }
        }

        //POST - http body
        //public async Task<ActionResult<GameDTO>> CreateGame([FromBody] CreateGameDTO createDTO)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            var errors = ModelState.Values
        //                .SelectMany(v => v.Errors)
        //                .Select(e => e.ErrorMessage)
        //                .ToList();
        //            return BadRequest(new
        //            {
        //                Success = false,
        //                Message = "Validation failed.",
        //                Errors = errors
        //            });
        //        }

        //        var user = new Game
        //        {
        //            Title = createDTO.Title,
        //            Slug = createDTO.Slug,
        //            Developer = createDTO.Developer,
        //            ReleaseYear = createDTO.ReleaseYear,
        //            GameType = createDTO.GameType
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        var response = new
        //        {
        //            Success = false,
        //            Message = "An error occurred while creating data.",
        //            Errors = new List<string> { ex.Message }
        //        };
        //        return StatusCode(500, response);
        //    }
        //}
    }
}
