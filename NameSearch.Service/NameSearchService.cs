using NameSearch.Data;
using NameSearch.Service.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NameSearch.Service
{
    public class NameSearchService : INameSearchService
    {
        private readonly IDataSource _dataSource;

        public NameSearchService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public bool AddNameToSearch(string firstName, string middleName, string lastName)
        {
            try
            {
                if (NamesForSearch.HasSearchCompleted)
                {
                    NamesForSearch.HasSearchCompleted = false;
                    NamesForSearch.NameSearchModels = null;
                }

                if (NamesForSearch.NameSearchModels == null)
                {
                    NamesForSearch.NameSearchModels = new List<NameSearchModel>();
                }

                NamesForSearch.NameSearchModels.Add(new NameSearchModel
                {
                    SavedFirstName = firstName,
                    SavedMiddleName = middleName,
                    SavedLastName = lastName
                });
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public List<NameSearchModel> GetNamesToSearch()
        {
            return NamesForSearch.NameSearchModels;
        }

        public List<SearchResult> SearchArticleText(string firstName, string middleName, string lastName)
        {
            List<SearchResult> results = new List<SearchResult>();

            string sPattern1 = $@"\b{firstName.ToLower()} {lastName.ToLower()}\b";
            int match1 = Regex.Matches(_dataSource.Text.ToLower(), sPattern1, RegexOptions.IgnoreCase).Count;

            if (match1 > 0)
            {
                results.Add(new SearchResult
                {
                    DisplayPattern = $"{firstName} {lastName}",
                    Occurences = match1,
                    Pattern = sPattern1
                });
            }


            string sPattern2 = $@"\b{firstName.ToLower()} {middleName.ToLower()[0]} {lastName.ToLower()}\b";
            int match2 = Regex.Matches(_dataSource.Text.ToLower(), sPattern2, RegexOptions.IgnoreCase).Count;

            if (match2 > 0)
            {
                results.Add(new SearchResult
                {
                    DisplayPattern = $"{firstName} {middleName[0]} {lastName}",
                    Occurences = match2,
                    Pattern = sPattern2
                });
            }

            string sPattern3 = $@"\b{firstName.ToLower()} {middleName.ToLower()[0]}\. {lastName.ToLower()}\b";
            int match3 = Regex.Matches(_dataSource.Text.ToLower(), sPattern3, RegexOptions.IgnoreCase).Count;

            if (match3 > 0)
            {
                results.Add(new SearchResult
                {
                    DisplayPattern = $"{firstName} {middleName[0]}. {lastName}",
                    Occurences = match3,
                    Pattern = sPattern3
                });
            }

            string sPattern4 = $@"\b{firstName.ToLower()} {middleName.ToLower()} {lastName.ToLower()}\b";
            int match4 = Regex.Matches(_dataSource.Text.ToLower(), sPattern4, RegexOptions.IgnoreCase).Count;

            if (match4 > 0)
            {
                results.Add(new SearchResult
                {
                    DisplayPattern = $"{firstName} {middleName} {lastName}",
                    Occurences = match4,
                    Pattern = sPattern4
                });
            }


            return results;
        }

        public List<NameSearchModel> SearchTextForAllSavedNames()
        {
            foreach (var name in NamesForSearch.NameSearchModels)
            {
                name.Occurences = SearchArticleText(name.SavedFirstName, name.SavedMiddleName, name.SavedLastName);
            }

            return NamesForSearch.NameSearchModels;
        }


    }
}
