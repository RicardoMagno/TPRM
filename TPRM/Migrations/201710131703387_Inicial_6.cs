namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DebitoClientes",
                c => new
                    {
                        DebitoClienteID = c.Int(nullable: false, identity: true),
                        EmpresaID = c.Int(nullable: false),
                        TransacaoID = c.Int(nullable: false),
                        UsuarioID = c.String(maxLength: 128),
                        ValorDebito = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DebitoClienteID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaID, cascadeDelete: true)
                .ForeignKey("dbo.Transacoes", t => t.TransacaoID, cascadeDelete: true)
                .Index(t => t.EmpresaID)
                .Index(t => t.TransacaoID)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DebitoClientes", "TransacaoID", "dbo.Transacoes");
            DropForeignKey("dbo.DebitoClientes", "EmpresaID", "dbo.Empresas");
            DropForeignKey("dbo.DebitoClientes", "UsuarioID", "dbo.AspNetUsers");
            DropIndex("dbo.DebitoClientes", new[] { "UsuarioID" });
            DropIndex("dbo.DebitoClientes", new[] { "TransacaoID" });
            DropIndex("dbo.DebitoClientes", new[] { "EmpresaID" });
            DropTable("dbo.DebitoClientes");
        }
    }
}
