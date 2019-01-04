namespace PlusConsulting.NameSearch.SearchCritera.Interfaces
{
    public interface ISearchResults
    {
        void AddItemFound(string key, int count);
        int GetCountForItem(string key);
        string ContentUrl { get; }
        string[] Keys { get; }
    }
}
