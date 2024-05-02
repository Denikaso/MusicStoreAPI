using System.ComponentModel.DataAnnotations;

namespace MusicStoreAPI.Models
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class VerifyPasswordRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}