using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
