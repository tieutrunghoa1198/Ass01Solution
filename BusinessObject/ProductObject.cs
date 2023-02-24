using DataAccess.Repository;
using System.Collections.ObjectModel;
namespace BusinessObject
{
    public class ProductObject : IDataGridFactory
    {
        public ProductObject() { }
        public ObservableCollection<object> CreateCollection()
        {
            ProductRepository product = new ProductRepository();
            return new ObservableCollection<object>(product.GetList());
        }
    }
}
