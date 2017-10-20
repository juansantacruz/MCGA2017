using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class ClientBusiness
    {
        public List<Client> All()
        {
            var categoryDac = new ClientDAC();
            var result = categoryDac.Select();
            return result;
        }
    }
}