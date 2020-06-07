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
            OpenProizvodjacItemViewCommand = new DelegateCommand(OnOpenProizvodjacItemView);
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

        public ICommand OpenProizvodjacItemViewCommand { get; }

        private void OnOpenProizvodjacItemView()
        {
            _eventAggregator.GetEvent<OpenProizvodjacItemViewEvent>()
                        .Publish(Id);
        }
    }
}
