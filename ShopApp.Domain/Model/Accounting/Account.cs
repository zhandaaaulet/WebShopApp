using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Domain.Model.Accounting
{
    public class Account
    {
        public long Id { get; set; }

        public decimal Balance { get; set; }
    }
}
