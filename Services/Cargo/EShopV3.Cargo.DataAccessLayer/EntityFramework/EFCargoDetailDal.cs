using EShopV3.Cargo.DataAccessLayer.Abstract;
using EShopV3.Cargo.DataAccessLayer.Concrete;
using EShopV3.Cargo.DataAccessLayer.Repositories;
using EShopV3.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopV3.Cargo.DataAccessLayer.EntityFramework
{
    public class EFCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EFCargoDetailDal(CargoContext context) : base(context)
        {
        }
    }
}
