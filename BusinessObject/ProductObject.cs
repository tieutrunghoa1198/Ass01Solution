using BusinessObject.Factory;
using DataAccess.DTO;
using DataAccess.Repository;
using System.Collections.ObjectModel;
namespace BusinessObject
{
    public class ProductObject : IDataGridFactory, ICRUD
    {
        public ProductObject() { }
        public ObservableCollection<object> CreateCollection()
        {
            ProductRepository product = new ProductRepository();
            return new ObservableCollection<object>(product.GetList());
        }

        public void Delete(object product)
        {
            Product asdz = (Product)product;
            ProductRepository productRepo = new ProductRepository();
            productRepo.Delete(asdz);
        }
    }
}
