using Abp.AutoMapper;
using PontoDeAjuda.Roles.Dto;
using PontoDeAjuda.Web.Models.Common;

namespace PontoDeAjuda.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
