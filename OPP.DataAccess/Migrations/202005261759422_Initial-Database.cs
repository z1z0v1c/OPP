namespace OPP.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proizvodjac", "JMBG", c => c.String());
            AlterColumn("dbo.Proizvodjac", "BPG", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proizvodjac", "BPG", c => c.String(maxLength: 12));
            AlterColumn("dbo.Proizvodjac", "JMBG", c => c.String(maxLength: 13));
        }
    }
}
