using System.ComponentModel.DataAnnotations;

namespace nextia_challenge.DTOs
{
    public class RegistroProdutoDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string categoria { get; set; }

        public float valor { get; set; }
    }
}
