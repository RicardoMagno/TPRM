namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_2_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servicos", "DisponibilidadeServico", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servicos", "DisponibilidadeServico", c => c.Boolean());
        }
    }
}
