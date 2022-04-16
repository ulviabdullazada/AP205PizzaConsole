using Microsoft.EntityFrameworkCore;
using PizzaMizza.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMizza.DAL
{
    class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ULVI;Database=PizzaMizza;Trusted_Connection=True;");
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public DbSet<PizzaSizePrice> PizzaSizePrices{ get; set; }
    }
}
