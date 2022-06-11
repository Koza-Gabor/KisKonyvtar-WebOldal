using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KisKonyvtarNyilvantartas01.Models
{
    public class Konyvek
    {
        public int Id { get; set; }

        [Display(Name ="Cím")]
        [StringLength(60)]
        public string Cim { get; set; }
        
        [Display(Name ="Szerző")]
        [StringLength(60)]
        public string Szerzo { get; set; }
        
        [Display(Name ="Műfaj")]
        [StringLength(30)]
        public string Mufaj { get; set; }
        
        [Display(Name ="Beszerzési Ár")]
        [Column(TypeName="decimal(10,2)")]
        public decimal Ar { get; set; }
    }
}
