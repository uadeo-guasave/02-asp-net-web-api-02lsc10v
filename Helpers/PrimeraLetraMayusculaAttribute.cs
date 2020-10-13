using System.ComponentModel.DataAnnotations;

namespace _02_asp_net_web_api_02lsc10v.Helpers
{
  public class PrimeraLetraMayusculaAttribute : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      // Validation rules
      if (value == null || string.IsNullOrEmpty(value.ToString()))
      {
        return ValidationResult.Success;
      }
      // value = "jose"; string.ToUpper(value) -> "JOSE"
      var letra = value.ToString();
      if (letra[0].ToString() != letra[0].ToString().ToUpper())
      {
        return new ValidationResult("La primera letra debe ser mayúscula.");
      }

      return ValidationResult.Success;
    }
  }
}