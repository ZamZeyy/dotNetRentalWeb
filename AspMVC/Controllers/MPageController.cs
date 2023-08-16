using Microsoft.AspNetCore.Mvc;

namespace MazdaColour.Controllers
{
    public class MPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MazdaPage()
        {
            return View();
        }
    }
}
