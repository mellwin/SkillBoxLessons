using System;

namespace WPFApp
{
    public class Client
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string MobilePhone { get; set; }
        public string Passport { get; set; }

        public string ChangeTime { get; set; }
        public string Changes { get; set; }
        public string ChangesType { get; set; }
        public string WhoChanged { get; set; }

        public Client()
        {
        }
        public string ClientInformation(Client client)
        {
            return String.Format("Id:{0, 5} | Name:{1,15} | Surname:{2,15} |  SecondName:{3, 15} | MobilePhone:{4, 12} | Passport:{5, 10} | ChangeTime:{6, 10} | Changes:{7, 35} | ChangesType:{8, 10} | WhoChanged:{9, 10} ",
                client.Id,
                client.Name,
                client.Surname,
                client.SecondName,
                client.MobilePhone,
                client.Passport,
                client.ChangeTime,
                client.Changes,
                client.ChangesType,
                client.WhoChanged);
        }
    }
}