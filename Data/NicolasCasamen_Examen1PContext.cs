using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NicolasCasamen_Examen1P.Models;

namespace NicolasCasamen_Examen1P.Data
{
    public class NicolasCasamen_Examen1PContext : DbContext
    {
        public NicolasCasamen_Examen1PContext (DbContextOptions<NicolasCasamen_Examen1PContext> options)
            : base(options)
        {
        }

        public DbSet<NicolasCasamen_Examen1P.Models.NC_Cine> NC_Cine { get; set; } = default!;
    }
}
