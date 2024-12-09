using Publico_Kommunikation.MVVM.Models;

namespace Publico_Kommunikation.DataAccess
{
    /// <summary>
    /// A repository interface for managing quote entities.
    /// Extends the functionality of the <see cref="ISimpleKeyRepository{T}"/> interface.
    /// </summary>
    public interface IQuoteRepository : ISimpleKeyRepository<Quote>
    {
        /// <summary>
        /// Retrieves all <see cref="Quote"/> entities where <see cref="Quote.QuoteName"/> or <see cref="Quote.Tags"/>
        /// matches the specified <paramref name="searchQuery"/>.
        /// </summary>
        /// <param name="searchQuery">The <see cref="string"/> to be used as the search query.</param>
        /// <returns>A collection of <see cref="Quote"/>entities that match the specified <paramref name="searchQuery"/>.</returns>
        IEnumerable<Quote> GetBySearchQuery(string searchQuery);
    }
}
