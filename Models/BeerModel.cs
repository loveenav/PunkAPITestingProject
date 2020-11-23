using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunkAPITest.Models
{
    public class BeerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Abv { get; set; }
        public DateTime FirstBrewed {get; set;}

    }
}
