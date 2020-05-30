using OPP.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPP.UI.Data
{
    public interface IPregledProizvodjacDataService
    {
        Task<IEnumerable<PregledProizvodjaca>> GetPregledProizvodjacaAsync();
    }
}