using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
