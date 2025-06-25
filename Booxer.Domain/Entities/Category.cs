using Booxer.Domain.Common;

namespace Booxer.Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
}