using System.ComponentModel.DataAnnotations;

namespace BonjoAPI.Models.Movie
{
    public class MovieRegisterDTO
    {
        [Required]
        public string Title { get; set; }
    }
}