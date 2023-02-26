using DataAccess.DTO;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void Delete(OrderDTO item) => OrderDAO.Instance.Delete(item);

        public IEnumerable<OrderDTO> GetList() => OrderDAO.Instance.GetOrderList();

        public void Insert(OrderDTO item) => OrderDAO.Instance.AddNew(item);

        public void Update(OrderDTO item) => OrderDAO.Instance.Update(item);
    }
}
