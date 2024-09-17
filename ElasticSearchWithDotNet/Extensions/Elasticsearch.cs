﻿using Elastic.Clients.Elasticsearch;
using Elastic.Transport;


namespace ElasticSearchWithDotNet.Extensions
{
    public static class Elasticsearch
    {

        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {

            var userName = configuration.GetSection("Elastic")["Username"];
            var password = configuration.GetSection("Elastic")["Password"];
            var settings = new ElasticsearchClientSettings(new Uri(configuration.GetSection("Elastic")
            ["url"]!)).Authentication(new BasicAuthentication(userName!, password!));
            var client = new ElasticsearchClient(settings);
            services.AddSingleton(client);
        }
    }
}
