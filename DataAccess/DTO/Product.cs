using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public Decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }

        public Product() { }

        public Product(int productId, int categoryId, string productName, string weight, decimal unitPrice, int unitInStock)
        {
            ProductId = productId;
            CategoryId = categoryId;
            ProductName = productName;
            Weight = weight;
            UnitPrice = unitPrice;
            UnitInStock = unitInStock;
        }
    }
}
