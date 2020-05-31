using OPP.UI.Event;
using OPP.UI.View.MessageDialogService;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OPP.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;
        private Func<IProizvodjacViewModel> _proizvodjacViewModelCreator;
        private IProizvodjacViewModel _proizvodjacViewModel;

        public MainViewModel(INavigationViewModel navigationViewModel, 
            Func<IProizvodjacViewModel> proizvodjacViewModelCreator,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _proizvodjacViewModelCreator = proizvodjacViewModelCreator;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;

            _eventAggregator.GetEvent<OpenProizvodjacViewEvent>()
            .Subscribe(OnOpenProizvodjacView);
            _eventAggregator.GetEvent<AfterProizvodjacRemovedEvent>()
            .Subscribe(OnRemoveProizvodjacView);

            NavigationViewModel = navigationViewModel;
            CreateNewProizvodjacCommand = new DelegateCommand(OnCreateNewProizvodjacExecute);
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        private async void OnOpenProizvodjacView(int? proizvodjacId)
        {
            if(ProizvodjacViewModel != null && ProizvodjacViewModel.HasChanges)
            {
                var result = _messageDialogService.ShowOKCancelDialog("Унели сте измене. Да ли желите да напустите страницу?", "Упозорење");
                if(result == MessageDialogResult.Cancel)
                {
                    return;
                }
            }
            ProizvodjacViewModel = _proizvodjacViewModelCreator();
            await ProizvodjacViewModel.LoadProizvodjacAsync(proizvodjacId);
        }

        public INavigationViewModel NavigationViewModel { get; }

        public IProizvodjacViewModel ProizvodjacViewModel
        {
            get { return _proizvodjacViewModel; }
            private set 
            { 
                _proizvodjacViewModel = value;
                OnPropertyChanged(); 
            }
        }

        public ICommand CreateNewProizvodjacCommand { get; }

        private void OnCreateNewProizvodjacExecute()
        {
            OnOpenProizvodjacView(null);
        }

        private void OnRemoveProizvodjacView(int obj)
        {
            ProizvodjacViewModel = null;
        }
    }
}
