using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    [TableAttribute("CinemaHall")]
    class CinemaHall
    {
        public int HallId { get; set; }
        public string HallName { get; set; }
    }
}
