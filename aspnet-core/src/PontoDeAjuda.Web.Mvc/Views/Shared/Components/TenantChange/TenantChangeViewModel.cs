using Abp.AutoMapper;
using PontoDeAjuda.Sessions.Dto;

namespace PontoDeAjuda.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
