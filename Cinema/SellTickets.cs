using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class SoldPlaces : DbContext
    {
        public SoldPlaces()
            : base("CinemaDB")
        {       }
        public DbSet Tickets { get; set; }
    }
}
