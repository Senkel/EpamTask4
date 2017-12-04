using EpamTask4;
using EpamTask4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class ClientService
    {
        public Client GetOrCreate(string name)
        {
            var clientRepo = new ClientRepository();

            Client client = clientRepo.GetByName(name);

            if (client == null)
            {
                client = new Client() { ClientName = name };
                clientRepo.Insert(client);
            }

            return client;
        }
    }
}
