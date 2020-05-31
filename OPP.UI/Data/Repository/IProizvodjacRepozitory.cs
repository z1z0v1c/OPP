using OPP.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPP.UI.Data.Repozitory
{
    public interface IProizvodjacRepozitory
    {
        Task<List<Proizvodjac>> GetAllAsync();
        Task<Proizvodjac> GetProizvodjacByIdAsync(int? proizvodjacId);
        Task SaveAsync();
        bool HasChanges();
        void Add(Proizvodjac proizvodjac);
        void Remove(Proizvodjac proizvodjac);
    }
}