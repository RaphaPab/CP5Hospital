using System.ComponentModel.DataAnnotations;

namespace CP5Hospital.Models
{
    public class PlanoSaude
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomePlano { get; set; }

        [Required]
        [StringLength(200)]
        public string Cobertura { get; set; }
    }
}