using DataAccess.DTO;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void Delete(OrderDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetList() => OrderDAO.Instance.GetOrderList();

        public void Insert(OrderDTO item)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
