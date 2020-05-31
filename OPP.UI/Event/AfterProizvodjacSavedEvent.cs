using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP.UI.Event
{
    public class AfterProizvodjacSavedEvent : PubSubEvent<AfterProizvodjacSavedEventArgs>
    {
    }

    public class AfterProizvodjacSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
