using OPP.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPP.UI.Data.Repository
{
    public interface IVrstaProizvodaRepository
    {
        void Add(VrstaProizvoda vrstaProizvoda);
        Task<List<VrstaProizvoda>> GetAllAsync();
        Task<VrstaProizvoda> GetVrstaProizvodaByIdAsync(int? vrstaProizvodaId);
        bool HasChanges();
        void Remove(VrstaProizvoda vrstaProizvoda);
        Task SaveAsync();
    }
}