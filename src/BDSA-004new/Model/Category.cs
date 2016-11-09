using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    public class Category : IEntity
    {
        private static int _count = 0;
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public Category(string type, string description)
        {
            Id = ++_count;
            Type = type;
            Description = description;
        }
    }
}
