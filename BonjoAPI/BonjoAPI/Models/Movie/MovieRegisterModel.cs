using System.ComponentModel.DataAnnotations;

namespace BonjoAPI.Models.Movie
{
    public class MovieRegisterModel
    {
        [Required]
        public string Title { get; set; }
    }
}