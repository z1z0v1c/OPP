using OPP.UI.Event;
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
    public class NavigationItemViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(int id, string displayMember,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Id = id;
            DisplayMember = displayMember;
            OpenProizvodjacViewCommand = new DelegateCommand(OnOpenProizvodjacView);
        }

        public int Id { get; }
        private string _displayMember;

        public string DisplayMember
        {
            get { return _displayMember; }
            set { 
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenProizvodjacViewCommand { get; }

        private void OnOpenProizvodjacView()
        {
            _eventAggregator.GetEvent<OpenProizvodjacViewEvent>()
                        .Publish(Id);
        }
    }
}
