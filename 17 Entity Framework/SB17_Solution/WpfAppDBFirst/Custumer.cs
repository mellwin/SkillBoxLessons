namespace WpfAppDBFirst;

public partial class Custumer
{
    public Guid Id { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string? SecondName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }


    /// <summary>
    /// Свойства сгенерились, конструктор я сам сделал
    /// </summary>
    /// <param name="id"></param>
    /// <param name="lastName"></param>
    /// <param name="name"></param>
    /// <param name="secondName"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="email"></param>
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
