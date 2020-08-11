using Abp.Application.Services.Dto;

namespace PontoDeAjuda.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

