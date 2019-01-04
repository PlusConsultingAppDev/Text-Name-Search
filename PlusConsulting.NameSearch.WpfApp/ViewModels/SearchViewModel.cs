using System.Windows.Input;
using PlusConsulting.NameSearch.SearchCritera;
using PlusConsulting.NameSearch.SearchCritera.Interfaces;

namespace PlusConsulting.NameSearch.WpfApp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private string _url;
        private string _content;
        private bool _useUrl;

        public string Url
        {
            get => _url;
            set
            {
                if (_url == value)
                    return;
                _url = value;
                OnPropertyChanged();
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                if (_content == value)
                    return;
                _content = value;
                OnPropertyChanged();
            }
        }

        public bool UseUrl
        {
            get => _useUrl;
            set
            {
                if (_useUrl == value)
                    return;
                _useUrl = value;
                OnPropertyChanged();
            }
        }

        public ISearchContent GetSearchContent()
        {
            return UseUrl
                ? GetContentFromUrl()
                : new SearchContent {Content = Content, Url = "Manually Entered"};
        }

        private ISearchContent GetContentFromUrl()
        {
            //TODO: Implement ability to scrape content from supplied URL rather than just returning the URL as content itself
            return new SearchContent
            {
                Url = Url,
                Content = Url
            };
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new RelayCommand(p => true, p => Clear()));

        public void Clear()
        {
            Content = "";
        }
    }
}
