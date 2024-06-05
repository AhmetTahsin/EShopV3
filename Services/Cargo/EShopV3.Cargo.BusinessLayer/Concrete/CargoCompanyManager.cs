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
    public class CargoCompanyManager : GenericManager<CargoCompany>,ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;
        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal) : base(cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

    }
}
