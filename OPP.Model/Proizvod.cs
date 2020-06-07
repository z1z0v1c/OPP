using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP.Model
{
    public class Proizvod
    {
        public int Id { set; get; }

        public int? VrstaProizvodaId { get; set; }

        [Required]
        public VrstaProizvoda VrstaProizvoda { set; get; }

        [Required]
        public double Cena { get; set; }
    }
}
