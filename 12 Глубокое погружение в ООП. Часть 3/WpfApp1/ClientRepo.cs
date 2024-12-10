using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WPFApp
{
    public class ClientRepo
    {
        private readonly string path = "Clients.json";

        public ClientRepo()
        {
            if (!File.Exists(path))
                File.Create(path);
        }

        public void Insert(Client client, string jobTitle)
        {
            var clientList = SelectDBClients();

            bool flag = true;

            if (clientList.Count() == 0)
            {
                client.Id = 1;
            }
            else
            {
                client.Id = clientList.Max(c => c.Id) + 1;
            }


            client.Changes = $"Добавлен клиент с идентификатором : {client.Id}";

            client.ChangeTime = DateTime.Now.ToString();

            client.ChangesType = "Добавление";

            client.WhoChanged = jobTitle;

            foreach (var c in clientList)
            {
                if (c.Passport == client.Passport)
                {
                    flag = false;
                }
            }

            if (flag) clientList.Add(client);

            SerializeNewJson(clientList);
        }

        public void Delete(int id)
        {
            var clientList = SelectDBClients();

            List<Client> newClientList = new List<Client>();

            foreach (var c in clientList)
            {
                if (c.Id != id) newClientList.Add(c);
            }

            SerializeNewJson(newClientList);
        }

        public void Update(Client client, string jobTitle)
        {
            var clientList = SelectDBClients();

            foreach (var c in clientList)
            {
                if (c.Passport == client.Passport)
                {
                    c.Name = client.Name;
                    c.Surname = client.Surname;
                    c.SecondName = client.SecondName;
                    c.MobilePhone = client.MobilePhone;


                    c.Changes = $"Изменен клиент с идентификатором : {client.Id}";
                    c.ChangeTime = DateTime.Now.ToString();
                    c.ChangesType = "Изменение";
                    c.WhoChanged = jobTitle;
                }
            }

            SerializeNewJson(clientList);
        }

        public Client FindClient(int id)
        {
            var clientList = SelectDBClients();
            var client = new Client();

            foreach (var c in clientList)
            {
                if (c.Id == id)
                {
                    client = c;
                    break;
                }
            }

            return client;
        }

        public List<Guid> SelectDBClientsBankAccountId(int clientId)
        {
            return FindClient(clientId).BankAccounts;
        }

        public List<Client> SelectDBClients()
        {
            string json = File.ReadAllText(path);

            List<Client> clientList = JsonConvert.DeserializeObject<List<Client>>(json);

            if (clientList == null) clientList = new List<Client>();

            return clientList;
        }

        private void SerializeNewJson(List<Client> clientList)
        {
            string newJson = JsonConvert.SerializeObject(clientList);

            File.WriteAllText(path, newJson);
        }
    }
}