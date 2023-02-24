using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    class OrderDTO
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public Decimal Freight { get; set; }

        public OrderDTO()
        {
        }

        public OrderDTO(int orderId, int memberId, DateTime orderDate, DateTime requireDate, DateTime shippedDate, decimal freight)
        {
            OrderId = orderId;
            MemberId = memberId;
            OrderDate = orderDate;
            RequiredDate = requireDate;
            ShippedDate = shippedDate;
            Freight = freight;
        }
    }
}
