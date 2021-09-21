using System.Collections.Generic;
using System.Linq;
using Nest;

namespace Elastic.Kibana.Examples.Search.Models
{
    public class ResponsePost
    {
        public List<Post> Posts { get; private set; }
        public string DebugInformation { get; private set; }

        public ResponsePost(ISearchResponse<Post> posts)
        {
            Posts = posts.Documents.ToList();
            DebugInformation = posts.DebugInformation;
        }

    }
}