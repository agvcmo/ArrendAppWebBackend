namespace AppArrend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ruta = c.String(),
                        Tipo = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        Arrendatario_Id = c.Int(),
                        Contrato_Id = c.Int(),
                        Inmueble_Id = c.Int(),
                        Pago_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Arrendatario_Id)
                .ForeignKey("dbo.Contratoes", t => t.Contrato_Id)
                .ForeignKey("dbo.Inmuebles", t => t.Inmueble_Id)
                .ForeignKey("dbo.Pagoes", t => t.Pago_Id)
                .Index(t => t.Arrendatario_Id)
                .Index(t => t.Contrato_Id)
                .Index(t => t.Inmueble_Id)
                .Index(t => t.Pago_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        SegundoApellido = c.String(),
                        NombreUsuario = c.String(),
                        Clave = c.String(),
                        Telefono = c.String(),
                        Celular = c.String(),
                        Direccion = c.String(),
                        Correo = c.String(),
                        Edad = c.Int(nullable: false),
                        Genero = c.Int(nullable: false),
                        Tipo = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Inmueble_Id = c.Int(),
                        Pago_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inmuebles", t => t.Inmueble_Id)
                .ForeignKey("dbo.Pagoes", t => t.Pago_Id)
                .Index(t => t.Inmueble_Id)
                .Index(t => t.Pago_Id);
            
            CreateTable(
                "dbo.Contratoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Habitacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Armario = c.Int(nullable: false),
                        baño = c.Boolean(nullable: false),
                        Inmueble_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inmuebles", t => t.Inmueble_Id)
                .Index(t => t.Inmueble_Id);
            
            CreateTable(
                "dbo.Inmuebles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Tipo = c.Int(nullable: false),
                        BañosComunes = c.Int(nullable: false),
                        Area = c.Double(nullable: false),
                        Estrato = c.Int(nullable: false),
                        Precio = c.Single(nullable: false),
                        Patio = c.Boolean(nullable: false),
                        Parqueadero = c.Boolean(nullable: false),
                        Lavadero = c.Int(nullable: false),
                        Comedor = c.Boolean(nullable: false),
                        SalaComedor = c.Boolean(nullable: false),
                        Sala = c.Boolean(nullable: false),
                        ContratoInmuebleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contratoes", t => t.ContratoInmuebleID, cascadeDelete: true)
                .Index(t => t.ContratoInmuebleID);
            
            CreateTable(
                "dbo.Novedads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pagoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        MedioDePago = c.Int(nullable: false),
                        InmueblePagoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inmuebles", t => t.InmueblePagoID, cascadeDelete: true)
                .Index(t => t.InmueblePagoID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Pagoes", "InmueblePagoID", "dbo.Inmuebles");
            DropForeignKey("dbo.Usuarios", "Pago_Id", "dbo.Pagoes");
            DropForeignKey("dbo.Archivoes", "Pago_Id", "dbo.Pagoes");
            DropForeignKey("dbo.Usuarios", "Inmueble_Id", "dbo.Inmuebles");
            DropForeignKey("dbo.Habitacions", "Inmueble_Id", "dbo.Inmuebles");
            DropForeignKey("dbo.Inmuebles", "ContratoInmuebleID", "dbo.Contratoes");
            DropForeignKey("dbo.Archivoes", "Inmueble_Id", "dbo.Inmuebles");
            DropForeignKey("dbo.Archivoes", "Contrato_Id", "dbo.Contratoes");
            DropForeignKey("dbo.Archivoes", "Arrendatario_Id", "dbo.Usuarios");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pagoes", new[] { "InmueblePagoID" });
            DropIndex("dbo.Inmuebles", new[] { "ContratoInmuebleID" });
            DropIndex("dbo.Habitacions", new[] { "Inmueble_Id" });
            DropIndex("dbo.Usuarios", new[] { "Pago_Id" });
            DropIndex("dbo.Usuarios", new[] { "Inmueble_Id" });
            DropIndex("dbo.Archivoes", new[] { "Pago_Id" });
            DropIndex("dbo.Archivoes", new[] { "Inmueble_Id" });
            DropIndex("dbo.Archivoes", new[] { "Contrato_Id" });
            DropIndex("dbo.Archivoes", new[] { "Arrendatario_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pagoes");
            DropTable("dbo.Novedads");
            DropTable("dbo.Inmuebles");
            DropTable("dbo.Habitacions");
            DropTable("dbo.Contratoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Archivoes");
        }
    }
}
