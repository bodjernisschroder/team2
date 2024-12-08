using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.DataAccess
{
    /// <summary>
    /// A repository interface for managing quote entities.
    /// Extends the functionality of the <see cref="ISimpleKeyRepository{T}"/> interface.
    /// </summary>
    public interface IQuoteRepository : ISimpleKeyRepository<Quote>
    {
        IEnumerable<Quote> GetBySearchQuery(string searchQuery);
    }
}
