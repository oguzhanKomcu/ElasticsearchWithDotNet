using ElasticSearchWithDotNet.Models;

namespace ElasticSearchWithDotNet.Repository
{
    public interface IBookRepository
    {
        Task<Book?> SaveAsync(Book newBook);
    }
}