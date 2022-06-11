using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KisKonyvtarNyilvantartas01.Models;

namespace KisKonyvtarNyilvantartas01.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KisKonyvtarNyilvantartas01.Models.Konyvek> Konyvek { get; set; }
    }
}
