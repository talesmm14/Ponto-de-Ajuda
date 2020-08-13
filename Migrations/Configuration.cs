namespace PontoDeAjuda.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PontoDeAjuda.DAL.PontoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PontoDeAjuda.DAL.PontoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var doacoes = new List<Doacao>
            {
                new Doacao{ Nome = "Mascara", icon = "fa fa-user"},
                new Doacao{ Nome = "MedKit", icon = "fa fa-medkit"}
            };
            doacoes.ForEach(s => context.Doacoes.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();

            var pontos = new List<Ponto>
            {
                new Ponto{ Nome = "Ponto de Teste", Descricao = "Este ponto e apenas para teste",
                Endereco = " - - - ", Telefone = "69 9 9999-9999", DataFinal = DateTime.Parse("2010-09-01"),
                Doacoes =  doacoes},
                new Ponto{ Nome = "Ponto de Teste 2", Descricao = "Um ponto de teste",
                Endereco = " - - - ", Telefone = "69 9 9999-9999", DataFinal = DateTime.Parse("2020-10-06"),
                Doacoes =  doacoes}
            };
            pontos.ForEach(s => context.Pontos.AddOrUpdate(p => p.Nome, s));
            context.SaveChanges();
        }
    }
}
