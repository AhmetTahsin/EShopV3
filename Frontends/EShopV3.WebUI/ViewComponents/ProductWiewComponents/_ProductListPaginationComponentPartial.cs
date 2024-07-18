using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.ViewComponents.ProductWiewComponents
{
    public class _ProductListPaginationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
