using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AppArrend.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

        public System.Data.Entity.DbSet<Modelo.Modelo.Archivo> Archivos { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Habitacion> Habitaciones { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Novedad> Novedades { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Usuario> Usuarios { get; set; }        

        public System.Data.Entity.DbSet<Modelo.Modelo.Contrato> Contratos { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Inmueble> Inmuebles { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Pago> Pagos { get; set; }
    }
}