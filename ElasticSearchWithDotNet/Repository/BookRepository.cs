using ElasticSearchWithDotNet.Dtos;
using ElasticSearchWithDotNet.Models;
using Nest;
using System.Collections.Immutable;

namespace ElasticSearchWithDotNet.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ElasticClient _elasticClient;
        private const string indexName = "books";
        public BookRepository(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<Book?> SaveAsync(Book newBook)
        {
            var response = await _elasticClient.IndexAsync(newBook, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));
            //fast fail
            if (!response.IsValid) return null;

            newBook.Id = response.Id;

            return newBook;
        }

        public async Task<List<Book>> GetAllBook()
        {
            var result = await _elasticClient.SearchAsync<Book>(s => s.Index(indexName).Query(q => q.MatchAll()));
            var books = result.Hits.Select(hit =>
            {
                var book = hit.Source;
                book.Id = hit.Id;  // _id değerini manuel olarak ayarlıyoruz
                return book;
            }).ToList();

            return books;
        }

        public async Task<Book?> GetById(string id)
        {
            var result = await _elasticClient.GetAsync<Book>(id, s => s.Index(indexName));
            if (!result.IsValid) return null;

           return result.Source;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _elasticClient.DeleteAsync<Book>(id, s => s.Index(indexName));
          
            return result.IsValid;
        }

        public async Task<bool> Update(BookUpdateDto bookUpdateDto)
        {
            var response = await _elasticClient.UpdateAsync<Book, BookUpdateDto>(bookUpdateDto.Id, x => x.Index(indexName).Doc(bookUpdateDto));

            return response.IsValid;
        }
    }
}
