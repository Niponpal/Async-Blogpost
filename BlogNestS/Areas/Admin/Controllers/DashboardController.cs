using Microsoft.AspNetCore.Mvc;

namespace BlogNestS.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
