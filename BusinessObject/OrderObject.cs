using System.Collections.ObjectModel;
using BusinessObject.Factory;
using DataAccess.Repository;
namespace BusinessObject
{
    public class OrderObject : IDataGridFactory
    {
        public ObservableCollection<object> CreateCollection()
        {
            OrderRepository order = new OrderRepository();
            return new ObservableCollection<object>(order.GetList());
        }
    }
}
