namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_5 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.DebitoEmpresaID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaID, cascadeDelete: true)
                .ForeignKey("dbo.Transacoes", t => t.TransacaoID, cascadeDelete: true)
                .Index(t => t.EmpresaID)
                .Index(t => t.TransacaoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DebitoEmpresas", "TransacaoID", "dbo.Transacoes");
            DropForeignKey("dbo.DebitoEmpresas", "EmpresaID", "dbo.Empresas");
            DropIndex("dbo.DebitoEmpresas", new[] { "TransacaoID" });
            DropIndex("dbo.DebitoEmpresas", new[] { "EmpresaID" });
            DropTable("dbo.DebitoEmpresas");
        }
    }
}
