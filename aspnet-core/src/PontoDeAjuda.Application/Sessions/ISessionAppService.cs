using System.Threading.Tasks;
using Abp.Application.Services;
using PontoDeAjuda.Sessions.Dto;

namespace PontoDeAjuda.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
