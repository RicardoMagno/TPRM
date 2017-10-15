using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TPRM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        

        public System.Data.Entity.DbSet<TPRM.Models.Servico> Servicos { get; set; }

        public System.Data.Entity.DbSet<TPRM.Models.Empresa> Empresas { get; set; }

        public System.Data.Entity.DbSet<TPRM.Models.StatusFluxoTransacao> StatusFluxoTransacoes { get; set; }
        
        public System.Data.Entity.DbSet<TPRM.Models.Transacao> Transacoes { get; set; }

        public System.Data.Entity.DbSet<TPRM.Models.UsuarioEmpresa> UsuarioEmpresas { get; set; }
        
        public System.Data.Entity.DbSet<TPRM.Models.DebitoCliente> DebitoClientes { get; set; }
        
    }
}