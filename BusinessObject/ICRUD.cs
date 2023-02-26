using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public interface ICRUD
    {
        void Delete(object obj);
    }

    public static class CRUDFactory
    {
        public static ICRUD GetBusinessObject(string _currentType)
        {
            ICRUD business = null;
            switch (_currentType)
            {
                case "product":
                    business = new ProductObject();
                    break;
                case "order":
                    business = new OrderObject();
                    break;
                case "member":
                    business = new MemberObject();
                    break;
            }
            return business;
        }
    }
}
