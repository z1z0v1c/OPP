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
    public class MainWindowViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private Func<IProizvodjacViewModel> _proizvodjacViewModelCreator;
        private IProizvodjacViewModel _proizvodjacViewModel;

        public MainWindowViewModel(Func<IProizvodjacViewModel> proizvodjacViewModelCreator,
            IProizvodjacViewModel proizvodjacViewModel,
            IEventAggregator eventAggregator)
        {
            _proizvodjacViewModelCreator = proizvodjacViewModelCreator;
            _proizvodjacViewModel = proizvodjacViewModel;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenProizvodjacViewEvent>()
            .Subscribe(OnOpenProizvodjacView);

            ProizvodjacViewModel = _proizvodjacViewModelCreator();
            OpenProizvodjacViewCommand = new DelegateCommand(OnOpenProizvodjacViewExecute);
        }

        private void OnOpenProizvodjacViewExecute()
        {
            OnOpenProizvodjacView(0);
        }

        public async Task LoadAsync()
        {
            await ProizvodjacViewModel.LoadAsync();
        }

        private void OnOpenProizvodjacView(int? proizvodjacId)
        {
            //if (ProizvodjacViewModel != null)
            //{
            //    var result = _messageDialogService.ShowOKCancelDialog("Унели сте измене. Да ли желите да напустите страницу?", "Упозорење");
            //    if (result == MessageDialogResult.Cancel)
            //    {
            //        return;
            //    }
            //}
            ProizvodjacViewModel = _proizvodjacViewModelCreator();
        }

        public IProizvodjacViewModel ProizvodjacViewModel
        {
            get { return _proizvodjacViewModel; }
            private set
            {
                _proizvodjacViewModel = value;
                //OnPropertyChanged();
            }
        }

        public DelegateCommand OpenProizvodjacViewCommand { get; }
    }
}
