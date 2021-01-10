using System;
using ShopApp.Domain.Model.Accounting;

namespace ShopApp.Domain.Model.Auth
{
    public class User
    {
        public long Id { get; set; }

        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public Role Role { get; set; }
        public Account Account { get; set; }

        public DateTimeOffset RegisteredDate { get; set; }
    }
}
