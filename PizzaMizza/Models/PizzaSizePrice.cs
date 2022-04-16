using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMizza.Models
{
    class PizzaSizePrice
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public double Price { get; set; }
        public Pizza Pizza { get; set; }
        public Size Size { get; set; }
    }
}
