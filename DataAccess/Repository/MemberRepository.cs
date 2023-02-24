using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void Delete(MemberDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberDTO> GetList() => MemberDAO.Instance.GetProductList();

        public void Insert(MemberDTO item)
        {
            throw new NotImplementedException();
        }

        public void Update(MemberDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
