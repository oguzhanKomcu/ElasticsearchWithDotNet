using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Core.Search;
using Elastic.Clients.Elasticsearch.Nodes;
using Elastic.Clients.Elasticsearch.QueryDsl;
using ElasticSearchWithDotNet.Dtos;
using ElasticSearchWithDotNet.Extensions;
using ElasticSearchWithDotNet.Models;
using System.Collections.Immutable;
using System.Threading;

namespace ElasticSearchWithDotNet.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ElasticsearchClient _elasticClient;
        private const string indexName = "books";
        public BookRepository(ElasticsearchClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<Book?> SaveAsync(Book newBook)
        {
            var response = await _elasticClient.IndexAsync(newBook, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));
            //fast fail
            if (!response.IsSuccess()) return null;

            newBook.Id = response.Id;
            return newBook;
        }
        public async Task<List<Book>> GetAllBook()
        {
            var result = await _elasticClient.SearchAsync<Book>(indexName);

            // _id değerini manuel olarak ayarlıyoruz
            foreach (var hit in result.Hits)
            {
                hit.Source.Id = hit.Id;
            };

            return result.Documents.ToList();
        }

        public async Task<Book?> GetById(string id)
        {
            var result = await _elasticClient.GetAsync<Book>(id, s => s.Index(indexName));
            if (!result.IsSuccess()) return null;

            return result.Source;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _elasticClient.DeleteAsync<Book>(id);

            if (!result.IsSuccess()) return false;
            return result.IsSuccess();
        }

        public async Task<bool> Update(BookUpdateDto bookUpdateDto)
        {
            var response = await _elasticClient.UpdateAsync<Book, BookUpdateDto>(indexName, bookUpdateDto.Id, x => x.Doc(bookUpdateDto));

            return response.IsSuccess();
        }

        public async Task<List<Book>> Search(string searchText)
        {
            var searchRequest = new SearchRequest(indexName)
            {
                Size = 10000,
                Query = new MultiMatchQuery
                {
                    Query = searchText,
                    Fields = Infer.Fields<Book>(p => p.Description, p => p.Name),
                    Type = TextQueryType.CrossFields,
                    Operator = Operator.And
                }
            };


            var searchResponse = await _elasticClient.SearchAsync<Book>(searchRequest);
            // _id değerini manuel olarak ayarlıyoruz
            foreach (var hit in searchResponse.Hits)
            {
                hit.Source.Id = hit.Id;
            };

            return searchResponse.Documents.ToList();
        }
    }
}
