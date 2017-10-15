namespace TPRM.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TPRM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TPRM.Models.ApplicationDbContext";
        }

        protected override void Seed(TPRM.Models.ApplicationDbContext context)
        {
            ////// 1° Bloco a ser executado
            //context.Roles.AddOrUpdate(r => r.Name,
            //    new IdentityRole { Name = "Admin" },
            //    new IdentityRole { Name = "Cliente" },
            //    new IdentityRole { Name = "Analista" });

            //context.Empresas.AddOrUpdate(
            //  e => e.CNPJ,
            //  new Empresa { CNPJ = "19.288.322/0001-43", RazaoSocial = "TPRM" }
            //);

            //context.Users.AddOrUpdate(u => u.Email,
            //    new ApplicationUser
            //    {
            //        Id = "39ae9b6d-ff30-4dd9-bbfa-bedcf10a2ad8",
            //        Email = "adm@email.com",
            //        PasswordHash = "AE+TOBtYUytn7wUPY3/Qc3T0apLm+SoJUmeVTKBQFI2GGqCX6YrqVl2cfQi0jHWiHQ==", // Pass@123
            //        UserName = "Adm"
            //    });
            ////// Fim 1° Bloco


            ////// 2° Bloco a ser executado
            //var store = new UserStore<ApplicationUser>(context);
            //var manager = new UserManager<ApplicationUser>(store);
            //manager.AddToRole("39ae9b6d-ff30-4dd9-bbfa-bedcf10a2ad8", "Admin");

            //var empresa = context.Empresas.First();
            //context.UsuarioEmpresas.AddOrUpdate(ue => ue.ApplicationUserID,
            //    new UsuarioEmpresa { ApplicationUserID = "39ae9b6d-ff30-4dd9-bbfa-bedcf10a2ad8", EmpresaID = empresa.EmpresaID });

            ////// Fim 2° Bloco

        }
    }
}
