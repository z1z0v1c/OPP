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
    public class ProizvodjacViewModel : ViewModelBase, IProizvodjacViewModel
    {
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;
        private Func<IProizvodjacItemViewModel> _proizvodjacItemViewModelCreator;
        private IProizvodjacItemViewModel _proizvodjacItemViewModel;

        public ProizvodjacViewModel(INavigationViewModel navigationViewModel,
            Func<IProizvodjacItemViewModel> proizvodjacItemViewModelCreator,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _proizvodjacItemViewModelCreator = proizvodjacItemViewModelCreator;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;

            _eventAggregator.GetEvent<OpenProizvodjacItemViewEvent>()
            .Subscribe(OnOpenProizvodjacItemView);
            _eventAggregator.GetEvent<AfterProizvodjacRemovedEvent>()
            .Subscribe(OnRemoveProizvodjacView);

            NavigationViewModel = navigationViewModel;
            CreateNewProizvodjacCommand = new DelegateCommand(OnCreateNewProizvodjacExecute);
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        private async void OnOpenProizvodjacItemView(int? proizvodjacId)
        {
            if (ProizvodjacItemViewModel != null && ProizvodjacItemViewModel.HasChanges)
            {
                var result = _messageDialogService.ShowOKCancelDialog("Унели сте измене. Да ли желите да напустите страницу?", "Упозорење");
                if (result == MessageDialogResult.Cancel)
                {
                    return;
                }
            }
            ProizvodjacItemViewModel = _proizvodjacItemViewModelCreator();
            await ProizvodjacItemViewModel.LoadProizvodjacAsync(proizvodjacId);
        }

        public INavigationViewModel NavigationViewModel { get; }

        public IProizvodjacItemViewModel ProizvodjacItemViewModel
        {
            get { return _proizvodjacItemViewModel; }
            private set
            {
                _proizvodjacItemViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateNewProizvodjacCommand { get; }

        private void OnCreateNewProizvodjacExecute()
        {
            OnOpenProizvodjacItemView(null);
        }

        private void OnRemoveProizvodjacView(int obj)
        {
            ProizvodjacItemViewModel = null;
        }
    }
}
