using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PontoDeAjuda
{
    [Table("Pontos")]
    public class Ponto
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024;
        [Key]
        public int PontoID { get; set; }
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
        public PontoState Status { get; set; }

        public Ponto()
        {
            CreationTime = DateTime.Now;
            DataFinal = DataFinal;
            Status = PontoState.Aberto;
        }

        public Ponto(string nome, string descricao, string endereco, string telefone, DateTime dataFinal, Suprimento suprimentos)
        {
            Nome = nome;
            Descricao = descricao;
            Endereco = endereco;
            Telefone = telefone;
            DataFinal = dataFinal;
            Suprimentos = suprimentos;
            CreationTime = DateTime.Now;
            Status = PontoState.Aberto;
        }
    }
    public enum PontoState : byte
    {
        Aberto = 0,
        Fechado = 0
    }
}
