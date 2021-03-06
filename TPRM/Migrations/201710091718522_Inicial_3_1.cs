namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_3_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transacoes",
                c => new
                    {
                        EmpresaContratanteID = c.Int(nullable: false),
                        EmpresaContratadaID = c.Int(nullable: false),
                        TipoServicoID = c.Int(nullable: false),
                        TransacaoID = c.Int(nullable: false, identity: true),
                        ValorTransacao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DescricaoTransacao = c.String(nullable: false, maxLength: 50),
                        StatusTransacaoID = c.Int(nullable: false),
                        Empresa_EmpresaID = c.Int(),
                        Empresa_EmpresaID1 = c.Int(),
                    })
                .PrimaryKey(t => t.TransacaoID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaContratadaID, cascadeDelete: false)
                .ForeignKey("dbo.Empresas", t => t.EmpresaContratanteID, cascadeDelete: false)
                .ForeignKey("dbo.Servicos", t => t.TipoServicoID, cascadeDelete: false)
                .ForeignKey("dbo.StatusFluxoTransacao", t => t.StatusTransacaoID, cascadeDelete: false)
                .ForeignKey("dbo.Empresas", t => t.Empresa_EmpresaID)
                .ForeignKey("dbo.Empresas", t => t.Empresa_EmpresaID1)
                .Index(t => t.EmpresaContratanteID)
                .Index(t => t.EmpresaContratadaID)
                .Index(t => t.TipoServicoID)
                .Index(t => t.StatusTransacaoID)
                .Index(t => t.Empresa_EmpresaID)
                .Index(t => t.Empresa_EmpresaID1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transacoes", "Empresa_EmpresaID1", "dbo.Empresas");
            DropForeignKey("dbo.Transacoes", "Empresa_EmpresaID", "dbo.Empresas");
            DropForeignKey("dbo.Transacoes", "StatusTransacaoID", "dbo.StatusFluxoTransacao");
            DropForeignKey("dbo.Transacoes", "TipoServicoID", "dbo.Servicos");
            DropForeignKey("dbo.Transacoes", "EmpresaContratanteID", "dbo.Empresas");
            DropForeignKey("dbo.Transacoes", "EmpresaContratadaID", "dbo.Empresas");
            DropIndex("dbo.Transacoes", new[] { "Empresa_EmpresaID1" });
            DropIndex("dbo.Transacoes", new[] { "Empresa_EmpresaID" });
            DropIndex("dbo.Transacoes", new[] { "StatusTransacaoID" });
            DropIndex("dbo.Transacoes", new[] { "TipoServicoID" });
            DropIndex("dbo.Transacoes", new[] { "EmpresaContratadaID" });
            DropIndex("dbo.Transacoes", new[] { "EmpresaContratanteID" });
            DropTable("dbo.Transacoes");
        }
    }
}
