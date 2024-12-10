namespace WebUI.Models
{
    public class PhoneContact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Descriptions { get; set; }

        public PhoneContact() { }

        public PhoneContact(string name, string phonenumber, string address, string descriptions)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhoneNumber = phonenumber;
            Address = address;
            Descriptions = descriptions;
        }

    }
}
