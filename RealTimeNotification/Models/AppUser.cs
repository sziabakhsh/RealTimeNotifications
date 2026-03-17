using System.ComponentModel.DataAnnotations;

namespace RealTimeNotification.Models
{
    public class AppUser
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
