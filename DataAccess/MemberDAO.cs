using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();

        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new MemberDAO();
                }
                return instance;
            }
        }

        public IEnumerable<MemberDTO> GetProductList()
        {
            List<MemberDTO> members;
            try
            {
                var myStockDB = new ManagementDBContext();
                members = myStockDB.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public MemberDTO GetMemberByID(int memberId)
        {
            MemberDTO members = null;
            try
            {
                var myStockDB = new ManagementDBContext();
                members = myStockDB.Members.SingleOrDefault(car => car.MemberId == memberId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }
    }
}
 