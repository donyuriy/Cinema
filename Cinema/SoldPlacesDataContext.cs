using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class SoldPlacesDataContext : DbContext
    {
        public SoldPlacesDataContext()
            : base("CinemaDB")
        {       }
        public DbSet Tickets { get; set; }
    }
}
