using System.ComponentModel.DataAnnotations;

namespace NicolasCasamen_Examen1P.Models
{
    public class NC_Cine
    {
        [Key]
        public int NC_NumeroBoleto { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Nombre no Valido"), MinLength(5, ErrorMessage = "Nombre no Valido")]
        public String? NC_Pelicula { get; set; }
        [Required]
        public DateTime NC_FechaPelicula { get; set; }
        [Required]
        public int NC_Entradas { get; set; }
        public bool NC_Socio { get; set; }
        [VerificarSocio]
        public decimal NC_Costo { get; set; }
    }
    public class VerificarSocio : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            decimal valor = (decimal)value;
            if (valor <= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}