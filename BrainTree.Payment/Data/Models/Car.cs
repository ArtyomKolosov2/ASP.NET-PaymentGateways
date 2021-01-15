using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainTree.Payment.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
        public string Nonce { get; set; }
        public string ImageURL { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
