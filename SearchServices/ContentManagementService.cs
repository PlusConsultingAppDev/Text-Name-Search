using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SearchServices
{
    public class ContentRetrieval
    {
        private readonly HttpClient _client;
        
        //we only want to set this using our fetch page method
        public string PageContents { get; private set; }

        public ContentRetrieval()
        {
            _client = new HttpClient();
        }

        async Task FetchPage(string url)
        {
            var response = await _client.GetAsync(url);
            PageContents = await response.Content.ReadAsStringAsync();
        }

    }
}
