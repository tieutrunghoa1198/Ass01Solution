using System.Collections.ObjectModel;
using BusinessObject.Factory;
using DataAccess.Repository;
namespace BusinessObject
{
    public class MemberObject : IDataGridFactory
    {
        public ObservableCollection<object> CreateCollection()
        {
            MemberRepository member = new MemberRepository();
            return new ObservableCollection<object>(member.GetList());
        }
    }
}
