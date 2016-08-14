namespace SalesForceWeb.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesForceWeb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Hora", c => c.String(maxLength: 5, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Hora");
        }

        
    }
}
