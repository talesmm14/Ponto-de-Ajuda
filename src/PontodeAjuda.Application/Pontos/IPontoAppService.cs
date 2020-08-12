using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using PontodeAjuda.Pontos.DTOs;

namespace PontodeAjuda.Pontos
{
    public interface IPontoAppService : IApplicationService
    {
        Task<ListResultDto<PontoListDto>> GetAll(GetAllPontosInput input);
    }
}
