using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using PontoDeAjuda.Authorization.Roles;
using PontoDeAjuda.Authorization.Users;
using PontoDeAjuda.MultiTenancy;

namespace PontoDeAjuda.EntityFrameworkCore
{
    public class PontoDeAjudaDbContext : AbpZeroDbContext<Tenant, Role, User, PontoDeAjudaDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PontoDeAjudaDbContext(DbContextOptions<PontoDeAjudaDbContext> options)
            : base(options)
        {
        }
    }
}
