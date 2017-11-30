using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class ClientBusiness
    {
        public Client Add(Client Client)
        {
            var ClientDac = new ClientDAC();
            return ClientDac.Create(Client);
        }
        public void Remove(int id)
        {
            var ClientDac = new ClientDAC();
            ClientDac.DeleteById(id);
        }
        public Client Find(int id)
        {
            var ClientDac = new ClientDAC();
            var result = ClientDac.SelectById(id);
            return result;
        }
        public void Edit(Client Client)
        {
            var ClientDac = new ClientDAC();
            ClientDac.UpdateById(Client);
        }
        public List<Client> All()
        {
            var categoryDac = new ClientDAC();
            var result = categoryDac.Select();
            return result;
        }
    }
}