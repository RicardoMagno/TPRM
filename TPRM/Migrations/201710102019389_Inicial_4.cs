namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioEmpresas",
                c => new
                    {
                        UsuarioEmpresaID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        EmpresaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioEmpresaID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaID, cascadeDelete: true)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.EmpresaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioEmpresas", "EmpresaID", "dbo.Empresas");
            DropForeignKey("dbo.UsuarioEmpresas", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.UsuarioEmpresas", new[] { "EmpresaID" });
            DropIndex("dbo.UsuarioEmpresas", new[] { "ApplicationUserID" });
            DropTable("dbo.UsuarioEmpresas");
        }
    }
}
