namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Servicoes", newName: "Servicos");
            DropTable("dbo.Empresas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        CNPJ = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CNPJ);
            
            RenameTable(name: "dbo.Servicos", newName: "Servicoes");
        }
    }
}
