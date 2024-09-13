using ElasticSearchWithDotNet.Dtos;
using ElasticSearchWithDotNet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchWithDotNet.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController( IBookService bookService )
        {
            _bookService = bookService;
                
        }

        [HttpPost]
        public async Task<IActionResult> Save(BookCreateDto request)
        {

            var result = await _bookService.SaveAsync(request);
            return Ok (result);
        }

    }
}
