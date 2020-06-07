using System.Threading.Tasks;

namespace OPP.UI.ViewModel
{
    public interface IProizvodjacItemViewModel
    {
        Task LoadProizvodjacAsync(int? proizvodjacId);
        bool HasChanges { get; }
    }
}