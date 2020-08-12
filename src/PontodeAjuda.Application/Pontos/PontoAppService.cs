using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using PontodeAjuda.Pontos.DTOs;

namespace PontodeAjuda.Pontos
{
    public class PontoAppService : PontodeAjudaAppServiceBase, IPontoAppService
    {
        private readonly IRepository<Ponto> _pontoRepository;
        public PontoAppService(IRepository<Ponto> pontoRepository)
        {
            _pontoRepository = pontoRepository;
        }

        public async Task<ListResultDto<PontoListDto>> GetAll(GetAllPontosInput input)
        {
            var pontos = await _pontoRepository
            .GetAll()
            .WhereIf(input.State.HasValue, t => t.Status == input.State.Value)
            .OrderByDescending(t => t.CreationTime)
            .ToListAsync();

            return new ListResultDto<PontoListDto>(
                ObjectMapper.Map<List<PontoListDto>>(pontos)
                );
        }
        public async System.Threading.Tasks.Task Create(CreatePontoInput input)
        {
            var ponto = ObjectMapper.Map<Ponto>(input);
            await _pontoRepository.InsertAsync(ponto);
        }
    }
}
