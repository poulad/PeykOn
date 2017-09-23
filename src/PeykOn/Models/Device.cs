using System;
using System.ComponentModel.DataAnnotations;

namespace PeykOn.Models
{
    public class Device
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string LastSeenIp { get; set; }

        public DateTime? LastSeenAt { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedAt { get; set; }
    }
}