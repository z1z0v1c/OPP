namespace OPP.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proizvodi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proizvod",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SortaProizvodaId = c.Int(nullable: false),
                        Cena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SortaProizvoda", t => t.SortaProizvodaId, cascadeDelete: true)
                .Index(t => t.SortaProizvodaId);
            
            CreateTable(
                "dbo.SortaProizvoda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VrstaProizvodaId = c.Int(nullable: false),
                        Naziv = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VrstaProizvoda", t => t.VrstaProizvodaId, cascadeDelete: true)
                .Index(t => t.VrstaProizvodaId);
            
            CreateTable(
                "dbo.VrstaProizvoda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proizvod", "SortaProizvodaId", "dbo.SortaProizvoda");
            DropForeignKey("dbo.SortaProizvoda", "VrstaProizvodaId", "dbo.VrstaProizvoda");
            DropIndex("dbo.SortaProizvoda", new[] { "VrstaProizvodaId" });
            DropIndex("dbo.Proizvod", new[] { "SortaProizvodaId" });
            DropTable("dbo.VrstaProizvoda");
            DropTable("dbo.SortaProizvoda");
            DropTable("dbo.Proizvod");
        }
    }
}
