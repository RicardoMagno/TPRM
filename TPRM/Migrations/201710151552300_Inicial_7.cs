namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servicos", "ValorServico", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servicos", "ValorServico", c => c.Double(nullable: false));
        }
    }
}
