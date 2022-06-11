using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisKonyvtarNyilvantartas01.Models
{
    public class KonyvKeres
    {
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public string Mufaj { get; set; }
        public List<Konyvek> KonyvLista { get; set; }
        public SelectList CimLista { get; set; }
        public SelectList MufajLista { get; set; }
    }
}
