using System.ComponentModel.DataAnnotations;

namespace OPP.Model
{
    public class Proizvodjac
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(25)]
        public string Prezime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Adresa { get; set; }

       
        public string JMBG { get; set; }

        
        public string BPG { get; set; }
    }
}
