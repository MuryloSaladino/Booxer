using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Booxer.Infrastructure.Persistence.Context;
using Booxer.Domain.Repository;

namespace Booxer.Infrastructure.Persistence.Repository;

public class UnitOfWork(BooxerContext ctx) : IUnitOfWork
{
    public async Task Save(CancellationToken cancellationToken)
    {
        try
        {
            await ctx.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
        {
            throw sqlEx.Number switch
            {
                2627 or 2601 => new DuplicatedEntityException(sqlEx.Message),
                547 => new EntityNotFoundException(),
                _ => new DatabaseException(sqlEx.Message),
            };
        }
        catch (Exception e)
        {
            throw new DatabaseException(e.Message);
        }
    }
}
