using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;

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

        public void AddNew(MemberDTO member)
        {
            try
            {
                MemberDTO _member = GetMemberByID(member.MemberId);
                if (_member == null)
                {
                    var myStockDB = new ManagementDBContext();
                    myStockDB.Members.Add(member);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(MemberDTO member)
        {
            try
            {
                MemberDTO _member = GetMemberByID(member.MemberId);
                if (_member != null)
                {
                    var myStockDB = new ManagementDBContext();
                    myStockDB.Entry<MemberDTO>(member).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(MemberDTO member)
        {
            try
            {
                MemberDTO _member = GetMemberByID(member.MemberId);
                if (_member != null)
                {
                    var myStockDB = new ManagementDBContext();
                    myStockDB.Members.Remove(member);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
 