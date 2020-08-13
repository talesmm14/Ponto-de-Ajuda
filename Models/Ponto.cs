using System;
using System.Collections.Generic;
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
        [Display(Name = "Nome do local")]
        public string Nome { get; set; }
        [StringLength(MaxDescriptionLength)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required]
        [StringLength(MaxDescriptionLength)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Final (Se existir)")]
        public DateTime DataFinal { get; set; }
        [Required]
        [Display(Name = "Doações")]
        private ICollection<Doacao> _doacoes;
        public ICollection<Doacao> Doacoes
        {
            get
            {
                return _doacoes ?? (_doacoes = new List<Doacao>());
            }
            set
            {
                _doacoes = value;
            }
        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }
        public PontoState Status { get; set; }

        public Ponto()
        {
            CreationTime = DateTime.Now;
            DataFinal = DataFinal;
            Status = PontoState.Aberto;
        }

        public Ponto(int pontoID, string nome, string descricao, string endereco, string telefone, DateTime dataFinal, ICollection<Doacao> doacoes)
        {
            PontoID = pontoID;
            Nome = nome;
            Descricao = descricao;
            Endereco = endereco;
            Telefone = telefone;
            DataFinal = dataFinal;
            Doacoes = doacoes;
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
