using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nextia_challenge.Models;
namespace nextia_challenge.Models
{
    [Table("Corais")]
    public class Coral
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string Especie { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "DATE")]
        public DateTime dt_cadastro { get; set; }

        [ForeignKey("Projeto")]
    }
}
