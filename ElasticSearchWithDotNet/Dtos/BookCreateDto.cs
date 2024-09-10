using ElasticSearchWithDotNet.Models;

namespace ElasticSearchWithDotNet.Dtos
{
    public record BookCreateDto (string Author, string Title, string Description)
    {

        public Book CreateBook()
        {
            Book book = new Book();
            book.Author = Author;
            book.Title = Title;
            book.Description = Description;
            return book;

        }
    }
}
