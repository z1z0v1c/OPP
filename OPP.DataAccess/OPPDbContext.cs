using OPP.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OPP.DataAccess
{
    public class OPPDbContext : DbContext
    {
        public OPPDbContext() : base("OPP")
        {

        }

        public DbSet<Proizvodjac> Proizvodjaci { get; set; }

        public DbSet<VrstaProizvoda> VrsteProizvoda { get; set; }

        public DbSet<Proizvod> Proizvodi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
