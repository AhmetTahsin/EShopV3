using EShopV3.Order.Application.Features.CORS.Queries.AddressQueries;
using EShopV3.Order.Application.Features.CORS.Queries.OrderDetailQueries;
using EShopV3.Order.Application.Features.CORS.Results.AddressResults;
using EShopV3.Order.Application.Features.CORS.Results.OrderDetailResults;
using EShopV3.Order.Application.Interfaces;
using EShopV3.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopV3.Order.Application.Features.CORS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderingId=values.OrderingId,
                ProductAmount=values.ProductAmount,
                OrderDetailId=values.OrderDetailId,
                ProductId=values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProructTotalPrice = values.ProructTotalPrice
            };
        }
    }
}
