using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.ViewComponents.ProductWiewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
