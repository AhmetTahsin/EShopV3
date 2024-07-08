using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
