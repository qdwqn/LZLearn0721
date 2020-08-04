using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZLearn.Models
{
    public class MockNoodleRepository : INoodleRepository
    {
        private List<Noodles> _noodles;
        public MockNoodleRepository()
        {
            if (_noodles == null)
            {
                InitializeNoodle();
            }
        }

        private void InitializeNoodle()
        {
            _noodles = new List<Noodles>()
            {
                new Noodles { Id = 1, Name = "毛细", Price = 12, ShortDescription = "S1", LongDescription = "L1" },
                new Noodles { Id = 2, Name = "细", Price = 10, ShortDescription = "S2", LongDescription = "L2" },
                new Noodles { Id = 3, Name = "宽", Price = 19, ShortDescription = "S3", LongDescription = "L3" }

            };
        }
        public IEnumerable<Noodles> GetAllNoodles()
        {
            return _noodles;
        }

        public Noodles GetNoodleById(int id)
        {
            return _noodles.FirstOrDefault(n => n.Id == id);
        }

        //NoodlsRepository现在已经完成，但是在项目的不同位置我们都有可能会使用到，所以
        //我们需要把他注入到系统的依赖注入容器中
    }
}
