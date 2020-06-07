using OPP.Model;
using OPP.UI.Data.Repository;
using OPP.UI.Event;
using OPP.UI.View.MessageDialogService;
using OPP.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OPP.UI.ViewModel
{
    class VrstaProizvodaItemViewModel : ViewModelBase, IVrstaProizvodaItemViewModel
    {
        private IVrstaProizvodaRepository _vrstaProizvodaRepository;
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;
        private VrstaProizvodaWrapper _vrstaProizvoda;
        private bool _hasChanges;

        public VrstaProizvodaItemViewModel(IVrstaProizvodaRepository vrstaProizvodaRepository,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _vrstaProizvodaRepository = vrstaProizvodaRepository;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            RemoveCommand = new DelegateCommand(OnRemoveExecute);
        }

        public async Task LoadProizvodjacAsync(int? vrstaProizvodaId)
        {
            var vrstaProizvoda = vrstaProizvodaId.HasValue
                ? await _vrstaProizvodaRepository.GetVrstaProizvodaByIdAsync(vrstaProizvodaId.Value)
                : CreateNewVrstaProizvoda();
            VrstaProizvoda = new VrstaProizvodaWrapper(vrstaProizvoda);
            VrstaProizvoda.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _vrstaProizvodaRepository.HasChanges();
                }
                if (e.PropertyName == nameof(VrstaProizvoda.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

            //Little trick to trigger validation
            if (VrstaProizvoda.Id == 0)
            {
                VrstaProizvoda.Naziv = "";
            }
        }

        public VrstaProizvodaWrapper VrstaProizvoda
        {
            get { return _vrstaProizvoda; }
            private set
            {
                _vrstaProizvoda = value;
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
            await _vrstaProizvodaRepository.SaveAsync();
            HasChanges = _vrstaProizvodaRepository.HasChanges();
            _eventAggregator.GetEvent<AfterVrstaProizvodaSavedEvent>().Publish(
                new AfterVrstaProizvodaSavedEventArgs
                {
                    Id = VrstaProizvoda.Id,
                    DisplayMember = $"{VrstaProizvoda.Naziv}"
                });
        }

        private bool OnSaveCanExecute()
        {
            return VrstaProizvoda != null && !VrstaProizvoda.HasErrors && HasChanges;
        }

        private async void OnRemoveExecute()
        {
            var result = _messageDialogService.ShowOKCancelDialog(
                $"Да ли сте сигурни да желите да обришете производ {VrstaProizvoda.Naziv}?",
                "Упозорење");

            if (result == MessageDialogResult.OK)
            {
                _vrstaProizvodaRepository.Remove(VrstaProizvoda.Model);
                await _vrstaProizvodaRepository.SaveAsync();
                _eventAggregator.GetEvent<AfterVrstaProizvodaRemovedEvent>().Publish(VrstaProizvoda.Id);
            }
        }

        private VrstaProizvoda CreateNewVrstaProizvoda()
        {
            var vrstaProizvoda = new VrstaProizvoda();
            _vrstaProizvodaRepository.Add(vrstaProizvoda);
            return vrstaProizvoda;
        }
    }
}
