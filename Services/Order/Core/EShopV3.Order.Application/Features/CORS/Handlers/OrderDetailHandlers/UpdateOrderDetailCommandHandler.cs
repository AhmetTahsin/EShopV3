using EShopV3.Order.Application.Features.CORS.Commands.OrderDetailCommands;
using EShopV3.Order.Application.Interfaces;
using EShopV3.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopV3.Order.Application.Features.CORS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.OrderingId = command.OrderingId;
            values.ProductId = command.ProductId;
            values.ProductName = command.ProductName;
            values.ProductPrice = command.ProductPrice;
            values.ProructTotalPrice = command.ProructTotalPrice;
            values.ProductAmount = command.ProductAmount;
            await _repository.UpdateAsync(values);
        }
    }
}
