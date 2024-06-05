using EShopV3.Cargo.BusinessLayer.Abstract;
using EShopV3.Cargo.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopV3.Cargo.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _iGeneric;

        public GenericManager(IGenericDal<T> iGeneric)
        {
            _iGeneric = iGeneric;
        }

        public void TDelete(int id)
        {
            _iGeneric.Delete(id);
        }

        public List<T> TGetAll()
        {
            return _iGeneric.GetAll();
        }

        public T TGetById(int id)
        {
            return _iGeneric.GetById(id);
        }

        public void TInsert(T entity)
        {
            _iGeneric.Insert(entity);
        }

        public void TUpdate(T entity)
        {
            _iGeneric.Update(entity);
        }
    }
}
