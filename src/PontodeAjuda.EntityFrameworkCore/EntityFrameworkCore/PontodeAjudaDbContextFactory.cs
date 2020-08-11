using PontodeAjuda.Configuration;
using PontodeAjuda.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PontodeAjuda.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class PontodeAjudaDbContextFactory : IDesignTimeDbContextFactory<PontodeAjudaDbContext>
    {
        public PontodeAjudaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PontodeAjudaDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(PontodeAjudaConsts.ConnectionStringName)
            );

            return new PontodeAjudaDbContext(builder.Options);
        }
    }
}