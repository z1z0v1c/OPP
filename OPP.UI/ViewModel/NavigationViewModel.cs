using OPP.Model;
using OPP.UI.Data;
using OPP.UI.Data.Lookup;
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
        private NavigationItemViewModel _izabraniProizvodjac;

        public NavigationViewModel(IPregledProizvodjacDataService pregledProizvodjacDataService,
            IEventAggregator eventAggregator)
        {
            _pregledProizvodjacDataService = pregledProizvodjacDataService;
            _eventAggregator = eventAggregator;
            Proizvodjaci = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterProizvodjacSavedEvent>().Subscribe(AfeterProizvodjacSaved);
            _eventAggregator.GetEvent<AfterProizvodjacRemovedEvent>().Subscribe(AfeterProizvodjacRemoved);
           
        }

        public async Task LoadAsync()
        {
            var pregledProizvodjaca = await _pregledProizvodjacDataService.GetPregledProizvodjacaAsync();
            //Proizvodjaci.Clear();
            foreach (var item in pregledProizvodjaca)
            {
                Proizvodjaci.Add(new NavigationItemViewModel(item.Id, item.DisplayMember, _eventAggregator));
            }
        }



        public ObservableCollection<NavigationItemViewModel> Proizvodjaci { get; }

        public NavigationItemViewModel IzabraniProizvodjac
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

        private void AfeterProizvodjacSaved(AfterProizvodjacSavedEventArgs obj)
        {
            var pregledProizvodjaca = Proizvodjaci.SingleOrDefault(p => p.Id == obj.Id);
            if (pregledProizvodjaca == null)
            {
                Proizvodjaci.Add(new NavigationItemViewModel(obj.Id, obj.DisplayMember, _eventAggregator));
            }
            else
            {
                pregledProizvodjaca.DisplayMember = obj.DisplayMember;
            }
        }

        private void AfeterProizvodjacRemoved(int obj)
        {
            var pregledProizvodjaca = Proizvodjaci.SingleOrDefault(p => p.Id == obj);
            if (pregledProizvodjaca != null)
            {
                Proizvodjaci.Remove(pregledProizvodjaca);
            }
        }
    }
}
