using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services;
using Creative.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Creative.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            List<Product> data;
            try
            {
                data = await _productService.GetAll();
            }
            catch (Exception e)
            {
                return Json(new
                {
                    status = 505,
                    message = e.Message
                });
            }
            
            ProductVM productVm = new ProductVM
            {
                Products = data,
                Length = data.Count
            };
            return View(productVm);
        }
    }
}