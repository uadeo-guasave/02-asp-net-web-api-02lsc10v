using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_asp_net_web_api_02lsc10v.Models
{
    [Table("editorials")]
    public class Editorial
    {
        // Nombre, Domicilio, Correo Electronico, Sitio Web, Telefono, Codigo postal
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100), StringLength(100,MinimumLength=1)]
        public string Name { get; set; }

        [Column("address")]
        [Required]
        [MaxLength(200), StringLength(200,MinimumLength=1)]
        public string Address { get; set; }

        [Column("email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Column("website")]
        [Required]
        [Url]
        public string Website { get; set; }

        [Column("phone")]
        [Required]
        [Phone]
        public string Phone { get; set; }

        [Column("postalcode")]
        [Required]
        [Range(1,99999)]
        public int PostalCode { get; set; }
    }
}