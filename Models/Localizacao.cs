using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nextia_challenge.Models;
namespace nextia_challenge.Models
{
    [Table("Localizacoes")]
    public class Localizacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [ForeignKey("Coral")]
        public int CoralId { get; set; }
        public Coral Coral { get; set; }
    }
}
