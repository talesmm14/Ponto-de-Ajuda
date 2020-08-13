using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PontoDeAjuda.DAL
{
    public class PontoContext : DbContext
    {
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Suprimento> Suprimentos { get; set; }
        public PontoContext() : base("PontoContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
