using OPP.DataAccess;
using OPP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP.UI.Data.Lookup
{
    class PregledDataService : IPregledProizvodjacDataService, IPregledVrstaProizvodaDataService
    {
        private Func<OPPDbContext> _contextCreator;

        public PregledDataService(Func<OPPDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<Pregled>> GetPregledProizvodjacaAsync()
        {
            using (var context = _contextCreator())
            {
                return await context.Proizvodjaci.AsNoTracking().
                     Select(p =>
                     new Pregled
                     {
                         Id = p.Id,
                         DisplayMember = p.Prezime + " " + p.Ime
                     }).OrderBy(p => p.DisplayMember).ToListAsync();
            }
        }

        public async Task<IEnumerable<Pregled>> GetPregledVrstaProizvodaAsync()
        {
            using (var context = _contextCreator())
            {
                return await context.VrsteProizvoda.AsNoTracking().
                     Select(v =>
                     new Pregled
                     {
                         Id = v.Id,
                         DisplayMember = v.Naziv
                     }).OrderBy(v => v.DisplayMember).ToListAsync();
            }
        }
    }
}
