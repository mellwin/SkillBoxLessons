using System.Collections.Generic;

namespace WPFApp
{
    public interface IEmployee
    {
        string JobTitle { get; }

        public void EditClient(Client client);

        public Client ReadClient(int id);

        public List<Client> ShowAllClients();
        
        public void RemoveClient(int id);
    }
}