using ElasticSearchWithDotNet.Dtos;
using ElasticSearchWithDotNet.Models;
using Nest;

namespace ElasticSearchWithDotNet.Repository
{
    public interface IBookRepository
    {
        Task<Book?> SaveAsync(Book newBook);
        Task<List<Book>> GetAllBook();
        Task<Book> GetById(string id);
        Task<bool> Delete(string id);
        Task<bool> Update(BookUpdateDto bookUpdateDto);
    }
}