namespace PlusConsulting.NameSearch.SearchCritera.Interfaces
{
    public interface ISearchItem
    {
        int Search(string content);
        string Key { get; }
    }
}
