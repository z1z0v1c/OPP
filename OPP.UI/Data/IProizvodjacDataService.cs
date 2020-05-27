using OPP.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPP.UI.Data
{
    public interface IProizvodjacDataService
    {
        Task<List<Proizvodjac>> GetAllAsync();
    }
}