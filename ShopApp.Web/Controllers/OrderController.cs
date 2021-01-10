using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Domain.Requests.Ordering;

namespace ShopApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> CreateOrder()
        {
            var request = new CreateOrderRequest(null, null);

            var receipt = await _mediator.Send(request);

            return Json(receipt);
        }
    }
}
