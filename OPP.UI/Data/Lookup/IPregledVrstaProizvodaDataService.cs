using OPP.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPP.UI.Data.Lookup
{
    interface IPregledVrstaProizvodaDataService
    {
        Task<IEnumerable<Pregled>> GetPregledVrstaProizvodaAsync();
    }
}