using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace PontoDeAjuda.DAL
{
    public class PontoContext : DbContext
    {
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public PontoContext() : base("PontoContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Ponto>()
             .HasMany(c => c.Doacoes).WithMany(i => i.Pontos)
             .Map(t => t.MapLeftKey("PontoID")
                 .MapRightKey("DoacaoID")
                 .ToTable("PontoDeAjuda"));
        }
    }
}
