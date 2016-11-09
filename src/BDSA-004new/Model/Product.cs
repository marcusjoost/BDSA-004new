using DesignPatterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    public class Product : IEntity
    {
        private static int _count = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }

        public Product(string name, double price, int quan, Category cat)
        {
            Id = ++_count;
            Name = name;
            Price = price;
            Quantity = quan;
            Category = cat;
        }

        public override string ToString()
        {
            return Name + ": " + Quantity;
        }
    }
}
