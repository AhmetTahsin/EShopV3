using EShopV3.Order.Application.Features.CORS.Commands.AddressCommands;
using EShopV3.Order.Application.Interfaces;
using EShopV3.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopV3.Order.Application.Features.CORS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail=createAddressCommand.Detail,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,
            });
        }
    }
}
