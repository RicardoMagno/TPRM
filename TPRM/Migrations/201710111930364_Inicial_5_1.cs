namespace TPRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial_5_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transacoes", "UsuarioID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transacoes", "UsuarioID");
            AddForeignKey("dbo.Transacoes", "UsuarioID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transacoes", "UsuarioID", "dbo.AspNetUsers");
            DropIndex("dbo.Transacoes", new[] { "UsuarioID" });
            DropColumn("dbo.Transacoes", "UsuarioID");
        }
    }
}
