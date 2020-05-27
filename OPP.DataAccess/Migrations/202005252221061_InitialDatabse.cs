namespace OPP.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proizvodjac",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 25),
                        Prezime = c.String(nullable: false, maxLength: 25),
                        Adresa = c.String(nullable: false, maxLength: 50),
                        JMBG = c.String(maxLength: 13),
                        BPG = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proizvodjac");
        }
    }
}
