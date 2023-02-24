using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new OrderDAO();
                }
                return instance;
            }
        }

        public IEnumerable<OrderDTO> GetOrderList()
        {
            List<OrderDTO> orders;
            try
            {
                var myStockDB = new ManagementDBContext();
                orders = myStockDB.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
    }
}
