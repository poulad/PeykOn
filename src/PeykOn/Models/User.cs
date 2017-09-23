using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Matrix.NET.Models;

namespace PeykOn.Models
{
    public class User
    {
        public int Id { get; set; }

        public UserAccountKind Kind { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string PasswordHash { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? ModifiedAt { get; set; }

        public List<AccessToken> AccessTokens { get; set; }
    }
}
