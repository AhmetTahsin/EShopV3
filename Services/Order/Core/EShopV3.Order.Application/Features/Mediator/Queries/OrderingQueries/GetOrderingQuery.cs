using EShopV3.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopV3.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>> //MediatR kütüphanesi
    {
        //GetOrderingQuery çağırdığımızda <List<GetOrderingQueryResult>>  döner
    }
}
