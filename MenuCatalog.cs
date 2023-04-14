using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace UML2
{
    public class MenuCatalog
    {
        List<Pizza> _pizzas;

        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();


        }
        public void Create(Pizza p)
        {

            _pizzas.Add(p);
        }


        public void PrintMenu()
        {
            foreach (var p in _pizzas)
            {
                Console.WriteLine(p);
                Console.WriteLine("_________________");
            }
        }

        public Pizza read(int number)
        { 
            return _pizzas[number-1];
        }

        public Pizza Searchpizza(string criteria)
        {
            foreach (var p in _pizzas)
            { 
                if(p.Name.ToLower() == criteria.ToLower())
                    return p;
            }
            return null;
        }

        public void Update(Pizza pizza)
        {
            foreach (var p in _pizzas)
            {
                if (p.Number == pizza.Number)
                { 
                    p.Name= pizza.Name;
                    p.Price= pizza.Price;
                    return;
                }
            }
        }

        public void Delete(Pizza pizza)
        {
            foreach (var p in _pizzas)
            {
                if (p.Number == pizza.Number)
                {
                    pizza = p;
                    break;

                }
            }
            _pizzas.Remove(pizza);
        }
        

    
    }
}