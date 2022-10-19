using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class AppUser: IdentityUser
    {
        [Required,MaxLength(128)]
        public string FirstName { get; set; }
        [Required,MaxLength(128)]
        public string LastName { get; set; }
    }
}