namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_2_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Empresas", "CNPJ", c => c.String(nullable: false, maxLength: 18));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresas", "CNPJ", c => c.Int(nullable: false));
        }
    }
}
