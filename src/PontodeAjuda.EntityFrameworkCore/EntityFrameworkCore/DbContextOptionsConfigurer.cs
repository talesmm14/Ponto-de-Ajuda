using Microsoft.EntityFrameworkCore;

namespace PontodeAjuda.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<PontodeAjudaDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for PontodeAjudaDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
