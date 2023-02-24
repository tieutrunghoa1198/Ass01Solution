using DataAccess.DTO;
namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void Delete(Product item)
        => ProductDAO.Instance.Delete(item);

        public IEnumerable<Product> GetList() 
        => ProductDAO.Instance.GetProductList();

        public void Insert(Product item) 
        => ProductDAO.Instance.AddNew(item);

        public void Update(Product item) 
        => ProductDAO.Instance.Update(item);
    }
}
