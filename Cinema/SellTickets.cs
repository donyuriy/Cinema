using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class SellTickets : DbContext
    {
        public SellTickets()
            : base("CinemaDB")
        {       }
        public DbSet Tickets { get; set; }
    }
}
