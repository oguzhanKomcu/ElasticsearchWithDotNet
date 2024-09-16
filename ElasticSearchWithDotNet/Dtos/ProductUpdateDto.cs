using ElasticSearchWithDotNet.Models;

namespace ElasticSearchWithDotNet.Dtos
{

    public record BookUpdateDto(string Id,string Author, string Title, string Description, string Name)
    {


    }
}
