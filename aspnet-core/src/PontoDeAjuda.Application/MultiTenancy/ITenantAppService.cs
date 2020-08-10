using Abp.Application.Services;
using PontoDeAjuda.MultiTenancy.Dto;

namespace PontoDeAjuda.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

