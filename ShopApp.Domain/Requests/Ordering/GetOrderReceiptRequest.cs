using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopApp.Domain.Model.Ordering;
using ShopApp.Domain.Model.Shared;
using ShopApp.Domain.Processors.Interfaces;

namespace ShopApp.Domain.Requests.Ordering
{
    /// <summary>
    /// Запрос на получение выписки по заказу.
    /// </summary>
    public class GetOrderReceiptRequest : IRequest<Receipt>
    {
        public GetOrderReceiptRequest(long orderId)
        {
            OrderId = orderId;
        }

        /// <summary>
        /// Уникальный идентификатор заказа.
        /// </summary>
        public long OrderId { get; }
    }

    public class GetOrderReceiptRequestHandler : IRequestHandler<GetOrderReceiptRequest, Receipt>
    {
        private readonly IOrderProcessor _orderProcessor;

        public GetOrderReceiptRequestHandler(IOrderProcessor orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        public async Task<Receipt> Handle(GetOrderReceiptRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderProcessor.GetById(request.OrderId);

            if (order is null)
            {
                throw new EntityNotFoundException(typeof(Order), 
                    $"Order with id {request.OrderId} not found");
            }

            return new Receipt(order);
        }
    }
}
