namespace ConsoleApp1
{
    public class Custumer
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Custumer() { }
        public Custumer(Guid id, string lastName, string name, string secondName, string phoneNumber, string email) 
        {
            Id = id;
            LastName = lastName;
            Name = name;
            SecondName = secondName;
            PhoneNumber = phoneNumber;
            Email = email;                
        }
    }
}
