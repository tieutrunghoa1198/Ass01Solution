using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Product() { }

        public Product(int id, string name) 
        {
            this.Id= id;
            this.Name= name;
        }

        public override string? ToString()
        {
            return $"Id: {Id} - Name: {Name}";
        }
    }
}
