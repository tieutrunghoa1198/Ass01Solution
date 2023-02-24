using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
