﻿namespace ElasticSearchWithDotNet.Dtos
{
    public record BookDto
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }



    }
}
