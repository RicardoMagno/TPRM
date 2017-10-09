namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_3_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Testes", "EmpresaContratadaID", "dbo.Empresas");
            DropForeignKey("dbo.Testes", "EmpresaContratanteID", "dbo.Empresas");
            DropForeignKey("dbo.Testes", "TipoServicoID", "dbo.Servicos");
            DropForeignKey("dbo.Testes", "StatusTransacaoID", "dbo.StatusFluxoTransacao");
            DropIndex("dbo.Testes", new[] { "EmpresaContratanteID" });
            DropIndex("dbo.Testes", new[] { "EmpresaContratadaID" });
            DropIndex("dbo.Testes", new[] { "TipoServicoID" });
            DropIndex("dbo.Testes", new[] { "StatusTransacaoID" });
            DropTable("dbo.Testes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Testes",
                c => new
                    {
                        EmpresaContratanteID = c.Int(nullable: false),
                        EmpresaContratadaID = c.Int(nullable: false),
                        TipoServicoID = c.Int(nullable: false),
                        TransacaoID = c.Int(nullable: false, identity: true),
                        ValorTransacao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DescricaoTransacao = c.String(nullable: false, maxLength: 50),
                        StatusTransacaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransacaoID);
            
            CreateIndex("dbo.Testes", "StatusTransacaoID");
            CreateIndex("dbo.Testes", "TipoServicoID");
            CreateIndex("dbo.Testes", "EmpresaContratadaID");
            CreateIndex("dbo.Testes", "EmpresaContratanteID");
            AddForeignKey("dbo.Testes", "StatusTransacaoID", "dbo.StatusFluxoTransacao", "StatusID", cascadeDelete: true);
            AddForeignKey("dbo.Testes", "TipoServicoID", "dbo.Servicos", "ServicoID", cascadeDelete: true);
            AddForeignKey("dbo.Testes", "EmpresaContratanteID", "dbo.Empresas", "EmpresaID", cascadeDelete: true);
            AddForeignKey("dbo.Testes", "EmpresaContratadaID", "dbo.Empresas", "EmpresaID", cascadeDelete: true);
        }
    }
}
