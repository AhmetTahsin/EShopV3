using Dapper;
using EShopV3.Discount.Context;
using EShopV3.Discount.Dtos;

namespace EShopV3.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Depper ekleme işlemi
        /// </summary>
        /// <param name="createCouponDto"></param>
        /// <returns></returns>
        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values(@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        /// <summary>
        /// Depper Silme işlemi idye göre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponid", id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        /// <summary>
        /// Depper Liste olarak veri alma
        /// </summary>
        /// <returns></returns>
        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values= await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }
        /// <summary>
        /// Depper Idye Göre veri çekme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select*From Coupons Where CouponId=@couponId";
            var parameters=new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return values;
            }
        }
        /// <summary>
        /// Depper Guncelleme
        /// </summary>
        /// <param name="updateCouponDto"></param>
        /// <returns></returns>
        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate , IsActive=@isActive ,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
