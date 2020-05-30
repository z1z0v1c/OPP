using System.Threading.Tasks;

namespace OPP.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationViewModel navigationViewModel, IProizvodjacViewModel proizvodjacViewModel)
        {
            NavigationViewModel = navigationViewModel;
            ProizvodjacViewModel = proizvodjacViewModel;
        }



        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }
        public IProizvodjacViewModel ProizvodjacViewModel { get; }
    }
}
