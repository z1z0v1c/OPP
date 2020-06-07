using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP.Model
{
    public class VrstaProizvoda
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Naziv { get; set; }
    }
}
