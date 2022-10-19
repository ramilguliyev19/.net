using System.ComponentModel.DataAnnotations;
using Core.Entity;
using DAL.Base;

namespace DAL.Models
{
    public class Product: BaseEntity, IEntity
    {
        [Required(ErrorMessage = "Title is required!"),MaxLength(30)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required!"),MaxLength(100)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Icon is required!")]
        public string Icon { get; set; }

        public bool IsActive { get; set; }
        
    }
}