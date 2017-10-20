using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Business
{
    public class OrderBusiness
    {
        public List<Order> All()
        {
            var OrderDac = new OrderDAC();
            var result = OrderDac.Select();
            return result;
        }

        public Order Add(Order Order)
        {
            var OrderDac = new OrderDAC();
            return OrderDac.Create(Order);
        }
    }
}
