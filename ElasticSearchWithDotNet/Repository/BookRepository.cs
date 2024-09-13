using ElasticSearchWithDotNet.Models;
using Nest;

namespace ElasticSearchWithDotNet.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ElasticClient _elasticClient;

        public BookRepository(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<Book?> SaveAsync(Book newBook)
        {
            var response = await _elasticClient.IndexAsync(newBook, x => x.Index("books"));
            //fast fail
            if (!response.IsValid) return null;
            newBook.Id = response.Id;
            return newBook;
        }
    }
}
