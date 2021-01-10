using System.Linq;
using System.Collections.Generic;
using System;
using ShopApp.Domain.Model.Shared;
using ShopApp.Domain.Model.Auth;

namespace ShopApp.Domain.Model.Ordering
{
    public class Order
    {
        private readonly List<OrderItem> _items;

        public Order(User orderedCustomer) : this(
            0L,
            Array.Empty<Counted<Item>>(),
            orderedCustomer,
            DateTimeOffset.Now,
            DateTimeOffset.Now)
        {

        }

        public Order(
            long id,
            IEnumerable<Counted<Item>> items,
            User orderedCustomer,
            DateTimeOffset createdDate,
            DateTimeOffset updatedDate)
        {
            Id = id;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            OrderedCustomer = orderedCustomer;

            _items = new List<OrderItem>();

            foreach(var item in items)
            {
                AddItem(item.Item, item.Count);
            }
        }

        public long Id { get; set; }

        public User OrderedCustomer { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public IEnumerable<OrderItem> Items => _items;

        public void AddItem(Item item, int quantity)
        {
            if (quantity <= 0)
            {
                return;
            }

            var existingItem = _items.FirstOrDefault(i => i.Item == item);

            if (existingItem is null)
            {
                existingItem = new OrderItem(item, this, 0);
                _items.Add(existingItem);
            }

            existingItem.Quantity += quantity;
        }

        public void RemoveItem(Item item, int quantity)
        {
            if (quantity <= 0)
            {
                return;
            }

            var existingItem = _items.FirstOrDefault(i => i.Item == item);

            if (existingItem != null)
            {
                existingItem.Quantity -= quantity;

                if (!existingItem.Any)
                {
                    _items.Remove(existingItem);
                }
            }
        }

        public decimal Price => _items.Sum(item => item.Price);
    }
}
