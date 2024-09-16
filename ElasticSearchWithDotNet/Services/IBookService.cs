using ElasticSearchWithDotNet.Dtos;
using ElasticSearchWithDotNet.Models;

namespace ElasticSearchWithDotNet.Services
{
    public interface IBookService
    {
        Task<ResponseDto<BookDto>> SaveAsync(BookCreateDto request);
        Task<ResponseDto<List<Book>>> GetAll();
        Task<ResponseDto<BookDto>> GetById(string Id);
        Task<ResponseDto<bool>> DeleteAsync(string id);
        Task<ResponseDto<bool>> Update(BookUpdateDto updateDto);
    }
}