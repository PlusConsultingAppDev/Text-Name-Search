using EnterpriseDataApp.API;
using EnterpriseDataApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseDataApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        [HttpPost("SearchNames")]
        public IActionResult SearchNames([FromBody] SearchRequest request)
        {
            SearchRequest.SearchRequestDetails search = (SearchRequest.SearchRequestDetails)request.Request.requestDetails;

            return Ok(new ResponseJSON(request, new SearchAPI(search.SearchItem).SearchNames()));
        }
    }

    public class SearchRequest : RequestJSON
    {
        public SearchRequest() : base() => Request.requestDetails = new SearchRequestDetails();

        public class SearchRequestDetails : RequestDetails
        {
            public SearchItem SearchItem { get; set; }
        }
    }
}
