using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context; //init
        }

        //CRUD Game Table
        //C-create POST
        //R-Read/Retrieve GET -all GET -byid
        //U-Update PATCH/PUT
        //D-Delete DELETE

        public async Task<ActionResult<List<GameDTO>>> GetAllGames()
        {
            try
            {
                var users = await _context.Games
                    .Select(u => new GameDTO
                    {
                        Artworks = u.Artworks,
                        GameType = u.GameType,
                        Title = u.Title,
                        Slug = u.Slug,
                        Platforms = u.Platforms,
                        Genre=u.Genre,
                        Developer=u.Developer,
                        ReleaseYear=u.ReleaseYear
                    }).ToListAsync();
                var response = new
                {
                    Success = true,
                    Data = users,
                    Message = "Users retrieved successfully."
                };

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
                return StatusCode(500, response);
            }
        }
    
        //POST - http body
        public async Task<ActionResult<GameDTO>> CreateGame([FromBody] CreateGameDTO createDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Validation failed.",
                        Errors = errors
                    });
                }

                var user = new Game
                {
                    Title = createDTO.Title,
                    Slug = createDTO.Slug,
                    Developer = createDTO.Developer,
                    ReleaseYear = createDTO.ReleaseYear,
                    GameType = createDTO.GameType
                };
            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = false,
                    Message = "An error occurred while creating data.",
                    Errors = new List<string> { ex.Message }
                };
                return StatusCode(500, response);
            }
        }
    }
}
