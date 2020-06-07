using Prism.Events;

namespace OPP.UI.Event
{
    public class AfterVrstaProizvodaSavedEvent : PubSubEvent<AfterVrstaProizvodaSavedEventArgs>
    {
    }

    public class AfterVrstaProizvodaSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}