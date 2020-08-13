using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PontoDeAjuda
{
    [Table("Suprimentos")]
    public class Suprimento
    {
        [Key]
        public int SuprimentoID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string icon { get; set; }
    }
}

