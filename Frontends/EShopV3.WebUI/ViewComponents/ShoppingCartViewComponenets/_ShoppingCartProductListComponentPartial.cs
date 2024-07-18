using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.ViewComponents.ShoppingCartViewComponenets
{
    public class _ShoppingCartProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
