using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopApp.Domain.Model.Auth;
using ShopApp.Domain.Model.Ordering;
using ShopApp.Domain.Model.Shared;
using ShopApp.Domain.Processors.Interfaces;

namespace ShopApp.Domain.Requests.Ordering
{
    public class CreateOrderRequest : IRequest<Receipt>
    {
        public CreateOrderRequest(
            User customer,
            IEnumerable<Counted<Item>> itemsToBuy)
        {
            OrderedCustomer = customer ?? throw new ArgumentNullException(nameof(customer));
            ItemsToBuy = itemsToBuy ?? throw new ArgumentNullException(nameof(itemsToBuy));
        }

        public User OrderedCustomer { get; }
        public IEnumerable<Counted<Item>> ItemsToBuy { get; }
    }

    public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest, Receipt>
    {
        private readonly IOrderProcessor _orderProcessor;

        public CreateOrderRequestHandler(IOrderProcessor orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        public async Task<Receipt> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new Order(request.OrderedCustomer);

            foreach(var item in request.ItemsToBuy)
            {
                order.AddItem(item.Item, item.Count);
            }

            await _orderProcessor.SaveOrder(order);

            return new Receipt(order);
        }
    }
}
