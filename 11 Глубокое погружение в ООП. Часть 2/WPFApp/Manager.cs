using System;
using System.Collections.Generic;

namespace WPFApp
{
    public class Manager : Consultant
    {
        public override string JobTitle { get => "Менеджер"; }

        public Manager() { }

        public override List<Client> ShowAllClients()
        {
            ClientRepo clientRepo = new ClientRepo();
            List<Client> clientsList = new List<Client>();

            clientsList = clientRepo.SelectDBClients();
            foreach (var c in clientsList)
            {
                Console.WriteLine(c.ClientInformation(c));
            }

            return clientsList;
        }
    }
}