using OPP.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPP.UI.Data
{
    public interface IProizvodjacDataService
    {
        Task<List<Proizvodjac>> GetAllAsync();

        Task<Proizvodjac> GetProizvodjacByIdAsync(int proizvodjacId);

        Task SaveAsync(Proizvodjac proizvodjac);
    }
}