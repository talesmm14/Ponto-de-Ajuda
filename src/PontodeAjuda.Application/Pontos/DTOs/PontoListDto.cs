using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;

namespace PontodeAjuda.Pontos.DTOs
{
    [AutoMapFrom(typeof(Ponto))]
    public class PontoListDto : EntityDto, IHasCreationTime
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataFinal { get; set; }
        public Suprimento Suprimentos { get; set; }
        public DateTime CreationTime { get; set; }
        public PontoState Status { get; set; }
    }
}
