using OPP.Model;
using OPP.UI.Data;
using OPP.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP.UI.ViewModel
{
    class ProizvodjacViewModel : ViewModelBase, IProizvodjacViewModel
    {
        private IProizvodjacDataService _proizvodjacDataService;
        private IEventAggregator _eventAggregator;
        private Proizvodjac _proizvodjac;

        public ProizvodjacViewModel(IProizvodjacDataService proizvodjacDataService,
            IEventAggregator eventAggregator)
        {
            _proizvodjacDataService = proizvodjacDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenProizvodjacViewEvent>()
                .Subscribe(OnOpenProizvodjacView);
        }

        public async Task LoadProizvodjacAsync(int proizvodjacId)
        {
            Proizvodjac = await _proizvodjacDataService.GetProizvodjacByIdAsync(proizvodjacId);
            //Proizvodjaci.Clear();
        }

        private async void OnOpenProizvodjacView(int proizvodjacId)
        {
            await LoadProizvodjacAsync(proizvodjacId);
        }

        public Proizvodjac Proizvodjac
        {
            get { return _proizvodjac; }
            private set
            {
                _proizvodjac = value;
                OnPropertyChanged();
            }
        }
    }
}
