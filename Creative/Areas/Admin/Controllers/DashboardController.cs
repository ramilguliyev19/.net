using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Creative.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
      [Authorize]
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}