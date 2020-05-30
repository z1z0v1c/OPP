using OPP.Model;
using OPP.UI.Data;
using OPP.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IPregledProizvodjacDataService _pregledProizvodjacDataService;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IPregledProizvodjacDataService pregledProizvodjacDataService,
            IEventAggregator eventAggregator)
        {
            _pregledProizvodjacDataService = pregledProizvodjacDataService;
            _eventAggregator = eventAggregator;
            Proizvodjaci = new ObservableCollection<PregledProizvodjaca>();
        }

        public async Task LoadAsync()
        {
            var pregledProizvodjaca = await _pregledProizvodjacDataService.GetPregledProizvodjacaAsync();
            //Proizvodjaci.Clear();
            foreach (var item in pregledProizvodjaca)
            {
                Proizvodjaci.Add(item);
            }
        }

        public ObservableCollection<PregledProizvodjaca> Proizvodjaci { get; }

        private PregledProizvodjaca _izabraniProizvodjac;

        public PregledProizvodjaca IzabraniProizvodjac
        {
            get { return _izabraniProizvodjac; }
            set {
                _izabraniProizvodjac = value;
                OnPropertyChanged();
                if(_izabraniProizvodjac != null)
                {
                    _eventAggregator.GetEvent<OpenProizvodjacViewEvent>()
                        .Publish(_izabraniProizvodjac.Id);
                }
            }
        }

    }
}
