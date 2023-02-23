using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace SalesWPFApp.ViewModel
{
    class DataGridFactory : FactoryTest
    {
        public ObservableCollection<object> CreateCollection()
        {
            return new ObservableCollection<object>(new List<Product>
            {
                new Product(1, "asd"),
                new Product(1, "asd"),
            });
        }
    }

    class DataGridFactoryOrder : FactoryTest
    {
        public ObservableCollection<object> CreateCollection()
        {
            return new ObservableCollection<object>(new List<Order>
            {
                new Order(1, "asd", "desc"),
                new Order(2, "asd", "desczxc zxc"),
                new Order(3, "asd", "desc 123qwe"),
            });
        }
    }

    class CollectionFactory
    {
        public FactoryTest MyObject { get; private set; }
        public CollectionFactory(string type)
        {
            switch (type)
            {
                case "product":
                    MyObject = new DataGridFactory();
                    break;
                case "order":
                    MyObject = new DataGridFactoryOrder();
                    break;
            }
        }
    }
    public interface FactoryTest
    {
        ObservableCollection<object> CreateCollection();
    }
}
