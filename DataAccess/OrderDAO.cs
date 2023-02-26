using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

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

        public OrderDTO GetOrderById(int orderId)
        {
            OrderDTO order = null;
            try
            {
                var myStockDB = new ManagementDBContext();
                order = myStockDB.Orders.SingleOrDefault(car => car.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void AddNew(OrderDTO order)
        {
            try
            {
                OrderDTO _order = GetOrderById(order.OrderId);
                if (_order == null)
                {
                    var myStockDB = new ManagementDBContext();
                    myStockDB.Orders.Add(order);
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

        public void Update(OrderDTO order)
        {
            try
            {
                OrderDTO _order = GetOrderById(order.OrderId);
                if (_order != null)
                {
                    var myStockDB = new ManagementDBContext();
                    myStockDB.Entry<OrderDTO>(order).State = EntityState.Modified;
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

        public void Delete(OrderDTO order)
        {
            try
            {
                OrderDTO _order = GetOrderById(order.OrderId);
                if (_order != null)
                {
                    var myStockDB = new ManagementDBContext();
                    myStockDB.Orders.Remove(order);
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
    }
}
