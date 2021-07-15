using CVAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVAPI.Context
{
    public class CVContext : DbContext
    {
        public CVContext(DbContextOptions<CVContext> options)
            : base(options)
        {

        }
        public DbSet<InformacionP> InformacionP { get; set; }
        public DbSet<ExperienciaL> ExperienciaL { get; set; }
    }
}
