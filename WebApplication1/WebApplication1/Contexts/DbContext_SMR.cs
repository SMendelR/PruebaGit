using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Contexts
{
    public class DbContext_SMR: DbContext
    {
        public DbSet<Persona> TablaPersona { get; set; }
        public DbContext_SMR(DbContextOptions<DbContext_SMR> options)
            : base(options)
        {

        }
    }
}
