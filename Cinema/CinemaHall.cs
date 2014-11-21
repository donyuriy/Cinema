﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    [TableAttribute("CinemaHall")]
    class CinemaHall
    {
        [Key]
        public int CinemaHallId { get; set; }
        public string CinemaHallName { get; set; }
    }
}
