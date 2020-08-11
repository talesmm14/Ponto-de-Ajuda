using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace PontodeAjuda
{
    [Table("Suprimentos")]
    public class Suprimento : Entity
    {
            [Required]
            public string Nome { get; set; }
            [Required]
            public string icon { get; set; }
        }
}

