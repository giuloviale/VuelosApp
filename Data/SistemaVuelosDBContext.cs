using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Data
{
    public class SistemaVuelosDBContext:DbContext
    {
        public SistemaVuelosDBContext() : base("KeyDB") { }

        public DbSet<Vuelo> vuelos { get; set; }
    }
}