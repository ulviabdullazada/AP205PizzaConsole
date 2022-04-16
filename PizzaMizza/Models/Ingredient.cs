using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMizza.Models
{
    class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
