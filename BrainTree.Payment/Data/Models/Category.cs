using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainTree.Payment.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Car> Models { get; set; }
    }
}
