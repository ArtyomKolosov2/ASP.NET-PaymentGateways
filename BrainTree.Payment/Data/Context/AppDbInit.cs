using BrainTree.Payment.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainTree.Payment.Data.Context
{
    public static class AppDbInit
    {
        public static async Task SeedCategoriesAsync(AppDbContext appDbContext)
        {
            if (!await appDbContext.Categories.AnyAsync())
            {
                var categories = new Category[]
                {
                    new Category { Name = "Tesla"},
                    new Category { Name = "Bmw"}
                };
                await appDbContext.Categories.AddRangeAsync(categories);
                await appDbContext.SaveChangesAsync();
            }
        }
        public static async Task SeedCarsAsync(AppDbContext appDbContext)
        {
            if (!await appDbContext.Cars.AnyAsync())
            {
                var cars = new Car[]
                {
                    new Car
                    {
                        CategoryId=1,
                        Name="Model Y",
                        Price=34000,
                        ImageURL="~/Images/car1.jpg",
                    },
                    new Car
                    {
                        CategoryId=1,
                        Name="Model X",
                        Price=30000,
                        ImageURL="~/Images/car3x.jpg",
                    },
                    new Car
                    {
                        CategoryId = 1,
                        Name = "Model Z",
                        Price = 35000,
                        ImageURL = "~/Images/car2.jpg",
                    },
                    new Car
                    {
                        CategoryId = 2,
                        Name = "E 39 Classic",
                        Price = 15000,
                        ImageURL = "~/Images/car4e39.jpg",
                    }
                };
                await appDbContext.Cars.AddRangeAsync(cars);                
                await appDbContext.SaveChangesAsync();
            }
            
        }
    }
}
