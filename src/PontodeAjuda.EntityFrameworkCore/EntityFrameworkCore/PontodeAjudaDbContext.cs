using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PontodeAjuda.EntityFrameworkCore
{
    public class PontodeAjudaDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public PontodeAjudaDbContext(DbContextOptions<PontodeAjudaDbContext> options) 
            : base(options)
        {

        }
    }
}
