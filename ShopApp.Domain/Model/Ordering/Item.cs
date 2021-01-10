using System;

namespace ShopApp.Domain.Model.Ordering
{
    public class Item
    {
        private string _articul;
        private string _title;
        private string _description;
        private decimal _price;
        private DateTimeOffset _updateDelete;

        public Item(
            string articul,
            string title,
            string description,
            decimal price)
            : this(
                  0L,
                  articul,
                  title,
                  description,
                  price,
                  DateTimeOffset.Now,
                  DateTimeOffset.Now)
        {

        }

        public Item(
            long id,
            string articul,
            string title, 
            string description,
            decimal price,
            DateTimeOffset createdDate,
            DateTimeOffset updatedDate)
        {

            Id = id;
            Articul = articul;
            Title = title;
            Description = description;
            Price = price;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }

        public long Id { get; set; }

        public string Articul
        {
            get
            {
                return _articul;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Articul can't be empty");
                }

                _articul = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title can't be emtpty");
                }

                _title = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(Description), "Description can't be null");
                }

                _description = value;
            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Price), "Price can't be less than 0");
                }

                _price = value;
            }
        }

        public DateTimeOffset CreatedDate { get; }

        public DateTimeOffset UpdatedDate
        {
            get
            {
                return _updateDelete;
            }
            set
            {
                if (value < CreatedDate)
                {
                    throw new ArgumentException("Update date can't be earlier than create date");
                }

                _updateDelete = value;
            }
        }
    }
}
