using ASF.Entities;
using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.UI.Process
{
    public class OrderProcess : ProcessComponent
    {
        public List<Order> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Order/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultOrder;
        }

        public void insertOrder(Order Order)
        {

            ProcessComponent.HttpPost<Order>("rest/Order/Add", Order, MediaType.Json);
        }
    }
}
