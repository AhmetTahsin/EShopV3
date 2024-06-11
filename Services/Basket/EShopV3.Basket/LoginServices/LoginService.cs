namespace EShopV3.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public LoginService(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }

        string ILoginService.GetUserId => _httpcontextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
