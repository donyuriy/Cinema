using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    [TableAttribute("Movie")]
    class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int ShowTime { get; set; }
        public int Hall { get; set; }

    }
}
