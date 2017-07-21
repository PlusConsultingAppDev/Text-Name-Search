using System.Collections.ObjectModel;

namespace WebApplication1.Models
{
    public class NameModelColl
    {
        public Collection<NameModel> Names { get; set; }
    }

    public class NameModel
    {
        public string Name { get; set; }
        public string Count { get; set; }
    }
}