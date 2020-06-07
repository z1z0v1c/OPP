using OPP.Model;

namespace OPP.UI.Wrapper
{
    public class VrstaProizvodaWrapper : ModelWrapper<VrstaProizvoda>
    {
        public VrstaProizvodaWrapper(VrstaProizvoda model) : base(model)
        {
        }

        public int Id { get { return Model.Id; } }

        public string Naziv
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
                ValidateProperty(nameof(Naziv));
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(Naziv):
                    if (string.IsNullOrEmpty(Naziv))
                    {
                        AddError(nameof(Naziv), "Нисте унели исправну вредност за поље Име!");
                    }
                    break;
            }
        }
    }
}
