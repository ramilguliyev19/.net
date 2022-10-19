using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using Creative.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Creative.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHeroService _heroService;

        public HomeController(IHeroService heroService)
        {
            _heroService = heroService;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            HomeVM homeVm = new HomeVM();
            homeVm.hero = (await _heroService.GetAll()).FirstOrDefault(hero => !hero.IsDelted && hero.IsActive);
            if (homeVm.hero is null)
            {
                homeVm.hero = new Hero
                {
                    Title = "Empty",
                    SubTitle = "Empty",
                    RedirectUrl = "Empty"
                };
            }
            return View(homeVm);
        }
    }
}