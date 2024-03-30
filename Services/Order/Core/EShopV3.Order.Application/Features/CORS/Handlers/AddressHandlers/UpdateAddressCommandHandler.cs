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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressId);
            values.Detail=command.Detail;
            values.District=command.District;
            values.City=command.City;
            values.UserId=command.UserId;
            await _repository.UpdateAsync(values);
        }

    }
}
