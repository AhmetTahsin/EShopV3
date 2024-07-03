using EShopV3.IdentityServer.Dtos;
using EShopV3.IdentityServer.Models;
using IdentityServer4.Hosting.LocalApiAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace EShopV3.IdentityServer.Controllers
{
   // [Authorize(LocalApi.PolicyName)] 
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
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
