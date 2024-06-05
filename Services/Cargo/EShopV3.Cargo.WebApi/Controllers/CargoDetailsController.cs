using EShopV3.Cargo.BusinessLayer.Abstract;
using EShopV3.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using EShopV3.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopV3.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _detailService;

        public CargoDetailsController(ICargoDetailService detailService)
        {
            _detailService = detailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _detailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _detailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail customer = new CargoDetail()
            {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                ReciverCustomer = createCargoDetailDto.ReciverCustomer,
                SunderCustomer = createCargoDetailDto.SunderCustomer,
            };
            _detailService.TInsert(customer);

            return Ok("Kargo Detayları Ekleme işlemi Başarı ile yapıldı");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _detailService.TDelete(id);
            return Ok("Kargo Detayları Silme işlemi Başarı ile yapıldı");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                ReciverCustomer = updateCargoDetailDto.ReciverCustomer,
                SunderCustomer = updateCargoDetailDto.SunderCustomer,
            };

            _detailService.TUpdate(cargoDetail);
            return Ok("Kargo Detayları Başarı ile Güncellendi");
        }
    }
}
