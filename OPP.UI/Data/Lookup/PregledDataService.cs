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
    class PregledDataService : IPregledProizvodjacDataService
    {
        private Func<OPPDbContext> _contextCreator;

        public PregledDataService(Func<OPPDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<PregledProizvodjaca>> GetPregledProizvodjacaAsync()
        {
            using (var context = _contextCreator())
            {
                return await context.Proizvodjaci.AsNoTracking().
                     Select(p =>
                     new PregledProizvodjaca
                     {
                         Id = p.Id,
                         DisplayMember = p.Prezime + " " + p.Ime
                     }).OrderBy(p => p.DisplayMember).ToListAsync();
            }
        }
    }
}
