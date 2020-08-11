using System.Collections.Generic;
using PontoDeAjuda.Roles.Dto;

namespace PontoDeAjuda.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
