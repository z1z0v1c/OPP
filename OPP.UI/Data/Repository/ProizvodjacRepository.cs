using OPP.DataAccess;
using OPP.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OPP.UI.Data.Repository
{
    public class ProizvodjacRepository : IProizvodjacRepository
    {
        private OPPDbContext _context;

        public ProizvodjacRepository(OPPDbContext context)
        {
            _context = context;
        }
        public async Task<List<Proizvodjac>> GetAllAsync()
        {
            //TODO: load from DB
            /*yield return new Proizvodjac { Ime = "Petar", Prezime = "Petrovic", JMBG = "212", BPG = "33", Adresa = "Dobrinja" };
            yield return new Proizvodjac { Ime = "Milos", Prezime = "Markovic", JMBG = "213", BPG = "34", Adresa = "Leusici" };
            yield return new Proizvodjac { Ime = "Ivan", Prezime = "Ilic", JMBG = "214", BPG = "35", Adresa = "Teocin" };*/

            return await _context.Proizvodjaci.OrderByDescending(p => p.Prezime).ToListAsync();
        }

        public async Task<Proizvodjac> GetProizvodjacByIdAsync(int? proizvodjacId)
        {
            return await _context.Proizvodjaci.SingleAsync(p => p.Id == proizvodjacId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Add(Proizvodjac proizvodjac)
        {
            _context.Proizvodjaci.Add(proizvodjac);
        }

        public void Remove(Proizvodjac proizvodjac)
        {
            _context.Proizvodjaci.Remove(proizvodjac);
        }
    }
}
