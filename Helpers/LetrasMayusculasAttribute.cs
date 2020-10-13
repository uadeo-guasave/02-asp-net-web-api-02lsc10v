using System.ComponentModel.DataAnnotations;

namespace _02_asp_net_web_api_02lsc10v.Helpers
{
  public class LetrasMayusculasAttribute : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      // Validation rules
      if (value == null || string.IsNullOrEmpty(value.ToString()))
      {
        return ValidationResult.Success;
      }
      // value = "jose"; string.ToUpper(value) -> "JOSE"
      var nombre = value.ToString();
      if (nombre != nombre.ToUpper())
      {
        return new ValidationResult("Solo puede contener letras mayúsculas.");
      }

      return ValidationResult.Success;
    }
  }
}