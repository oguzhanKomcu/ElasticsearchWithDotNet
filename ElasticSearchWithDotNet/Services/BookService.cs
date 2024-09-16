using ElasticSearchWithDotNet.Dtos;
using ElasticSearchWithDotNet.Models;
using ElasticSearchWithDotNet.Repository;
using Nest;
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
        public async Task<ResponseDto<List<Book>>> GetAll()
        {
            var response = await _bookRepository.GetAllBook();

            if (response == null)
            {

                return ResponseDto<List<Book>>.Fail(new List<string> { "Kitap listesi getirilme esnasında bir hata meydana geldi." }, System.Net.HttpStatusCode.InternalServerError);
            }

            var books = response.Select(x => new BookDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Title = x.Title,
                Author = x.Author,
            });


            return ResponseDto<List<Book>>.Succes(response, HttpStatusCode.Accepted);
        }
        public async Task<ResponseDto<BookDto>> GetById(string Id)
        {
            var response = await _bookRepository.GetById(Id);

            if (response == null)
            {

                return ResponseDto<BookDto>.Fail(new List<string> { "Kitap bulunamadı." }, System.Net.HttpStatusCode.InternalServerError);
            }




            return ResponseDto<BookDto>.Succes(response.CreateDto(), HttpStatusCode.Accepted);
        }

        public async Task<ResponseDto<bool>> DeleteAsync(string id)
        {
            var isSuccess = await _bookRepository.Delete(id);
            if (!isSuccess)
            {
                return ResponseDto<bool>.Fail(new List<string> { "silme esnasında bir hata meydana geldi." }, System.Net.HttpStatusCode. InternalServerError);
            }
                 return ResponseDto<bool>.Succes(true, HttpStatusCode.NoContent);

        }
        public async Task<ResponseDto<bool>> Update(BookUpdateDto updateDto)
        {
            var isSuccess = await _bookRepository.Update(updateDto);
            if (!isSuccess)
            {
                return ResponseDto<bool>.Fail(new List<string> { "silme esnasında bir hata meydana geldi." }, System.Net.HttpStatusCode.InternalServerError);
            }
            return ResponseDto<bool>.Succes(true, HttpStatusCode.NoContent);

        }
    }
}
