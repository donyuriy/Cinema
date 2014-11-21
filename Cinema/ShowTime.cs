﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    [TableAttribute("ShowTime")]
    class ShTime
    {
        [Key]
        public int ShowId { get; set; }
        public string ShowName { get; set; }
        //public int CinemaHall { get; set; }
        //public int Movie { get; set; }
        //public DateTime ShowTime { get; set; }
    }
}
