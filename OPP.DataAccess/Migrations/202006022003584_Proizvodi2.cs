namespace OPP.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proizvodi2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SortaProizvoda", "VrstaProizvodaId", "dbo.VrstaProizvoda");
            DropForeignKey("dbo.Proizvod", "SortaProizvodaId", "dbo.SortaProizvoda");
            DropIndex("dbo.Proizvod", new[] { "SortaProizvodaId" });
            DropIndex("dbo.SortaProizvoda", new[] { "VrstaProizvodaId" });
            AddColumn("dbo.Proizvod", "VrstaProizvodaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Proizvod", "VrstaProizvodaId");
            AddForeignKey("dbo.Proizvod", "VrstaProizvodaId", "dbo.VrstaProizvoda", "Id", cascadeDelete: true);
            DropColumn("dbo.Proizvod", "SortaProizvodaId");
            DropTable("dbo.SortaProizvoda");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SortaProizvoda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VrstaProizvodaId = c.Int(nullable: false),
                        Naziv = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Proizvod", "SortaProizvodaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Proizvod", "VrstaProizvodaId", "dbo.VrstaProizvoda");
            DropIndex("dbo.Proizvod", new[] { "VrstaProizvodaId" });
            DropColumn("dbo.Proizvod", "VrstaProizvodaId");
            CreateIndex("dbo.SortaProizvoda", "VrstaProizvodaId");
            CreateIndex("dbo.Proizvod", "SortaProizvodaId");
            AddForeignKey("dbo.Proizvod", "SortaProizvodaId", "dbo.SortaProizvoda", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SortaProizvoda", "VrstaProizvodaId", "dbo.VrstaProizvoda", "Id", cascadeDelete: true);
        }
    }
}
