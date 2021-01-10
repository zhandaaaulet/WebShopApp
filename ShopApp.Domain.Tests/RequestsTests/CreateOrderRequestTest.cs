using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ShopApp.Domain.Model.Auth;
using ShopApp.Domain.Model.Ordering;
using ShopApp.Domain.Model.Shared;
using ShopApp.Domain.Processors.Implementation;
using ShopApp.Domain.Processors.Interfaces;
using ShopApp.Domain.Requests.Ordering;

namespace ShopApp.Domain.Tests.RequestsTests
{
    public class CreateOrderRequestTest
    {
        private IOrderProcessor _orderProcessor;

        [SetUp]
        public void SetUp()
        {
            _orderProcessor = new InMemoryOrderProcessor();
        }

        [Test]
        public async Task Should_Create_Valid_Receipt()
        {
            User user = new User
            {
                Login = "Carl"
            };

            List<Counted<Item>> itemsToBuy = new List<Counted<Item>>
            {
                new Counted<Item>(new Item("X1", "Хлеб", "", 80), 5),
                new Counted<Item>(new Item("X2", "Пакет молока", "", 240), 2)
            };
            
            CreateOrderRequest request = new CreateOrderRequest(user, itemsToBuy);

            CreateOrderRequestHandler handler = new CreateOrderRequestHandler(_orderProcessor);

            var receipt = await handler.Handle(request, default);

            Assert.AreEqual(880, receipt.TotalPrice);
        }

        [Test]
        public async Task Should_Get_Valid_Receipt()
        {
            User user = new User
            {
                Login = "Carl"
            };

            List<Counted<Item>> itemsToBuy = new List<Counted<Item>>
            {
                new Counted<Item>(new Item("X1", "Хлеб", "", 80), 5),
                new Counted<Item>(new Item("X2", "Пакет молока", "", 240), 2)
            };

            CreateOrderRequest request = new CreateOrderRequest(user, itemsToBuy);

            CreateOrderRequestHandler handler = new CreateOrderRequestHandler(_orderProcessor);

            var id = (await handler.Handle(request, default)).OrderId;

            GetOrderReceiptRequest getRequest = new GetOrderReceiptRequest(id);

            GetOrderReceiptRequestHandler getHandler = new GetOrderReceiptRequestHandler(_orderProcessor);

            var receipt = await getHandler.Handle(getRequest, default);

            Assert.AreEqual(880, receipt.TotalPrice);
        }
    }
}
