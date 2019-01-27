namespace EnterpriseDataApp.Models
{
    public class RequestJSON
    {
        public RequestJSON()
        {
            Request = new RequestItem();
        }
        public RequestItem Request { get; set; }
    }

    public class RequestItem
    {
        public RequestItem()
        {
            header = new RequestHeader();
        }
        public RequestHeader header { get; set; }
        public object requestDetails { get; set; }
    }

    public class RequestHeader
    {
        public string type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }

    public abstract class RequestDetails
    {

    }
}
