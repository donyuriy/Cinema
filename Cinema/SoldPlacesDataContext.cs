using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class SoldPlacesDataContext : DbContext
    {
        public SoldPlacesDataContext()
            : base("CinemaDB")
        {       }

        public DbSet<ShTime> STime { get; set; }
        public DbSet<CinemaHall> CHall { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<SoldPlaces> SPlaces { get; set; }

    }
}
