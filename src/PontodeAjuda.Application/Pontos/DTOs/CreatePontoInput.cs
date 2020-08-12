using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace PontodeAjuda.Pontos.DTOs
{
    [AutoMapTo(typeof(Ponto))]
    public class CreatePontoInput
    {
        [Required]
        [MaxLength(Ponto.MaxTitleLength)]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        [StringLength(Ponto.MaxDescriptionLength)]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataFinal { get; set; }
        [Required]
        public Suprimento Suprimentos { get; set; }
        public DateTime CreationTime { get; set; }
        public PontoState Status { get; set; }
    }
}
