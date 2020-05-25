using OPP.Model;
using OPP.UI.Data;
using System.Collections.ObjectModel;

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

        public void Load()
        {
            var proizvodjaci = _proizvodjacDataService.GetAll();
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
