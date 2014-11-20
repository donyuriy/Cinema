using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    [TableAttribute("Movie")]
    class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDirector { get; set; }
    }
}
