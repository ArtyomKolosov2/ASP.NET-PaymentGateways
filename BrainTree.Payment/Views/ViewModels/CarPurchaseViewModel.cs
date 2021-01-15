using BrainTree.Payment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainTree.Payment.Views.ViewModels
{
    public class CarPurchaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public uint Price { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
        public string Nonce { get; set; }
    }
}
