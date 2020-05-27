namespace OPP.DataAccess.Migrations
{
    using OPP.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OPP.DataAccess.OPPDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OPP.DataAccess.OPPDbContext context)
        {
            try
            {
                context.Proizvodjaci.AddOrUpdate(
                    p => p.Id,
                    new Proizvodjac { Id = 1, Ime = "Petar", Prezime = "Petrovic", JMBG = "1234567891012", BPG = "123456789101", Adresa = "Dobrinja" },
                    new Proizvodjac { Id = 2, Ime = "Milos", Prezime = "Markovic", JMBG = "1234567891013", BPG = "123456789102", Adresa = "Leusici" },
                    new Proizvodjac { Id = 3, Ime = "Ivan", Prezime = "Ilic", JMBG = "1234567891014", BPG = "1234567891013", Adresa = "Teocin" }
                    );
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
