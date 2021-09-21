using System;
using Elastic.Kibana.Examples.Search.Models;
using Nest;

namespace Elastic.Kibana.Examples.Search.Logic
{
    public class SearchLogic
    {
        private ElasticClient _elasticClient;
        public SearchLogic(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public void CreateIndexElastiSearch()
        {
            _elasticClient.Indices.Create("posts", a => 
                a.Settings(s=>s.NumberOfReplicas(1).NumberOfShards(1))
                    .Map<Post>(m => m.AutoMap()));
        }

        public void PopulateElasticSearch()
        {
            _elasticClient.IndexDocument(new Post
                {PostDate = DateTime.Now.AddDays(-2), PostText = "Java", UserName = "remigiusz.mrozek"});
            
            _elasticClient.IndexDocument(new Post
                {PostDate = DateTime.Now.AddDays(-1), PostText = "C# Java", UserName = "jan.kowalski"});
            
            _elasticClient.IndexDocument(new Post
                {PostDate = DateTime.Now.AddDays(0), PostText = "Python Java", UserName = "remigiusz.mrozek"});
        }

        public ResponsePost SearchPosts(Models.Search search)
        {

            ISearchResponse<Post> posts = _elasticClient.Search<Post>(s => s
                .Query(q => q.MatchPhrase(m => m.Field("postText").Query(search.Text))));
            return
                new ResponsePost(
                  posts
            );
        }
    }
}