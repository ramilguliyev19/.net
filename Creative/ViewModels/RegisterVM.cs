using System.ComponentModel.DataAnnotations;

namespace Creative.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First Name is required"),MaxLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required"),MaxLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required"),MaxLength(100),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required"),MaxLength(100),DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required"),MaxLength(100),DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}