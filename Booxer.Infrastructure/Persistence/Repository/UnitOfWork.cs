using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Booxer.Infrastructure.Persistence.Context;
using Booxer.Domain.Repository;
using Booxer.Domain.Exceptions;

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
                _ => new InternalException(),
            };
        }
        catch (Exception)
        {
            throw new InternalException();
        }
    }
}
