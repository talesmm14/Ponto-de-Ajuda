using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PontoDeAjuda.Configuration;
using PontoDeAjuda.Web;

namespace PontoDeAjuda.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PontoDeAjudaDbContextFactory : IDesignTimeDbContextFactory<PontoDeAjudaDbContext>
    {
        public PontoDeAjudaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PontoDeAjudaDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            PontoDeAjudaDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PontoDeAjudaConsts.ConnectionStringName));

            return new PontoDeAjudaDbContext(builder.Options);
        }
    }
}
