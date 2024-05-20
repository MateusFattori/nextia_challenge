using System.ComponentModel.DataAnnotations;
using nextia_challenge.Models;
namespace nextia_challenge.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        public string nome { get; set; }

        public string categoria { get; set; }

        public float valor { get; set; }
    }
}
