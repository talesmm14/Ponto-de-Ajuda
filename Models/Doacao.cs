using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PontoDeAjuda
{
    [Table("Doacoes")]
    public class Doacao
    {
        [Key]
        public int DoacaoID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        public string icon { get; set; }
        public ICollection<Ponto> Pontos { get; set; }
    }
}

