using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponenetPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
