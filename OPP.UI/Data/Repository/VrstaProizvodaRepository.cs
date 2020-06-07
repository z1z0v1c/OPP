using OPP.DataAccess;
using OPP.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OPP.UI.Data.Repository
{
    public class VrstaProizvodaRepository : IVrstaProizvodaRepository
    {
        private OPPDbContext _context;

        public VrstaProizvodaRepository(OPPDbContext context)
        {
            _context = context;
        }
        public async Task<List<VrstaProizvoda>> GetAllAsync()
        {
            return await _context.VrsteProizvoda.OrderByDescending(v => v.Naziv).ToListAsync();
        }

        public async Task<VrstaProizvoda> GetVrstaProizvodaByIdAsync(int? vrstaProizvodaId)
        {
            return await _context.VrsteProizvoda.SingleAsync(v => v.Id == vrstaProizvodaId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Add(VrstaProizvoda vrstaProizvoda)
        {
            _context.VrsteProizvoda.Add(vrstaProizvoda);
        }

        public void Remove(VrstaProizvoda vrstaProizvoda)
        {
            _context.VrsteProizvoda.Remove(vrstaProizvoda);
        }
    }
}
