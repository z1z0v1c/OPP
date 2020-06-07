using System.Threading.Tasks;

namespace OPP.UI.ViewModel
{
    public interface IVrstaProizvodaItemViewModel
    {
        bool HasChanges { get; set; }

        Task LoadProizvodjacAsync(int? vrstaProizvodaId);
    }
}