using System;
using System.Linq;
using PlusConsulting.NameSearch.SearchCritera.Interfaces;

namespace PlusConsulting.NameSearch.WpfApp.ViewModels
{
    public class ResultsViewModel : ViewModelBase
    {
        private ISearchResults _results;
        public ISearchResults Results
        {
            get => _results;
            set
            {
                _results = value;
                OnPropertyChanged();
                FormatTextFriendlyResults();
            }
        }

        private string _textFriendlyResults;
        public string TextFriendlyResults
        {
            get => _textFriendlyResults;
            set
            {
                _textFriendlyResults = value;
                OnPropertyChanged();
                OnPropertyChanged();
            }
        }

        private void FormatTextFriendlyResults()
        {
            TextFriendlyResults = _results == null
            ? ""
            : string.Join(Environment.NewLine, _results.Keys.Select(key => $"{key} ({_results.GetCountForItem(key)})"));
        }
    }
}
