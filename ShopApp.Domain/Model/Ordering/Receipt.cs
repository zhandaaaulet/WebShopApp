using System;
using System.Linq;
using System.Collections.Generic;

namespace ShopApp.Domain.Model.Ordering
{
    public class Receipt
    {
        public Receipt(Order order)
        {
            OrderId = order.Id;
            CreatedDate = order.CreatedDate;
            Items = new List<ReceiptItem>(order.Items.Select(item =>
                new ReceiptItem(item.Item.Id, item.Item.Articul, item.Item.Articul, item.Item.Price, item.Quantity)));
        }

        public long OrderId { get; }
        public DateTimeOffset CreatedDate { get; }
        public IEnumerable<ReceiptItem> Items { get; }
        public decimal TotalPrice => Items.Sum(item => item.TotalPrice);
    }
}
