using Domain.Abstractions;
using Domain.Entities;
using Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShoppingItemRepository
    {
        Task<ShoppingItem> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<ShoppingItem>> GetAllAsync(
            bool onlyNotPurchased = false, 
            CancellationToken ct = default);
        Task<PagedResult<ShoppingItem>> SearchAsync(
            ItemSearchCriteria criteria,
            CancellationToken ct = default);
        Task AddAsync(ShoppingItem item, CancellationToken ct = default);
        Task UpdateAsync(ShoppingItem item, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
        Task<bool> ExistByNameAsync(string normalizedName,  CancellationToken ct = default);
    }
}
