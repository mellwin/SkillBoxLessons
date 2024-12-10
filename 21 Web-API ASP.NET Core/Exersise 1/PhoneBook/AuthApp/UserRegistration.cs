using System.ComponentModel.DataAnnotations;

namespace PhoneBook.AuthApp
{
    public class UserRegistration
    {
        [Required, MaxLength(20)]
        public string? LoginProp { get; set; }

        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}