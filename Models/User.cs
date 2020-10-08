using System;
using System.ComponentModel.DataAnnotations;

namespace _02_asp_net_web_api_02lsc10v.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(12)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Password { get; set; }

        [Required, MaxLength(50)]
        public string Firstname { get; set; }

        [Required, MaxLength(50)]
        public string Lastname { get; set; }

        [Required, MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(300)]
        public string RememberToken { get; set; }

        [Required]
        public DateTime LastLogin { get; set; }
    }
}