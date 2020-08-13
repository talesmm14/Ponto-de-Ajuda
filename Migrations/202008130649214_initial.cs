namespace PontoDeAjuda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pontos", "Doacao_DoacaoID", "dbo.Doacoes");
            DropIndex("dbo.Pontos", new[] { "Doacao_DoacaoID" });
            DropColumn("dbo.Pontos", "Doacao_DoacaoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pontos", "Doacao_DoacaoID", c => c.Int());
            CreateIndex("dbo.Pontos", "Doacao_DoacaoID");
            AddForeignKey("dbo.Pontos", "Doacao_DoacaoID", "dbo.Doacoes", "DoacaoID");
        }
    }
}
