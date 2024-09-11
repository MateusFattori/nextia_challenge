using System.ComponentModel.DataAnnotations;

namespace nextia_challenge.DTOs
{
    public class PromocaoDTO
    {
        [Required]
        public string produto { get; set; }

        [Required]
        public string nome_promocao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime dt_inicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime dt_final { get; set; }
    }
}
