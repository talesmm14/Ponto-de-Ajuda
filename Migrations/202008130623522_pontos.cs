namespace PontoDeAjuda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pontos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pontos", "Doacao_DoacaoID", c => c.Int());
            CreateIndex("dbo.Pontos", "Doacao_DoacaoID");
            AddForeignKey("dbo.Pontos", "Doacao_DoacaoID", "dbo.Doacoes", "DoacaoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pontos", "Doacao_DoacaoID", "dbo.Doacoes");
            DropIndex("dbo.Pontos", new[] { "Doacao_DoacaoID" });
            DropColumn("dbo.Pontos", "Doacao_DoacaoID");
        }
    }
}
