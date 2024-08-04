using Microsoft.AspNetCore.Mvc;

namespace EShopV3.WebUI.Areas.Admin.ViewComponenet.AdminLayoutViewComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
