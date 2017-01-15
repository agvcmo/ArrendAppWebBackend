using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppArrendBackend.Models
{
    public class AppArrendContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AppArrendContext() : base("name=AppArrendContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public static AppArrendContext Create()
        {
            return new AppArrendContext();
        }

        public System.Data.Entity.DbSet<Modelo.Modelo.Archivo> Archivoes { get; set; }
        public System.Data.Entity.DbSet<Modelo.Modelo.Contrato> Contratoes { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Habitacion> Habitacions { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Inmueble> Inmuebles { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Novedad> Novedads { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Pago> Pagoes { get; set; }

        public System.Data.Entity.DbSet<Modelo.Modelo.Usuario> Usuarios { get; set; }
    }
}
