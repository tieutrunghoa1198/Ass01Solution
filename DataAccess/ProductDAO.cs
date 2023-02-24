using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();

        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ProductDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var myStockDB = new ManagementDBContext();
                products = myStockDB.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetProductByID(int productID)
        {
            Product product = null;
            try
            {
                var myStockDB = new ManagementDBContext();
                product = myStockDB.Products.SingleOrDefault(car => car.ProductId == productID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void AddNew(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product == null)
                {
                    var myStockDB = new ManagementDBContext();
                    myStockDB.Products.Add(product);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product != null)
                {
                    var myStockDB = new ManagementDBContext();
                    myStockDB.Entry<Product>(product).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product != null)
                {
                    var myStockDB = new ManagementDBContext();
                    myStockDB.Products.Remove(product);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
