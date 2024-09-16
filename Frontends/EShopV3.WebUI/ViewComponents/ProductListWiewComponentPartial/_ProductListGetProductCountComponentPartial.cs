using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.ViewComponents.ProductListWiewComponentPartial
{
    public class _ProductListGetProductCountComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
