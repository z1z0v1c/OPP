using OPP.Model;
using OPP.UI.Data.Repozitory;
using OPP.UI.Event;
using OPP.UI.View.MessageDialogService;
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
        private IProizvodjacRepozitory _proizvodjacRepozitory;
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;
        private ProizvodjacWrapper _proizvodjac;
        private bool _hasChanges;

        public ProizvodjacViewModel(IProizvodjacRepozitory proizvodjacRepozitory,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _proizvodjacRepozitory = proizvodjacRepozitory;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            RemoveCommand = new DelegateCommand(OnRemoveExecute);           
        }

        public async Task LoadProizvodjacAsync(int? proizvodjacId)
        {
            var proizvodjac = proizvodjacId.HasValue
                ? await _proizvodjacRepozitory.GetProizvodjacByIdAsync(proizvodjacId.Value)
                : CreateNewProizvodjac();
            Proizvodjac = new ProizvodjacWrapper(proizvodjac);
            Proizvodjac.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _proizvodjacRepozitory.HasChanges();
                }
                if (e.PropertyName == nameof(Proizvodjac.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }                
            };
        ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            //Little trick to trigger validation
            if(Proizvodjac.Id == 0)
            {
                Proizvodjac.Ime = "";
                Proizvodjac.Prezime = "";
                Proizvodjac.Adresa = "";
            }
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

        public bool HasChanges
        {
            get { return _hasChanges; }
            set 
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand RemoveCommand { get; }

        private async void OnSaveExecute()
        {
            await _proizvodjacRepozitory.SaveAsync();
            HasChanges = _proizvodjacRepozitory.HasChanges();
            _eventAggregator.GetEvent<AfterProizvodjacSavedEvent>().Publish(
                new AfterProizvodjacSavedEventArgs
                {
                    Id = Proizvodjac.Id,
                    DisplayMember = $"{Proizvodjac.Ime} {Proizvodjac.Prezime}"
                }) ;
        }

        private bool OnSaveCanExecute()
        {
            return Proizvodjac != null && !Proizvodjac.HasErrors && HasChanges;
        }

        private async void OnRemoveExecute()
        {
            var result = _messageDialogService.ShowOKCancelDialog(
                $"Да ли сте сигурни да желите да обришете произвођача {Proizvodjac.Ime} {Proizvodjac.Prezime}?",
                "Упозорење");

            if (result == MessageDialogResult.OK)
            {
                _proizvodjacRepozitory.Remove(Proizvodjac.Model);
                await _proizvodjacRepozitory.SaveAsync();
                _eventAggregator.GetEvent<AfterProizvodjacRemovedEvent>().Publish(Proizvodjac.Id);
            }
        }

        private Proizvodjac CreateNewProizvodjac()
        {
            var proizvodjac = new Proizvodjac();
            _proizvodjacRepozitory.Add(proizvodjac);
            return proizvodjac;
        }
    }
}
