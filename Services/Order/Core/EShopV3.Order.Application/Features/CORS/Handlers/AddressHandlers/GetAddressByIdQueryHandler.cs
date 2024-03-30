using EShopV3.Order.Application.Features.CORS.Queries.AddressQueries;
using EShopV3.Order.Application.Features.CORS.Results.AddressResults;
using EShopV3.Order.Application.Interfaces;
using EShopV3.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopV3.Order.Application.Features.CORS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AdressId = values.AddressId,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId,
            };
        }
    }
}
