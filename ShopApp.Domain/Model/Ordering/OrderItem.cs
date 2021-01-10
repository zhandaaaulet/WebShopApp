using System;

namespace ShopApp.Domain.Model.Ordering
{
    public class OrderItem
    {
        private int _quantity;

        public OrderItem(Item item, Order order, int quantity)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            Order = order ?? throw new ArgumentNullException(nameof(order));
            Quantity = quantity;
        }

        public Item Item { get; }
        public Order Order { get; }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                _quantity = value;
            }
        }

        public bool Any => Quantity != 0;

        public decimal Price => Quantity * Item.Price;
    }
}
