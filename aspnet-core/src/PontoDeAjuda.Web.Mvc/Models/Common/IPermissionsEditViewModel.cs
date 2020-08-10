using System.Collections.Generic;
using PontoDeAjuda.Roles.Dto;

namespace PontoDeAjuda.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}