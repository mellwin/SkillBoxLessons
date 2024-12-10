using System.Collections.Generic;

namespace SB10._3
{
    interface IEmployee
    {
        string JobTitle { get; }

        public void EditClient(Client client);

        public Client ReadClient(int id);

        public List<Client> ShowAllClients();

        public void AddClient(Client client);
    }
}