namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_3 : DbMigration
    {
        public override void Up()
        {            
            CreateTable(
                "dbo.StatusFluxoTransacao",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        DescricaoStatus = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.StatusID);
        }
        
        public override void Down()
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
                        Empresa_EmpresaID = c.Int(),
                        Empresa_EmpresaID1 = c.Int(),
                    })
                .PrimaryKey(t => t.TransacaoID);
            
            DropTable("dbo.StatusFluxoTransacao");
            CreateIndex("dbo.Transacoes", "Empresa_EmpresaID1");
            CreateIndex("dbo.Transacoes", "Empresa_EmpresaID");
            CreateIndex("dbo.Transacoes", "TipoServicoID");
            CreateIndex("dbo.Transacoes", "EmpresaContratadaID");
            CreateIndex("dbo.Transacoes", "EmpresaContratanteID");
            AddForeignKey("dbo.Transacoes", "Empresa_EmpresaID1", "dbo.Empresas", "EmpresaID");
            AddForeignKey("dbo.Transacoes", "Empresa_EmpresaID", "dbo.Empresas", "EmpresaID");
            AddForeignKey("dbo.Transacoes", "TipoServicoID", "dbo.Servicos", "ServicoID", cascadeDelete: true);
            AddForeignKey("dbo.Transacoes", "EmpresaContratanteID", "dbo.Empresas", "EmpresaID", cascadeDelete: true);
            AddForeignKey("dbo.Transacoes", "EmpresaContratadaID", "dbo.Empresas", "EmpresaID", cascadeDelete: true);
        }
    }
}
