using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SupportServices
{
    public class ContentManagementService
    {
        private static HttpClient _client = new HttpClient();

        //we only want to set this using our fetch page method
        public string PageContents { get; private set; }

        public ContentManagementService()
        {
        }

        public async Task<string> FetchPageAsync(string uri)
        {

            HttpResponseMessage response = await _client.GetAsync(uri);
            try
            {
                //will throw an exception if not successful
                response.EnsureSuccessStatusCode(); 
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            if (response.IsSuccessStatusCode)
            {
                PageContents = await response.Content.ReadAsStringAsync();// .ReadAsAsync<string>();
            }

            return PageContents;
        }

        public string FetchPage(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

