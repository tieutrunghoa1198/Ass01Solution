﻿using DataAccess.DTO;
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

        public IEnumerable<ProductDTO> GetProductList()
        {
            List<ProductDTO> products;
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
    }
}
