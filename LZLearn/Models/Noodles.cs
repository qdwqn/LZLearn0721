using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZLearn.Models
{
    public class Noodles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public decimal Price { get; set; }
        public string ImageURL { get; set; }
    }
}
