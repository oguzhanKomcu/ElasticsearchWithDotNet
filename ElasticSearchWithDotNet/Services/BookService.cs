using ElasticSearchWithDotNet.Dtos;
using ElasticSearchWithDotNet.Repository;

namespace ElasticSearchWithDotNet.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository )
        {
           _bookRepository = bookRepository;   
        }

        public async Task SaveAsync(BookCreateDto request)
        {
            var response = _bookRepository.SaveAsync(request.CreateBook());
        }

    }
}
