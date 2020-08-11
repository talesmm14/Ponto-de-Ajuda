using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace PontodeAjuda
{
    [Table("Pontos")]
    public class Ponto : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024;

        [Required]
        [StringLength(MaxTitleLength)]
        public string Nome { get; set; }
        [StringLength(MaxDescriptionLength)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(MaxDescriptionLength)]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataFinal { get; set; }
        [Required]
        public Suprimento Suprimentos { get; set; }
        public DateTime CreationTime { get; set; }
        public Ponto()
        {
            CreationTime = Clock.Now;
            DataFinal = DataFinal;
        }

        public Ponto(string nome, string descricao, string endereco, string telefone, DateTime dataFinal, Suprimento suprimentos)
        {
            Nome = nome;
            Descricao = descricao;
            Endereco = endereco;
            Telefone = telefone;
            DataFinal = dataFinal;
            Suprimentos = suprimentos;
            CreationTime = Clock.Now;
        }
    }
}
