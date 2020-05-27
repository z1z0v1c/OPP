using OPP.Model;
using OPP.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OPP.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IProizvodjacDataService _proizvodjacDataService;
        private Proizvodjac _izabraniProizvodjac;

        public MainViewModel(IProizvodjacDataService proizvodjacDataService)
        {
            Proizvodjaci = new ObservableCollection<Proizvodjac>();
            _proizvodjacDataService = proizvodjacDataService;
        }

        public async Task LoadAsync()
        {
            var proizvodjaci = await _proizvodjacDataService.GetAllAsync();
            Proizvodjaci.Clear();
            foreach(var proizvodjac in proizvodjaci)
            {
                Proizvodjaci.Add(proizvodjac);
            }
        }

        public ObservableCollection<Proizvodjac> Proizvodjaci { get; set; } 

        public Proizvodjac IzabraniProizvodjac
        {
            get { return _izabraniProizvodjac; }
            set 
            { 
                _izabraniProizvodjac = value;
                OnPropertyChanged();
            }
        }

        
    }
}
