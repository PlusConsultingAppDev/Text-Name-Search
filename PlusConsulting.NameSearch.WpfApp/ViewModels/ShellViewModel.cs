using System.Linq;
using System.Windows.Input;
using PlusConsulting.NameSearch.SearchCritera;
using PlusConsulting.NameSearch.SearchCritera.Interfaces;

namespace PlusConsulting.NameSearch.WpfApp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private bool _isBackEnabled;
        private string _nextText;
        private ICommand _nextCommand;
        private ICommand _backCommand;
        private ViewModelBase _activeViewModel;
        private readonly NamesViewModel _namesViewModel;
        private readonly SearchViewModel _searchViewModel;
        private readonly ResultsViewModel _resultsViewModel;
        private readonly SearchEngine _searchEngine;

        public ShellViewModel(NamesViewModel namesViewModel, SearchViewModel searchViewModel, ResultsViewModel resultsViewModel)
        {
            _namesViewModel = namesViewModel;
            _searchViewModel = searchViewModel;
            _resultsViewModel = resultsViewModel;
            _searchEngine = new SearchEngine();
            ActiveViewModel = _namesViewModel;
        }

        public ViewModelBase ActiveViewModel
        {
            get => _activeViewModel;
            set
            {
                if (_activeViewModel == value)
                    return;
                _activeViewModel = value;
                OnPropertyChanged();
                IsBackEnabled = value != _namesViewModel;
                NextText = value == _resultsViewModel
                    ? "Start Over"
                    : "Next";
            }
        }

        public bool IsBackEnabled
        {
            get => _isBackEnabled;
            set
            {
                if (_isBackEnabled == value)
                    return;
                _isBackEnabled = value;
                OnPropertyChanged();
            }
        }

        public string NextText
        {
            get => _nextText;
            set
            {
                if (_nextText == value)
                    return;
                _nextText = value;
                OnPropertyChanged();
            }
        }

        public ICommand NextCommand => _nextCommand ?? (_nextCommand = new RelayCommand(p => CanNext(), p => Next()));
        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand(p => ActiveViewModel != _namesViewModel, p => Back()));

        private bool CanNext()
        {
            return (ActiveViewModel == _namesViewModel && _namesViewModel.Names.Any())
                   || (ActiveViewModel == _searchViewModel && !(string.IsNullOrEmpty(_searchViewModel.Content)))
                   || (ActiveViewModel == _resultsViewModel);
        }

        private void Next()
        {
            if (ActiveViewModel == _namesViewModel)
            {
                ActiveViewModel = _searchViewModel;
            }

            else if (ActiveViewModel == _searchViewModel)
            {
                Search();
                ActiveViewModel = _resultsViewModel;
            }

            else if (ActiveViewModel == _resultsViewModel)
            {
                _resultsViewModel.Results = null;
                _namesViewModel.ClearAllNames();
                _searchViewModel.Clear();
                ActiveViewModel = _namesViewModel;
            }
        }

        private void Search()
        {
            ISearchContent searchContent = _searchViewModel.GetSearchContent();
            var searchItems = _namesViewModel.Names.ToArray<ISearchItem>();
            _resultsViewModel.Results = _searchEngine.Search(searchItems, searchContent);
        }

        private void Back()
        {
            if (ActiveViewModel == _resultsViewModel)
            {
                ActiveViewModel = _searchViewModel;
            }
            else if (ActiveViewModel == _searchViewModel)
            {
                ActiveViewModel = _namesViewModel;
            }
        }
    }
}
