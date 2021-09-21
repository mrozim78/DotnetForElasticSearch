using Elastic.Kibana.Examples.Search.Logic;
using Elastic.Kibana.Examples.Search.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Nest;

namespace Elastic.Kibana.Examples.Search.Pages
{
    public class Search : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ElasticClient _elasticClient;
        private SearchLogic _searchLogic;
        
        [BindProperty]
        public Models.Search SearchParam { get; set; }
        
        
        public Search(ILogger<IndexModel> logger, ElasticClient elasticClient)
        {
            _logger = logger;
            _elasticClient = elasticClient;
            _searchLogic = new SearchLogic(_elasticClient);
        }
        
        public ResponsePost SearchResponse { get; private set; }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                SearchResponse = _searchLogic.SearchPosts(SearchParam);
            }
            return Page();
        }
    }
}