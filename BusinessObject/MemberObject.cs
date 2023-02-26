using System.Collections.ObjectModel;
using BusinessObject.Factory;
using DataAccess.DTO;
using DataAccess.Repository;
namespace BusinessObject
{
    public class MemberObject : IDataGridFactory, ICRUD
    {
        public ObservableCollection<object> CreateCollection()
        {
            MemberRepository member = new MemberRepository();
            return new ObservableCollection<object>(member.GetList());
        }

        public void Delete(object product)
        {
            MemberDTO asdz = (MemberDTO)product;
            MemberRepository orderRepo = new MemberRepository();
            orderRepo.Delete(asdz);
        }
    }
}
