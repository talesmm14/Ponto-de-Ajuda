using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PontodeAjuda.EntityFrameworkCore
{
    public class PontodeAjudaDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Suprimento> Suprimentos { get; set; }
        public PontodeAjudaDbContext(DbContextOptions<PontodeAjudaDbContext> options) 
            : base(options)
        {

        }
    }
}
