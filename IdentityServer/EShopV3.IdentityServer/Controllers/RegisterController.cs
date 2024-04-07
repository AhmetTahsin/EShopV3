using EShopV3.IdentityServer.Dtos;
using EShopV3.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShopV3.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
            };
            var result = await _userManager.CreateAsync(values,userRegisterDto.Password);//IdentityResult
            if (result.Succeeded)//Succeeded true false dondurur başarılı mı değil mi
            {
                return Ok("Kullanıcı Başarı ile eklendi");
            }
            else
            {
                return Ok("Bir Hata Oluştu Tekrar Deneyin");
            }
        }
    }
}
