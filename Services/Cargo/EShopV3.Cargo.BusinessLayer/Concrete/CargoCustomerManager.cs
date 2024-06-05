using EShopV3.Cargo.BusinessLayer.Abstract;
using EShopV3.Cargo.DataAccessLayer.Abstract;
using EShopV3.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopV3.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : GenericManager<CargoCustomer>, ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;
        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal) : base(cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }
    }
}
