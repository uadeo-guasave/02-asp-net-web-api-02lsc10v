using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using _02_asp_net_web_api_02lsc10v.Helpers;

namespace _02_asp_net_web_api_02lsc10v.Models
{
  public class User : IValidatableObject
  {
    public int Id { get; set; }

    [Required, MaxLength(12), StringLength(12, MinimumLength = 6)]
    public string Name { get; set; }

    [Required, MaxLength(200)]
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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      // add validation logic
      // strengh >= STRONG
      var fortaleza = VerificarFortaleza();
      if (fortaleza < (int)PasswordStrengh.STRONG)
      {
        yield return new ValidationResult($"La contraseña es {(PasswordStrengh)fortaleza}, agrega mayúsculas, minúsculas, numeros y simbolos para reforzarla.", new[] { nameof(Password) });
      }

      if (Name.Any(c => !char.IsLetter(c)))
      {
        yield return new ValidationResult("El campo Name debe contenter solo letras.", new[] { nameof(Name) });
      }

    }

    private int VerificarFortaleza()
    {
      // strengh = (muy facil, facil, medio, fuerte, muy fuerte)
      var fortaleza = 0;
      // Longitud (>=6 +1)
      if (Password.Length >= 6)
        fortaleza++;

      // Mayusculas (+1)
      if (Password.Any(c => char.IsUpper(c)))
        fortaleza++;

      // Minusculas (+1)
      if (Password.Any(c => char.IsLower(c)))
        fortaleza++;

      // Numeros (+1)
      if (Password.Any(c => char.IsDigit(c)))
        fortaleza++;

      // Simbolos (+1)
      if (Password.Any(c => char.IsSymbol(c)))
        fortaleza++;

      return fortaleza;
    }
  }

  public enum PasswordStrengh
  {
    VERY_WEAK = 1,
    WEAK = 2,
    MEDIUM = 3,
    STRONG = 4,
    VERY_STRONG = 5
  }
}