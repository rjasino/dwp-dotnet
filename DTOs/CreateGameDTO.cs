using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class CreateGameDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public required string Title { get; set; }
        [Required(ErrorMessage = "Slug is required.")]
        public required string Slug { get; set; }
        [Required(ErrorMessage = "Developer is required.")]
        [StringLength(50, ErrorMessage = "Developer cannot exceed 50 characters.")]
        public required string Developer { get; set; }
        public int ReleaseYear { get; set; }
        [Required(ErrorMessage = "Game Type is required.")]
        public required string GameType { get; set; }
    }
}
