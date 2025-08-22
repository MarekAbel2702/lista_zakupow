using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications
{
    public sealed class ItemSearchCriteria
    {
        public string? NameContains { get; init; }
        public bool? OnlyNotPurchased { get; init; }
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 50;
    }
}
