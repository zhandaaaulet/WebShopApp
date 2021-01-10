using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Domain.Model.Ordering;
using ShopApp.Domain.Processors.Interfaces;

namespace ShopApp.Domain.Processors.Implementation
{
    public class InMemoryOrderProcessor : IOrderProcessor
    {
        private static int _idCounter = 0;

        private readonly List<Order> _orders = new List<Order>();

        public Task<Order> GetById(long orderId)
        {
            return Task.FromResult(_orders.FirstOrDefault(order => order.Id == orderId));
        }

        public Task SaveOrder(Order order)
        {
            _orders.Add(order);
            order.Id = ++_idCounter;
            return Task.CompletedTask;
        }
    }
}
