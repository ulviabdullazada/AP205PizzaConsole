﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMizza.Models
{
    class PizzaIngredient
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        public Pizza Pizza { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
