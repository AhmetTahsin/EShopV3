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
    public class CargoDetailManager : GenericManager<CargoDetail>, ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;
        public CargoDetailManager(ICargoDetailDal cargoDetailDal) : base(cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }
    }
}
