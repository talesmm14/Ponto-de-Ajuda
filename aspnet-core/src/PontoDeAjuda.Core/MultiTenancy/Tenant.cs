using Abp.MultiTenancy;
using PontoDeAjuda.Authorization.Users;

namespace PontoDeAjuda.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
