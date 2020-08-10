using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PontoDeAjuda.EntityFrameworkCore
{
    public static class PontoDeAjudaDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PontoDeAjudaDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PontoDeAjudaDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
