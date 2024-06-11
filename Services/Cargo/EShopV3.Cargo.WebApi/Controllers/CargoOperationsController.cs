using EShopV3.Cargo.BusinessLayer.Abstract;
using EShopV3.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using EShopV3.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopV3.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase 
    {
        private readonly ICargoOperationService _operationService;

        public CargoOperationsController(ICargoOperationService operationService)
        {
            _operationService = operationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _operationService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _operationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation operation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };
            _operationService.TInsert(operation);

            return Ok("Kargo işlemi Başarı ile yapıldı");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _operationService.TDelete(id);
            return Ok("Kargo işlemi Başarı ile Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate,
            };

            _operationService.TUpdate(CargoOperation);
            return Ok("Kargo İşlemi Başarı ile Güncellendi");
        }
    }
}
