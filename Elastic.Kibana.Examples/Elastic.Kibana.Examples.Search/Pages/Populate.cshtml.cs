using Elastic.Kibana.Examples.Search.Logic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Nest;

namespace Elastic.Kibana.Examples.Search.Pages
{
    public class Populate : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ElasticClient _elasticClient;
        private SearchLogic _searchLogic;
        
        public Populate(ILogger<IndexModel> logger, ElasticClient elasticClient)
        {
            _logger = logger;
            _elasticClient = elasticClient;
            _searchLogic = new SearchLogic(_elasticClient);

        }
        
        public void OnGet()
        {
            _searchLogic.CreateIndexElasticSearch();
            _searchLogic.PopulateElasticSearch();
        }
    }
}