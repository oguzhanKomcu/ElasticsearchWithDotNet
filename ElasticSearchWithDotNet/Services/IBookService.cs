using ElasticSearchWithDotNet.Dtos;

namespace ElasticSearchWithDotNet.Services
{
    public interface IBookService
    {
        Task<ResponseDto<BookDto>> SaveAsync(BookCreateDto request);
    }
}