using ElasticSearchWithDotNet.Dtos;
using ElasticSearchWithDotNet.Repository;
using System.Net;

namespace ElasticSearchWithDotNet.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResponseDto<BookDto>> SaveAsync(BookCreateDto request)
        {
            var response = await _bookRepository.SaveAsync(request.CreateBook());

            if (response == null)
            {

                return ResponseDto<BookDto>.Fail(new List<string> { "kayıt esnasında bir hata meydana geldi." }, System.Net.HttpStatusCode. InternalServerError);
            }

            return ResponseDto<BookDto>.Succes(response.CreateDto(), HttpStatusCode.Created);
        }

    }
}
