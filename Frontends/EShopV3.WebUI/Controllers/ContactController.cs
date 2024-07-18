using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
