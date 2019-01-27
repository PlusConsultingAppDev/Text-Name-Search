using System.Net;

namespace EnterpriseDataApp.Models
{
    public class ResponseJSON
    {
        public ResponseJSON() : this("") { }
        public ResponseJSON(RequestJSON request) : this(request.Request.header.token) { }

        public ResponseJSON(string token) : this(HttpStatusCode.OK, "", token) { }

        public ResponseJSON(HttpStatusCode code, string message, string token) : this((int)code, message, token)
        {
        }
        public ResponseJSON(int status, string message, string token)
        {
            Response = new ResponseItem();
            Response.header = new ResponseHeader()
            {
                status = status,
                message = message,
                token = token
            };
            Response.responseDetails = (object)null;
        }
        public ResponseJSON(RequestJSON request, object response) : this(request)
        {
            Response.responseDetails = response;
        }
        public ResponseJSON(string token, object response) : this(token)
        {
            Response.responseDetails = response;
        }

        public ResponseItem Response { get; set; }
    }
    public class ResponseItem
    {
        public ResponseHeader header { get; set; }
        public object responseDetails { get; set; }
    }
    public class ResponseHeader
    {
        public int status { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }
}
