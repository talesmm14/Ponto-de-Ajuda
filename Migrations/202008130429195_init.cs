namespace PontoDeAjuda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doacoes",
                c => new
                    {
                        DoacaoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        icon = c.String(),
                    })
                .PrimaryKey(t => t.DoacaoID);
            
            CreateTable(
                "dbo.Pontos",
                c => new
                    {
                        PontoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 256),
                        Descricao = c.String(),
                        Endereco = c.String(nullable: false),
                        Telefone = c.String(),
                        DataFinal = c.DateTime(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.PontoID);
            
            CreateTable(
                "dbo.PontoDeAjuda",
                c => new
                    {
                        PontoID = c.Int(nullable: false),
                        DoacaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PontoID, t.DoacaoID })
                .ForeignKey("dbo.Pontos", t => t.PontoID, cascadeDelete: true)
                .ForeignKey("dbo.Doacoes", t => t.DoacaoID, cascadeDelete: true)
                .Index(t => t.PontoID)
                .Index(t => t.DoacaoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PontoDeAjuda", "DoacaoID", "dbo.Doacoes");
            DropForeignKey("dbo.PontoDeAjuda", "PontoID", "dbo.Pontos");
            DropIndex("dbo.PontoDeAjuda", new[] { "DoacaoID" });
            DropIndex("dbo.PontoDeAjuda", new[] { "PontoID" });
            DropTable("dbo.PontoDeAjuda");
            DropTable("dbo.Pontos");
            DropTable("dbo.Doacoes");
        }
    }
}
