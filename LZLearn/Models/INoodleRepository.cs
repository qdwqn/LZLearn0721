using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZLearn.Models
{
    public interface INoodleRepository
    {
        IEnumerable<Noodles> GetAllNoodles();
        Noodles GetNoodleById(int id);
    }
}
