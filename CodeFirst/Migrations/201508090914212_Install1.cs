namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Install1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersInfo", "Id", "dbo.UsersRole");
            DropIndex("dbo.UsersInfo", new[] { "Id" });
            DropPrimaryKey("dbo.UsersInfo", new[] { "Id" });
            AddPrimaryKey("dbo.UsersInfo", "UserId");
            DropColumn("dbo.UsersInfo", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersInfo", "Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.UsersInfo", new[] { "UserId" });
            AddPrimaryKey("dbo.UsersInfo", "Id");
            CreateIndex("dbo.UsersInfo", "Id");
            AddForeignKey("dbo.UsersInfo", "Id", "dbo.UsersRole", "Id");
        }
    }
}
