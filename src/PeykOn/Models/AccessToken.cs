using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeykOn.Models
{
    public class AccessToken
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string DeviceId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
