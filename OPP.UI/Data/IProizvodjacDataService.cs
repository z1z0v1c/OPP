using OPP.Model;
using System.Collections.Generic;

namespace OPP.UI.Data
{
    public interface IProizvodjacDataService
    {
        IEnumerable<Proizvodjac> GetAll();
    }
}