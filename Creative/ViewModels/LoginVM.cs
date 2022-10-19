using System.ComponentModel.DataAnnotations;

namespace Creative.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required"),MaxLength(100),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required"),MaxLength(100),DataType(DataType.Password)]
        public string Password { get; set; }
    }
}