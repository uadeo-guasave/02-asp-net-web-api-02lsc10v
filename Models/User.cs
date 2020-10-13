using System;
using System.ComponentModel.DataAnnotations;
using _02_asp_net_web_api_02lsc10v.Helpers;

namespace _02_asp_net_web_api_02lsc10v.Models
{
  public class User
  {
    public int Id { get; set; }

    [Required, MaxLength(12), StringLength(12, MinimumLength = 6)]
    public string Name { get; set; }

    [Required, MaxLength(200), StringLength(20, MinimumLength = 8)]
    public string Password { get; set; }

    [Required, StringLength(50, MinimumLength = 3), LetrasMayusculas]
    public string Firstname { get; set; }

    [Required, MaxLength(50), PrimeraLetraMayuscula]
    public string Lastname { get; set; }

    [Required, MaxLength(200), EmailAddress]
    public string Email { get; set; }

    [MaxLength(300)]
    public string RememberToken { get; set; }

    [Required]
    public DateTime LastLogin { get; set; }
  }
}