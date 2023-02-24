using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.test
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Order()
        {

        }

        public Order(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string? ToString()
        {
            return $"Id: {Id} - Name: {Name} - Desc: {Description}";
        }
    }
}
