using Microsoft.AspNetCore.Mvc;

namespace BlogNestS.Areas.Admin.Views.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
