using OPP.Model;
using OPP.UI.Data;
using OPP.UI.Event;
using OPP.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OPP.UI.ViewModel
{
    class ProizvodjacViewModel : ViewModelBase, IProizvodjacViewModel
    {
        private IProizvodjacDataService _proizvodjacDataService;
        private IEventAggregator _eventAggregator;
        private ProizvodjacWrapper _proizvodjac;

        public ProizvodjacViewModel(IProizvodjacDataService proizvodjacDataService,
            IEventAggregator eventAggregator)
        {
            _proizvodjacDataService = proizvodjacDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenProizvodjacViewEvent>()
                .Subscribe(OnOpenProizvodjacView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public async Task LoadProizvodjacAsync(int proizvodjacId)
        {
            var proizvodjac = await _proizvodjacDataService.GetProizvodjacByIdAsync(proizvodjacId);
            Proizvodjac = new ProizvodjacWrapper(proizvodjac);
            //Proizvodjaci.Clear();
        }

        public ProizvodjacWrapper Proizvodjac
        {
            get { return _proizvodjac; }
            private set
            {
                _proizvodjac = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        private async void OnSaveExecute()
        {
            await _proizvodjacDataService.SaveAsync(Proizvodjac.Model);
            _eventAggregator.GetEvent<AfterProizvodjacSavedEvent>().Publish(
                new AfterProizvodjacSavedEventArgs
                {
                    Id = Proizvodjac.Id,
                    DisplayMember = $"{Proizvodjac.Ime} {Proizvodjac.Prezime}"
                }) ;
        }

        private bool OnSaveCanExecute()
        {
            //TODO
            return true;
        }

        private async void OnOpenProizvodjacView(int proizvodjacId)
        {
            await LoadProizvodjacAsync(proizvodjacId);
        }
    }
}
