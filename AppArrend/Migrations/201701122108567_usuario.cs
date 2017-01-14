namespace AppArrend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Archivoes", name: "Arrendatario_Id", newName: "Usuario_Id");
            RenameIndex(table: "dbo.Archivoes", name: "IX_Arrendatario_Id", newName: "IX_Usuario_Id");
            AlterColumn("dbo.Usuarios", "Tipo", c => c.Int(nullable: false));
            DropColumn("dbo.Usuarios", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Usuarios", "Tipo", c => c.Int());
            RenameIndex(table: "dbo.Archivoes", name: "IX_Usuario_Id", newName: "IX_Arrendatario_Id");
            RenameColumn(table: "dbo.Archivoes", name: "Usuario_Id", newName: "Arrendatario_Id");
        }
    }
}
