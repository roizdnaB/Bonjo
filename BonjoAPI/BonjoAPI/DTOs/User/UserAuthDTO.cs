using System.ComponentModel.DataAnnotations;

namespace BonjoAPI.Models.User
{
    public class UserAuthDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}