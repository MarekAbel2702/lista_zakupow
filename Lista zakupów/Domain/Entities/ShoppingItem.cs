using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShoppingItem
    {
        public const int MaxNameLength = 100;

        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int Quantity => _quantity;
        public bool IsPurchased { get; private set; }
        public DateTime? CreatedAtUtc { get; private set; }
        public DateTime? UpdatedAtUtc { get; private set; }


        private int _quantity;

        private ShoppingItem() { }

        private ShoppingItem(string name, int quantity)
        {
            Name = ValidateName(name);
            _quantity = ValidateQuantity(quantity);

            IsPurchased = false;
            CreatedAtUtc = DateTime.Now;
            UpdatedAtUtc = null;
        }

        public static ShoppingItem Create (string name, int quantity)
            => new ShoppingItem (name, quantity);

        public void UpdateName(string name)
        {
            Name = ValidateName(name);
            Touch();
        }

        public void UpdateQuantity(int quantity)
        {
            _quantity = ValidateQuantity(quantity);
            Touch();
        }

        public void Increase(int by = 1)
        {
            if (by < 1)
                throw new DomainException("Increase step must be at least 1.");

            _quantity = ValidateQuantity(_quantity + by);
            Touch();
        }

        public void Decrease (int by = 1)
        {
            if (by < 1)
            {
                throw new DomainException("Decrease step must by at least 1");
            }

            _quantity = ValidateQuantity(_quantity - by);
            Touch();
        }

        public void MarkPurchased()
        {
            if (!IsPurchased)
            {
                IsPurchased = true;
                Touch();
            }
        }

        public void MarkPuchased()
        {
            if (IsPurchased)
            {
                IsPurchased = false;
                Touch();
            }
        }

        private static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty.");

            var trimmed = name.Trim();

            if (trimmed.Length > MaxNameLength)
                throw new DomainException($"Name cannot exceed {MaxNameLength} characters.");
            return trimmed;
        }

        private static int ValidateQuantity(int quantity)
        {
            if (quantity < 1)
                throw new DomainException("Quantity must be at least 1.");
            return quantity;
        }

        private void Touch() => UpdatedAtUtc = DateTime.UtcNow;
    }
}
