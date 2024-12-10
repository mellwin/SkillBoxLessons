using System;
using System.Collections.Generic;

namespace SB10._3
{
    public class Consultant : IEmployee
    {
        public virtual string JobTitle { get => "Консультант"; }

        private const string HiddenPassport = "** ** ******";

        public Consultant() { }

        public void EditClient(Client client)
        {
            ClientRepo cr = new ClientRepo();
            cr.Update(client, JobTitle);
        }
        public Client ReadClient(int id)
        {
            return new ClientRepo().FindClient(id);
        }

        public virtual List<Client> ShowAllClients()
        {
            ClientRepo clientRepo = new ClientRepo();
            List<Client> clientsList = new List<Client>();

            clientsList = clientRepo.SelectDBClients();
            foreach (var c in clientsList)
            {
                c.Passport = HiddenPassport;
                Console.WriteLine(c.ClientInformation(c));
            }

            return clientsList;
        }
        public void AddClient(Client client)
        {
            ClientRepo cr = new ClientRepo();
            cr.Insert(client, JobTitle);
        }
    }
}
