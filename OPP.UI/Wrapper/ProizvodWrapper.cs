using OPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP.UI.Wrapper
{
    public class ProizvodWrapper : ModelWrapper<Proizvod>
    {
        public ProizvodWrapper(Proizvod model) : base(model)
        {
        }

        public int Id { get { return Model.Id; } }

        public int? VrstaProizvodaId { get { return Model.VrstaProizvodaId; } }

        public VrstaProizvoda VrstaProizvoda { get { return Model.VrstaProizvoda; } }

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
