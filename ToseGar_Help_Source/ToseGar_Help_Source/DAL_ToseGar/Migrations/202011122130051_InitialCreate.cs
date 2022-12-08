namespace DAL_ToseGar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chart_Sell_BE",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Sell = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Human_Picture",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HCode = c.String(),
                        PictureAddress = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Human_Picture");
            DropTable("dbo.Chart_Sell_BE");
        }
    }
}
