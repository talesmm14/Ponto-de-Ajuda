using System.Collections.Generic;
using PontoDeAjuda.Roles.Dto;

namespace PontoDeAjuda.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
