using System.Collections.Generic;
using DAL.Models;

namespace Creative.ViewModels
{
    public class ProductVM
    {
        public List<Product> Products;
        public int Length { get; set; }
    }
}