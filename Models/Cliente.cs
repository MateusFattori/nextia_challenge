using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nextia_challenge.Models;
namespace nextia_challenge.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string nome { get; set; }

        public string cpf { get; set; }

        public string email { get; set; }

        public string senha { get; set; }

        public string genero { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "DATE")]
        public DateTime dt_nascimento { get; set; }

        public string telefone { get; set; }
    }
}
