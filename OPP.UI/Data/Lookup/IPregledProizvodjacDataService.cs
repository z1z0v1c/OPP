﻿using OPP.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OPP.UI.Data.Lookup
{
    public interface IPregledProizvodjacDataService
    {
        Task<IEnumerable<Pregled>> GetPregledProizvodjacaAsync();
    }
}