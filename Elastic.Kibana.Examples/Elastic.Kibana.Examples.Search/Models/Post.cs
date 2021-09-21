using System;

namespace Elastic.Kibana.Examples.Search.Models
{
    public class Post
    {
        public string UserName { get; set; }
        public DateTime PostDate { get; set; }
        public string PostText { get; set; }
    }
}