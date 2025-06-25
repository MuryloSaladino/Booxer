using Booxer.Domain.Common;

namespace Booxer.Domain.Entities;

public class Resource : BaseEntity
{
    public required Guid CategoryId { get; set; }
    public required Category Category { get; set; }
    
    public required string Name { get; set; }
}
