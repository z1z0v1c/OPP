using OPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP.UI.Data
{
    public class ProizvodjacDataService : IProizvodjacDataService
    {
        public IEnumerable<Proizvodjac> GetAll()
        {
            //TODO: load from DB
            yield return new Proizvodjac { Ime = "Petar", Prezime = "Petrovic", JMBG = "212", BPG = "33", Adresa = "Dobrinja" };
            yield return new Proizvodjac { Ime = "Milos", Prezime = "Markovic", JMBG = "213", BPG = "34", Adresa = "Leusici" };
            yield return new Proizvodjac { Ime = "Ivan", Prezime = "Ilic", JMBG = "214", BPG = "35", Adresa = "Teocin" };
        }
    }
}
