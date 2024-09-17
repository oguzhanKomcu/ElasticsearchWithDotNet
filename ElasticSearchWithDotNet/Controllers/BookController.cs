using ElasticSearchWithDotNet.Dtos;
using ElasticSearchWithDotNet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ElasticSearchWithDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController 
    {
        private readonly IBookService _bookService;

        public BookController( IBookService bookService )
        {
            _bookService = bookService;
                
        }

        [NonAction]
        public IActionResult CreateActionResult<T>(ResponseDto<T> response)
        {
            if (response.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = response.Status.GetHashCode() };
            }

            return new ObjectResult(response) { StatusCode = response.Status.GetHashCode() };
        }
        [HttpPost]
        public async Task<IActionResult> Save(BookCreateDto request)
        {

            var result = await _bookService.SaveAsync(request);
            //return Ok (result);

            return CreateActionResult(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(BookUpdateDto request)
        {

            var result = await _bookService.Update(request);
            //return Ok (result);

            return CreateActionResult(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _bookService.GetAll();
            //return Ok (result);

            return CreateActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {

            var result = await _bookService.GetById(id);

            return CreateActionResult(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            var result = await _bookService.DeleteAsync(id);

            return CreateActionResult(result);
        }

        [HttpGet("search/{searchText}")] // Search metodu için
        public async Task<IActionResult> Search(string searchText)
        {
            var result = await _bookService.Search(searchText);
            return CreateActionResult(result);
        }
    }
}
