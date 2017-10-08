namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false, identity: true),
                        CNPJ = c.Int(nullable: false),
                        RazaoSocial = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmpresaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empresas");
        }
    }
}
