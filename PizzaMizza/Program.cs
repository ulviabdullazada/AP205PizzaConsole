using Microsoft.EntityFrameworkCore;
using PizzaMizza.DAL;
using PizzaMizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaMizza
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Do you want Menu? Y/N");
            //if (Console.ReadLine().ToLower() == "y")
            //{
            //    Menu();
            //}
            UpdatePizza(3, "Salyan");
            GetAllPizzas();
        }
        public static void Menu()
        {
            GetAllPizzas();
            Console.WriteLine("Which pizza do you want? Enter its number :");
            int.TryParse(Console.ReadLine(), out int num);
            if (num > 0)
            {
                GetPizzaIngredients(num);
            }
            else
            {
                Console.WriteLine("0dan boyuk olmalidir");
                Menu();
            }
        }
        static void GetAllPizzas()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<Pizza> pizzas = sql.Pizzas.ToList();
                foreach (Pizza pizza in pizzas)
                {
                    Console.WriteLine($"{pizza.Id}. {pizza.Name}");
                }
            }
        }
        static void GetPizzaIngredients(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (sql.Pizzas.Any(p=>p.Id == id))
                {
                    Pizza pizza = sql.Pizzas.Include(p=> p.PizzaIngredients).ThenInclude(pi=>pi.Ingredient).SingleOrDefault(p=>p.Id == id);
                    string ingredients = "";
                    foreach (PizzaIngredient pi in pizza.PizzaIngredients)
                    {
                        ingredients += pi.Ingredient.Name + ", ";
                    }
                    if (ingredients.Length > 2)
                    {
                        Console.WriteLine(pizza.Name + " - " +ingredients.Substring(0,ingredients.Length-2));
                    }
                    else
                    {
                        Console.WriteLine(pizza.Name + " - " + ingredients);
                    }
                }
                else
                {
                    Console.WriteLine("Bele pizza yoxdu");
                    Menu();
                }
            }
        }
        static void UpdatePizza(int id, string name)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.Pizzas.Any(p => p.Id == id)) return;
                Pizza pizza = sql.Pizzas.SingleOrDefault(p=>p.Id == id);
                pizza.Name = name;
                sql.SaveChanges();
            }
        }
        static void UpdatePizzaPrice(int id,int size, double price)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.PizzaSizePrices.Any(p => p.PizzaId == id && p.SizeId == size)) return;
                PizzaSizePrice pizza = sql.PizzaSizePrices.SingleOrDefault(p => p.PizzaId == id && p.SizeId == size);
                pizza.Price = price;
                sql.SaveChanges();
            }
        }
        static void RemovePizza(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.Pizzas.Any(p => p.Id == id)) return;
                Pizza pizza = sql.Pizzas.SingleOrDefault(p => p.Id == id);
                sql.Remove(pizza);
                sql.SaveChanges();
            }
        }
    }
}
