namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_6_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DebitoEmpresas", "EmpresaID", "dbo.Empresas");
            DropForeignKey("dbo.DebitoEmpresas", "TransacaoID", "dbo.Transacoes");
            DropIndex("dbo.DebitoEmpresas", new[] { "EmpresaID" });
            DropIndex("dbo.DebitoEmpresas", new[] { "TransacaoID" });
            DropTable("dbo.DebitoEmpresas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DebitoEmpresas",
                c => new
                    {
                        DebitoEmpresaID = c.Int(nullable: false, identity: true),
                        EmpresaID = c.Int(nullable: false),
                        TransacaoID = c.Int(nullable: false),
                        ValorDebito = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DebitoEmpresaID);
            
            CreateIndex("dbo.DebitoEmpresas", "TransacaoID");
            CreateIndex("dbo.DebitoEmpresas", "EmpresaID");
            AddForeignKey("dbo.DebitoEmpresas", "TransacaoID", "dbo.Transacoes", "TransacaoID", cascadeDelete: true);
            AddForeignKey("dbo.DebitoEmpresas", "EmpresaID", "dbo.Empresas", "EmpresaID", cascadeDelete: true);
        }
    }
}
