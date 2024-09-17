using ElasticSearchWithDotNet.Dtos;


namespace ElasticSearchWithDotNet.Models
{
    public class Book
    {


        public string Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public BookDto CreateDto()
        {
            return new BookDto { Id = Id , Title = Title, Author = Author, Description = Description, Name = Name };
        }
    }
}
