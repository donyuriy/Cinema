using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    [TableAttribute("ShowTime")]
    class ShTime
    {
        public int ShowTimeId { get; set; }
        public DateTime ShowTime { get; set; }
    }
}
