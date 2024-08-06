using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpeacialOfferComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
