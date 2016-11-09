using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using DesignPatterns.Model;

namespace DesignPatterns
{
    public class Stock
    {
        private IData<Product> _productRepo;
        private IData<Category> _categoryRepo;

        public Stock(string filename)
        {
            _productRepo = new FlatFileInventory<Product>("products" + filename);
            _categoryRepo = new FlatFileInventory<Category>("categories" + filename);
        }

        //TODO : Add description ?
        public IEntity Add(string name, double price, int quantity, string cat)
        {
            IEnumerable<Category> categories = _categoryRepo.Read();
            Category category = categories.FirstOrDefault(c => c.Type == cat);
            if (category == null)
            {
                string desc = "";
                category = new Category(cat, desc);
                _categoryRepo.Create(category);
            }
            Product p = new Product(name, price, quantity, category);
            _productRepo.Create(p);
            return p;
        }

        public void DeleteCategory(int id)
        {
            try
            {
                var c = _categoryRepo.Read(id);
                _categoryRepo.Delete(c);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var p = _productRepo.Read(id);
                _productRepo.Delete(p);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void PrintInventory(int categoryId = 0)
        {
            if (categoryId == 0)
            {
                var items = _productRepo.Read();
                foreach (var i in items)
                    Console.WriteLine(i);
            }
            else
            {
                var items = _productRepo.Read().Where(p => p.Category.Id == categoryId);
                foreach (var i in items)
                    Console.WriteLine(i);
            }
        }

        public double CalculateStockWorth()
        {
            double sum = 0;
            foreach (var item in _productRepo.Read())
            {
                sum += (item.Price * item.Quantity);
            }
            return sum;
        }
    }
}
