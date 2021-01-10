using System;

namespace ShopApp.Domain.Model.Ordering
{
    public class ReceiptItem
    {
        public ReceiptItem(long itemId, string articul, string title, decimal price, int quantity)
        {
            ItemId = itemId;
            Articul = articul ?? throw new ArgumentNullException(nameof(articul));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Price = price;
            Quantity = quantity;
        }

        public long ItemId { get; }
        public string Articul { get; }
        public string Title { get; }
        public decimal Price { get; }
        public int Quantity { get; }
        public decimal TotalPrice => Price * Quantity;
    }
}
