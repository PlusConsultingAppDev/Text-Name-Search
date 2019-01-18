using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchAPI.Models;

namespace SearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DocumentSearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public DocumentSearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        // GET api/values
        [HttpGet, HttpPost]
        public async Task<IActionResult> Search([FromBody] List<SearchParam> searchParams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var taskList = new List<Task<DocumentSearchResult>>();
                foreach (var item in searchParams)
                {
                    var t = CallSearchService(item);
                    taskList.Add(t);
                }

                if (taskList.Count == 0) return NotFound(new List<SearchResult>());

                await Task.WhenAll(taskList);
                var resultList = GenerateSearchResults(taskList);

                return Ok(resultList);
            }
            catch (Exception)
            {
                // 
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        #region "Private Methods"

        private static IEnumerable<SearchResult> GenerateSearchResults(List<Task<DocumentSearchResult>> taskList)
        {
            var resultList = new List<SearchResult>();
            foreach (var task in taskList)
            {
                var fullName = GetFullName(task.Result.SearchQuery);
                var numberOfOccurrences = GetNumberOfOccurrences(task.Result.SearchQuery, task.Result.ContentList);

                resultList.Add(new SearchResult{FullName = fullName, NumberOfOccurrences = numberOfOccurrences});
            }
            return resultList;
        }

        private static string GetFullName(SearchParam searchQuery)
        {
            return searchQuery == null ? string.Empty : $"{searchQuery.FirstName} {searchQuery.MiddleName} {searchQuery.LastName}";
        }

        private Task<DocumentSearchResult> CallSearchService(SearchParam item)
        {
            return _searchService.SearchAsync(item);
        }

        private static int GetNumberOfOccurrences(SearchParam searchQuery, List<string> contentList)
        {
            var valuesToCheck = GetValuesToCheck(searchQuery);
            var result = 0;
            foreach (var item in contentList)
            {
                result += valuesToCheck.Sum(item2 => GetNumberOfOccurrencesFound(item, item2));
            }

            return result;
        }

        private static IEnumerable<string> GetValuesToCheck(SearchParam searchQuery)
        {
            var middleInitial = searchQuery.MiddleName.Substring(0, 1);
            var resultList = new List<string>
            {
                $"{searchQuery.FirstName} {searchQuery.LastName}",
                $"{searchQuery.FirstName} {middleInitial} {searchQuery.LastName}",
                $"{searchQuery.FirstName} {middleInitial}. {searchQuery.LastName}",
                $"{searchQuery.FirstName} {searchQuery.MiddleName} {searchQuery.LastName}"
            };
            return resultList;
        }

        private static int GetNumberOfOccurrencesFound(string content, string valueToFind)
        {
            if (string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(valueToFind))
            {
                return 0;
            }
            return Regex.Matches(content, valueToFind, RegexOptions.Multiline | RegexOptions.IgnoreCase).Count;
        }

        #endregion "Private Methods"

    }
}