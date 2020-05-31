using OPP.Model;
using System;
using System.Text;
using System.Threading.Tasks;

namespace OPP.UI.Wrapper
{
    public class ProizvodjacWrapper : ModelWrapper<Proizvodjac>
    {
        public ProizvodjacWrapper(Proizvodjac model) : base(model)
        {
        }

        public int Id { get { return Model.Id; } }

        public string Ime
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
                ValidateProperty(nameof(Ime));
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(Ime):
                    if (string.IsNullOrEmpty(Ime))
                    {
                        AddError(nameof(Ime), "Нисте унели исправну вредност за поље Име!");
                    }
                    break;
                case nameof(Prezime):
                    if (string.IsNullOrEmpty(Prezime))
                    {
                        AddError(nameof(Prezime), "Нисте унели исправну вредност за поље Презиме!");
                    }
                    break;
            }
        }

        public string Prezime
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
                ValidateProperty(nameof(Prezime));
            }
        }

        public string Adresa
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string JMBG
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string BPG
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
