using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity;
using DAL.Base;
using Microsoft.AspNetCore.Http;

namespace DAL.Models
{
    public class Hero: BaseEntity, IEntity
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "SubTitle is required")]
        public string SubTitle { get; set; }
        [Required(ErrorMessage = "Image is required")]

        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "RedirectUrl is required")]
        public string RedirectUrl { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Image is required")]
        public IFormFile ImageFile { get; set; }
    }
}