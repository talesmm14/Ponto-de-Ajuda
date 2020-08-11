using Abp.Authorization;
using PontoDeAjuda.Authorization.Roles;
using PontoDeAjuda.Authorization.Users;

namespace PontoDeAjuda.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
