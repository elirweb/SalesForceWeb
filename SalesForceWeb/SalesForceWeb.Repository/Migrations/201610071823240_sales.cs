namespace SalesForceWeb.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sales : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Usuario", name: "Email_Endereco", newName: "Email");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Usuario", name: "Email", newName: "Email_Endereco");
        }
    }
}
