using System.Collections.ObjectModel;
using BusinessObject.Factory;
using DataAccess.DTO;
using DataAccess.Repository;
namespace BusinessObject
{
    public class OrderObject : IDataGridFactory, ICRUD
    {
        public ObservableCollection<object> CreateCollection()
        {
            OrderRepository order = new OrderRepository();
            return new ObservableCollection<object>(order.GetList());
        }

        public void Delete(object product)
        {
            OrderDTO asdz = (OrderDTO)product;
            OrderRepository orderRepo = new OrderRepository();
            orderRepo.Delete(asdz);
        }
    }
}
