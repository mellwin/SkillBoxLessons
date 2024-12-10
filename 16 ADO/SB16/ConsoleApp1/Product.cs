namespace ConsoleApp1
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }

        public Product(Guid id, string email, int productCode, string productName)
        {
            Id = id;
            Email = email;
            ProductCode = productCode;
            ProductName = productName;
        }
    }

}