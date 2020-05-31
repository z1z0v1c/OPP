using OPP.DataAccess;
using OPP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace OPP.UI.Data
{
    public class ProizvodjacDataService : IProizvodjacDataService
    {
        private Func<OPPDbContext> _contextCreator;

        public ProizvodjacDataService(Func<OPPDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        public async Task<List<Proizvodjac>> GetAllAsync()
        {
            //TODO: load from DB
            /*yield return new Proizvodjac { Ime = "Petar", Prezime = "Petrovic", JMBG = "212", BPG = "33", Adresa = "Dobrinja" };
            yield return new Proizvodjac { Ime = "Milos", Prezime = "Markovic", JMBG = "213", BPG = "34", Adresa = "Leusici" };
            yield return new Proizvodjac { Ime = "Ivan", Prezime = "Ilic", JMBG = "214", BPG = "35", Adresa = "Teocin" };*/

            using(var context = _contextCreator())
            {
                return await context.Proizvodjaci.AsNoTracking().ToListAsync();
            }
        }

        public async Task<Proizvodjac> GetProizvodjacByIdAsync(int proizvodjacId)
        {
            using (var context = _contextCreator())
            {
                return await context.Proizvodjaci.AsNoTracking().SingleAsync(p => p.Id == proizvodjacId);
            }
        }

        public async Task SaveAsync(Proizvodjac proizvodjac)
        {
            using (var context = _contextCreator())
            {
                context.Proizvodjaci.Attach(proizvodjac);
                context.Entry(proizvodjac).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
